using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Log;
using Xunit;

namespace Common.Test.Log
{
    /// <summary>
    /// 日志服务测试。
    /// </summary>
    public class LoggerServiceTest
    {
        [Fact]
        public void GetLoggerTest()
        {
            LoggerService loggerService = new LoggerService();
            ILog logger = loggerService.GetLogger();

            Assert.NotNull(logger);
            Assert.IsType<EmptyLogger>(logger);
        }
    }
}
