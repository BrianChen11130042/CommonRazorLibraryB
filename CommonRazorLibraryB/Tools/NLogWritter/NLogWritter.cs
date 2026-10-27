using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace CommonRazorLibraryB.Tools.NLogWritter
{
    public enum ENLogLevel
    {
        Event,
        Info,
        Error
    }

    public class NLogWritter : INLogObserver
    {
        public Logger logger;
        public string _directory;
        static Mutex mutex;

        public NLogWritter(string dir)
        {
            _directory = dir + "Logs";

            mutex = new Mutex();

            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        }

        public async Task HandleNLog(ENLogLevel status, string msg)
        {
            mutex.WaitOne();

            switch (status)
            {
                case ENLogLevel.Event:
                    logger.Trace(msg);
                    break;

                case ENLogLevel.Info:
                    logger.Info(msg);
                    break;

                case ENLogLevel.Error:
                    logger.Error(msg);
                    break;

                default:
                    break;
            }

            mutex.ReleaseMutex();
        }
    }
}
