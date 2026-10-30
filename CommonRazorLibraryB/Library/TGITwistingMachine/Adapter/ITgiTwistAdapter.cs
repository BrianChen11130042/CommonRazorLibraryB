using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Adapter
{
    public interface ITgiTwistAdapter<T>
    {
        Task<bool> GetTwistStatus(T t);

        Task<bool> SetTaskCompletion(T t);

        Task<bool> SetAutoMode(T t);
    }
}
