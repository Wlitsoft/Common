using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Serialize;
using Xunit;

namespace Common.Test.Serialize
{
    public class XmlCDATAElementTest
    {
        /// <summary>
        /// 一个用于测试的 Xml 字符串。
        /// </summary>
        private const string _xml = @"<xml>
                                          <Element1><![CDATA[<h1>Hello World!</h1>]]></Element1>
                                          <Str>this is a string</Str>
                                      </xml>";

        [Fact]
        public void XmlCDATAElementSerializableTest()
        {
            XmlCDATAElementTestModel model = new XmlCDATAElementTestModel()
            {
                Element1 = "<h1>Hello World!</h1>",
                Str = "this is a string"
            };

            string expectedXml = _xml.FormatXmlString();
            string actualXml = model.ToXmlString().FormatXmlString();
            Assert.Equal(expectedXml, actualXml);
        }

        [Fact]
        public void XmlCDATAElementDeserializeTest()
        {
            XmlCDATAElementTestModel model = _xml.ToXmlObject<XmlCDATAElementTestModel>();
            Assert.Equal("<h1>Hello World!</h1>", model.Element1.Value);
        }
    }

    /// <summary>
    /// Xml CDATA 元素 序列化/反序列化测试类 测试模型。
    /// </summary>
    [XmlRoot("xml")]
    public class XmlCDATAElementTestModel
    {
        /// <summary>
        /// 获取或设置元素1。
        /// </summary>
        public XmlCDATAElement Element1 { get; set; }

        /// <summary>
        /// 获取或设置一个字符串。
        /// </summary>
        public string Str { get; set; }
    }
}
