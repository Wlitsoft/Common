using System;
using System.IO;
using Wlitsoft.Framework.Common.Log4Net.Logger;
using Xunit;

namespace Common.Log4Net.Logger.Test
{
    public class Log4NetLoggerTest
    {
        [Fact]
        public void CreateLoggerTest()
        {
            log4net.ILog log = log4net.LogManager.GetLogger("test");
            Log4NetLogger logger = new Log4NetLogger(log);

            Assert.NotNull(logger);
        }

        [Fact]
        public void InfoTest()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("./Conf/log4net.conf"));
            log4net.ILog log = log4net.LogManager.GetLogger("Test");
            Log4NetLogger logger = new Log4NetLogger(log);
            logger.Info($"Test{DateTime.Now}");
        }
    }
}
