using System.Collections.Generic;
using Wlitsoft.Framework.Common.Security;
using Xunit;

namespace Common.Test.Security
{
    public class ParamsSignerTest
    {

        [Fact]
        public void GetSignTest()
        {
            ParamsSigner paramsSigner = new ParamsSigner("wlitsoft");

            Dictionary<string, string> paramsDic = new Dictionary<string, string>
            {
                {"p1", "v1"},
                {"p2", "v2"}
            };

            paramsSigner.Params = paramsDic;
            string sign = paramsSigner.GetSign();

            Assert.NotNull(sign);
            Assert.True(sign.Length > 0);
        }
    }
}
