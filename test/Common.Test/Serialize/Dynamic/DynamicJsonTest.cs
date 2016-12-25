using Common.Test.Model;
using Wlitsoft.Framework.Common.Serialize.Dynamic;
using Xunit;

namespace Common.Test.Serialize.Dynamic
{
    public class DynamicJsonTest
    {
        [Fact]
        public void ParseTest()
        {
            string json = "{\"e1\":\"abc\"}";
            dynamic jsonObj = DynamicJson.Parse(json);

            Assert.NotNull(jsonObj);
            Assert.Equal("abc", jsonObj.e1);
        }

        [Fact]
        public void SerializeTest()
        {
            PersonModel model = new PersonModel()
            {
                Name = "p1",
                Age = 21
            };
            string json = DynamicJson.Serialize(model);

            Assert.NotNull(json);
            Assert.True(json.Length > 0);

            Assert.True(json.Contains("21"));
        }
    }
}
