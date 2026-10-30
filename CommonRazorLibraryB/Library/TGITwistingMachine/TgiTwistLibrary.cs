using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Library.TGITwistingMachine.Adapter;
using CommonRazorLibraryB.Library.TGITwistingMachine.Config;
using CommonRazorLibraryB.Library.TGITwistingMachine.Package;
using CommonRazorLibraryB.Library.TGITwistingMachine.Property;
using CommonRazorLibraryB.Manager.ModbusTcp.Master;

namespace CommonRazorLibraryB.Library.TGITwistingMachine
{
    public partial class TgiTwistLibrary<T>
    {
        public ModbusTcpMasterManager modbusTcpMasterManager;

        public TgiTwistConfigManager<T> configManager;

        public TgiTwistPropertyManager<T> propertyManager;

        public TgiTwistLibrary(ModbusTcpMasterManager modbusTcpMasterManager,
                               TgiTwistConfigManager<T> configManager,
                               TgiTwistPropertyManager<T> propertyManager)
        {
            this.modbusTcpMasterManager = modbusTcpMasterManager;
            this.configManager = configManager;
            this.propertyManager = propertyManager;
        }

    }

    public partial class TgiTwistLibrary<T> : ITgiTwistPackage<T>
    {
        public Dictionary<T, TgiTwistPackage> _packages { get; set; }

        public Dictionary<T, TgiTwistPackage> Packages
        {
            get
            {
                return _packages;
            }
            set
            {
                _packages = value;
            }
        }

        public void InitPackage()
        {
            if (Packages == null)
            {
                Packages = new Dictionary<T, TgiTwistPackage>();

                foreach (T dev in Enum.GetValues(typeof(T)))
                {
                    Packages.Add(dev, new TgiTwistPackage());
                }
            }

            foreach (T dev in Enum.GetValues(typeof(T)))
            {
                Packages[dev].config = configManager.table[dev.ToString()];
                Packages[dev].property = propertyManager.table[dev.ToString()];

                string master = configManager.table[dev.ToString()].master.ToString();
                Packages[dev].master = modbusTcpMasterManager.table[master].modbusTcpMaster;
            }
        }
    }

    public partial class TgiTwistLibrary<T> : ITgiTwistAdapter<T>
    {
        TgiTwistAdapter adapter;

        public void InitAdapter()
        {
            List<TgiTwistConfig> cs = configManager.table.Values.ToList();
            adapter = new TgiTwistAdapter(cs);
        }

        ITgiTwistAdapter<TgiTwistPackage> SelectAdapter(T t)
        {
            string key = t.ToString();
            TgiTwistConfig c = configManager.table[key];
            return adapter[c.supplier];
        }

        public async Task<bool> GetTwistStatus(T t)
        {
            return await SelectAdapter(t).GetTwistStatus(Packages[t]);
        }

        public async Task<bool> SetAutoMode(T t)
        {
            return await SelectAdapter(t).SetAutoMode(Packages[t]);
        }

        public async Task<bool> SetTaskCompletion(T t)
        {
            return await SelectAdapter(t).SetTaskCompletion(Packages[t]);
        }
    }
}
