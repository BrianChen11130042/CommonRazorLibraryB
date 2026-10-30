using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Base.Adapter;
using CommonRazorLibraryB.Library.TGITwistingMachine.Config;
using CommonRazorLibraryB.Library.TGITwistingMachine.Package;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Adapter
{

    public enum ETgiTwistSupplier { TgiTwist1 }

    public class TgiTwistAdapter : AdapterBase<TgiTwistConfig, ETgiTwistSupplier, ITgiTwistAdapter<TgiTwistPackage>>
    {
        public TgiTwistAdapter(List<TgiTwistConfig> keys) : base(keys)
        {

        }

        protected override void InitAdapter(List<TgiTwistConfig> keys)
        {
            foreach(var v in keys)
            {
                ETgiTwistSupplier supplier = v.supplier;

                if (table.ContainsKey(supplier))
                    continue;

                switch(supplier)
                {
                    case ETgiTwistSupplier.TgiTwist1:
                        table.Add(supplier, new AdapterTgiTwistingMachine1());
                        break;
                }
            }
        }
    }
}
