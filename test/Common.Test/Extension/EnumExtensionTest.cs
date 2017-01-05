using System.ComponentModel;
using Wlitsoft.Framework.Common.Extension;
using Xunit;

namespace Common.Test.Extension
{
    public class EnumExtensionTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            Sex sex = Sex.Nan;
            string text = sex.GetDescription();

            Assert.Equal<string>("男", text);
        }

        [Fact]
        public void GetEnumItemByDescriptionTest()
        {
            Sex sex = EnumExtension.GetEnumItemByDescription<Sex>("男");

            Assert.Equal<Sex>(Sex.Nan, sex);
        }
    }

    public enum Sex
    {
        [Description("男")]
        Nan,

        [Description("女")]
        Nv
    }
}
