using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Property
{
    public class TgiTwistProperty
    {
        public string device { get; set; }

        public SetTgiTwist set { get; set; } = new SetTgiTwist();

        public GetTgiTwist get { get; set; } = new GetTgiTwist();
    }

    public class SetTgiTwist
    {
        //完成作業列表
        public ushort taskCompletion { get; set; } 

        //自動模式
        public ushort autoMode { get; set; } 
    }

    public class GetTgiTwist
    {
        //撚紗機編號
        public ushort machineNumber { get; set; }

        //狀態列表一
        public ushort processState { get; set; }

        //狀態列表二
        public ushort machineStatus { get; set; }

        //通知作業列表
        public ushort taskStartedInform { get; set; }

        //完成作業列表
        public ushort taskCompletedInform { get; set; }

        //自動模式
        public ushort isAutoMode { get; set; }

    }

}
