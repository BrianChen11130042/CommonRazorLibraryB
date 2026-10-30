using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.Library.TGITwistingMachine.Package;

namespace CommonRazorLibraryB.Library.TGITwistingMachine.Adapter
{
    public partial class AdapterTgiTwistingMachine1
    {
        enum EGetOperate
        {
            TwistStatus
        }

        void getCmd(EGetOperate operate, TgiTwistPackage t)
        {
            switch(operate)
            {
                case EGetOperate.TwistStatus:
                    cmdTwistStatus(t);
                    break;
            }
        }

        void cmdTwistStatus(TgiTwistPackage t)
        {
            t.station = 1;
            t.startAddress = 1;
            t.offset = 10;
        }
    }

    public partial class AdapterTgiTwistingMachine1
    {
        void unpack(EGetOperate operate, TgiTwistPackage t)
        {
            switch(operate)
            {
                case EGetOperate.TwistStatus:
                    upTwistStatus(t);
                    break;
            }
        }

        void upTwistStatus(TgiTwistPackage t)
        {
            t.property.get.machineNumber = t.arrayRcmd[0];
            t.property.get.processState = t.arrayRcmd[1];
            t.property.get.machineStatus = t.arrayRcmd[2];
            t.property.get.taskStartedInform = t.arrayRcmd[3];
            t.property.get.taskCompletedInform = t.arrayRcmd[4];
            t.property.get.isAutoMode = t.arrayRcmd[5];
        }
    }

    public partial class AdapterTgiTwistingMachine1
    {
        enum ESetOperate
        {
            TaskCompletion,
            AutoMode
        }

        void getCmd(ESetOperate operate, TgiTwistPackage t)
        {
            switch(operate)
            {
                case ESetOperate.TaskCompletion:
                    cmdTaskCompletion(t);
                    break;

                case ESetOperate.AutoMode:
                    cmdAutoMode(t);
                    break;
            }
        }

        void cmdTaskCompletion(TgiTwistPackage t)
        {
            ushort[] temp = new ushort[1];
            temp[0] = t.property.set.taskCompletion;

            t.arrayCmd = temp;
            t.station = 1;
            t.startAddress = 5;
        }

        void cmdAutoMode(TgiTwistPackage t)
        {
            ushort[] temp = new ushort[1];
            temp[0] = t.property.set.autoMode;

            t.arrayCmd = temp;
            t.station = 1;
            t.startAddress = 6;
        }
    }

    public partial class AdapterTgiTwistingMachine1 : ITgiTwistAdapter<TgiTwistPackage>
    {
        public async Task<bool> GetTwistStatus(TgiTwistPackage t)
        {
            try
            {
                if(t.master is null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.TwistStatus, t);
                await getMultiRegister(t);
                unpack(EGetOperate.TwistStatus, t);

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetTaskCompletion(TgiTwistPackage t)
        {
            try
            {
                if (t.master is null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.TaskCompletion, t);
                await setMultiRegister(t);

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetAutoMode(TgiTwistPackage t)
        {
            try
            {
                if (t.master is null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.AutoMode, t);
                await setMultiRegister(t);

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }
    }

    public partial class AdapterTgiTwistingMachine1
    {
        void setModbusTcpError()
        {
            throw new InvalidOperationException("Modbus Tcp Disconnect");
        }

        async Task getMultiRegister(TgiTwistPackage t)
        {
            t.arrayRcmd = await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);
        }

        async Task setMultiRegister(TgiTwistPackage t)
        {
            await t.master.WriteMultipleRegistersAsync((byte)t.station, (ushort)t.startAddress, t.arrayCmd);
        }
    }
}
