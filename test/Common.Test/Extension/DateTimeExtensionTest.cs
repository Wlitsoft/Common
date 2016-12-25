using System;
using Wlitsoft.Framework.Common.Extension;
using Xunit;

namespace Common.Test.Extension
{
    public class DateTimeExtensionTest
    {
        [Fact]
        public void GetUnixTimestampTest()
        {
            DateTime testDateTime = Convert.ToDateTime("2016-12-25 14:45:00");
            long testUnixTimestamp = testDateTime.GetUnixTimestamp();

            Assert.Equal<long>(1482648300, testUnixTimestamp);
        }
    }
}
