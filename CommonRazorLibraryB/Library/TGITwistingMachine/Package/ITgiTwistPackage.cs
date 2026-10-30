using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Package
{
    public interface ITgiTwistPackage<T>
    {
        Dictionary<T, TgiTwistPackage> Packages { get; set; }
    }
}
