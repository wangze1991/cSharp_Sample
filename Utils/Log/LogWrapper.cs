using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Utils
{
    public  class LogWrapper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Debug(string content) {
            logger.Debug(content);
        }
        public static void Info(string content)
        {
            logger.Info(content);
        }
        public static void Error(string content)
        {
            logger.Error(content);
        }
    }
}
