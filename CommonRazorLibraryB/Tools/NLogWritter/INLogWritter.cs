using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CommonRazorLibraryB.Tools.NLogWritter
{
    public interface INLogObservable
    {
        void AddNLogObserver(INLogObserver o);

        void RemoveNLogObserver(INLogObserver o);

        Task NotifyNLog(ENLogLevel level, string msg);
    }

    public interface INLogObserver
    {
        Task HandleNLog(ENLogLevel level, string msg);
    }
}
