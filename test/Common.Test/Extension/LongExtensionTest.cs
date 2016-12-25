using System;
using Wlitsoft.Framework.Common.Extension;
using Xunit;

namespace Common.Test.Extension
{
    public class LongExtensionTest
    {
        [Fact]
        public void ToDateTimeTest()
        {
            long testUnixTimestamp = 1482648300;
            DateTime testUnixDateTime = testUnixTimestamp.ToDateTime();

            Assert.Equal<DateTime>(Convert.ToDateTime("2016-12-25 14:45:00"), testUnixDateTime);
        }
    }
}
