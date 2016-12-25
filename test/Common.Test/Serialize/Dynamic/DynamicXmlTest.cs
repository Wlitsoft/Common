using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wlitsoft.Framework.Common.Serialize.Dynamic;
using Xunit;

namespace Common.Test.Serialize.Dynamic
{
    public class DynamicXmlTest
    {
        [Fact]
        public void Test01()
        {
            string xml = @"<xml><e1>abc</e1></xml>";
            dynamic obj = new DynamicXml(xml);

            Assert.NotNull(obj);
            Assert.Equal("abc", obj.e1.Value);
        }
    }
}
