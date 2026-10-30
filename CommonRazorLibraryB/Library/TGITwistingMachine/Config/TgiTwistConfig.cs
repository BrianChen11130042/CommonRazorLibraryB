using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Library.TGITwistingMachine.Adapter;
using CommonRazorLibraryB.Manager.ModbusTcp.Master;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Config
{
    public class TgiTwistConfig
    {
        public string device { get; set; }

        public EModbusTcpMaster master { get; set; } = EModbusTcpMaster.Master1;

        public ETgiTwistSupplier supplier { get; set; } = ETgiTwistSupplier.TgiTwist1;

    }
}
