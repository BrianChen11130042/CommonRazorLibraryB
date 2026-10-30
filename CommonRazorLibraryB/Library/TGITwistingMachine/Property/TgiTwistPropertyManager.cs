using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Base.Manager;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Property
{
    public class TgiTwistPropertyManager<E> : ManagerBase<E, TgiTwistProperty>
    {
        public string Directory;

        public const string fileName = "TgiTwistProperty.json";

        public TgiTwistPropertyManager(string dir) : base(dir + "Property\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, TgiTwistProperty>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new TgiTwistProperty() { device = key });
                }
            }
        }
    }
}
