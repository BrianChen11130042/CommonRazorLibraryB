using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Base.Manager;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Config
{
    public class TgiTwistConfigManager<E> : ManagerBase<E, TgiTwistConfig>
    {
        public string Directory { get; set; }

        public const string fileName = "TgiTwistConfig.json";

        public TgiTwistConfigManager(string dir) : base(dir + "Config\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, TgiTwistConfig>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new TgiTwistConfig() { device = key});
                }
            }
        }
    }
}
