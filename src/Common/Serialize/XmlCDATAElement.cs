/**********************************************************************************************************************
 * 描述：
 *      Xml CDATA 元素。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月23日	 新建
 *********************************************************************************************************************/
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Wlitsoft.Framework.Common.Serialize
{
    /// <summary>
    /// Xml CDATA 元素。
    /// </summary>
    public class XmlCDATAElement : IXmlSerializable
    {
        #region 公共属性

        /// <summary>
        /// 获取或设置 元素文本值。
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="XmlCDATAElement"/> 类的新实例。
        /// </summary>
        public XmlCDATAElement()
        {

        }

        /// <summary>
        /// 根据内容文本值初始化 <see cref="XmlCDATAElement"/> 类的新实例。
        /// </summary>
        /// <param name="value">内容文本值。</param>
        public XmlCDATAElement(string value)
        {
            this.Value = value;
        }

        #endregion

        #region 操作符重载

        /// <summary>
        /// <see cref="XmlCDATAElement"/> 转 <see cref="string"/> 。
        /// </summary>
        /// <param name="element">Xml CDATA 元素对象。</param>
        /// <returns>一个字符串。</returns>
        public static implicit operator string(XmlCDATAElement element)
        {
            return (element == null) ? null : element.Value;
        }

        /// <summary>
        /// <see cref="string"/> 转 <see cref="XmlCDATAElement"/>。
        /// </summary>
        /// <param name="value">一个字符串。</param>
        /// <returns>Xml CDATA 元素对象。</returns>
        public static implicit operator XmlCDATAElement(string value)
        {
            return new XmlCDATAElement(value);
        }

        #endregion

        #region IXmlSerializable 成员

        /// <summary>
        /// 此方法是保留方法，请不要使用。 在实现 IXmlSerializable 接口时，应从此方法返回 null（在 Visual Basic 中为 Nothing），如果需要指定自定义架构，应向该类应用 <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/>。
        /// </summary>
        /// 
        /// <returns>
        /// <see cref="T:System.Xml.Schema.XmlSchema"/>，描述由 <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> 方法产生并由 <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> 方法使用的对象的 XML 表示形式。
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// 从对象的 XML 表示形式生成该对象。
        /// </summary>
        /// <param name="reader">对象从中进行反序列化的 <see cref="T:System.Xml.XmlReader"/> 流。</param>
        public void ReadXml(XmlReader reader)
        {
            this.Value = reader.ReadElementContentAsString();
        }

        /// <summary>
        /// 将对象转换为其 XML 表示形式。
        /// </summary>
        /// <param name="writer">对象要序列化为的 <see cref="T:System.Xml.XmlWriter"/> 流。</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteCData(this.Value);
        }

        #endregion

        #region Object 成员

        /// <summary>
        /// 返回表示当前对象的字符串。
        /// </summary>
        /// 
        /// <returns>
        /// 表示当前对象的字符串。
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return this.Value;
        }

        #endregion
    }
}
