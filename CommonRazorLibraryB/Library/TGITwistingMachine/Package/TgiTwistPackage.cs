using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Library.TGITwistingMachine.Config;
using CommonRazorLibraryB.Library.TGITwistingMachine.Property;
using CommonRazorLibraryB.Manager.ModbusTcp.Master;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Package
{
    public class TgiTwistPackage : ModbusTcpMasterPack
    {
        public TgiTwistConfig config { get; set; }

        public TgiTwistProperty property { get; set; }

        public string errorLog { get; set; } = string.Empty;

        public SemaphoreSlim gate { get; } = new SemaphoreSlim(1, 1);
    }
}
