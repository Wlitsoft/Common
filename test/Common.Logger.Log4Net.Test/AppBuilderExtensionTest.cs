using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Logger.Log4Net;
using Xunit;

namespace Common.Log4Net.Logger.Test
{
    public class AppBuilderExtensionTest
    {
        [Fact]
        public void SetLog4NetLoggerByXmlConfigTest()
        {
            App.Builder.SetLog4NetLoggerByXmlConfig("./Conf/log4net.conf");
            ILog log = App.LoggerService.GetLogger("Test");

            Assert.NotNull(log);
            Assert.IsType<Log4NetLogger>(log);
        }

        [Fact]
        public void DebugTest()
        {
            App.Builder.SetLog4NetLoggerByXmlConfig("./Conf/log4net.conf");
            ILog log = App.LoggerService.GetLogger("Test");

            log.Debug("Debug Info");
        }
    }
}
