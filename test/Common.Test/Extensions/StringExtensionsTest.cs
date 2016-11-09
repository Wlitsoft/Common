/**********************************************************************************************************************
 * 描述：
 *      字符串类型扩展方法静态类 测试。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 *********************************************************************************************************************/

using Common.Test.Model;
using Xunit;
using Wlitsoft.Framework.Common.Extensions;

namespace Common.Test.Extensions
{
    /// <summary>
    /// 字符串类型扩展方法静态类 测试。
    /// </summary>
    public class StringExtensionsTest
    {
        [Fact]
        public void ToJsonObjectTest()
        {
            const string json = "{\"Age\":5,\"Name\":\"Common\"}";

            PersonModel model = json.ToJsonObject<PersonModel>();

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }

        [Fact]
        public void ToXmlObject_TTest()
        {
            const string xml = @"<PersonModel>
                                    <Name>Common</Name>
                                    <Age>5</Age>
                                </PersonModel>";

            PersonModel model = xml.ToXmlObject<PersonModel>();

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }

        [Fact]
        public void ToXmlObjectTest()
        {
            const string xml = @"<PersonModel>
                                    <Name>Common</Name>
                                    <Age>5</Age>
                                </PersonModel>";

            PersonModel model = (PersonModel)xml.ToXmlObject(typeof(PersonModel));

            Assert.NotNull(model);
            Assert.Equal<string>("Common", model.Name);
            Assert.Equal<int>(5, model.Age);
        }

        [Fact]
        public void GetMD5Test()
        {
            string str = "hello";

            string expected = "5D41402ABC4B2A76B9719D911017C592";
            string actual = str.GetMD5();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSHA1Test()
        {
            string str = "hello";

            string expected = "AAF4C61DDCC5E8A2DABEDE0F3B482CD9AEA9434D";
            string actual = str.GetSHA1();

            Assert.Equal(expected, actual);
        }
    }
}
