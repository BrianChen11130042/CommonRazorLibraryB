using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonRazorLibraryB.UIComponentTools.ToastMessage
{
    public interface IToastMessage
    {
        void NotifyInfo(string msg);

        void NotifySuccess(string msg);

        void NotifyError(string msg);

        event dgNotifyToastMsg dgNotifyToast;
    }
}
