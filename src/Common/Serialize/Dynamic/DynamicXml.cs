/**********************************************************************************************************************
 * 描述：
 *      动态 Xml 对象。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月23日	 新建
 *********************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Xml.Linq;
using System.Collections;


namespace Wlitsoft.Framework.Common.Serialize.Dynamic
{
    /// <summary>
    /// 动态 Xml 对象。
    /// </summary>
    public class DynamicXml : DynamicObject, IEnumerable
    {
        //元素。
        private readonly List<XElement> _elements;

        #region 构造方法

        /// <summary>
        /// 根据 xml 字符串初始化 <see cref="DynamicXml"/> 的新实例。
        /// </summary>
        /// <param name="text"></param>
        public DynamicXml(string text)
        {
            var doc = XDocument.Parse(text);
            _elements = new List<XElement> { doc.Root };
        }

        /// <summary>
        /// 根据 xml 元素对象初始化 <see cref="DynamicXml"/> 的新实例。
        /// </summary>
        /// <param name="element">xml 元素对象。</param>
        protected DynamicXml(XElement element)
        {
            _elements = new List<XElement> { element };
        }

        /// <summary>
        /// 根据 xml 元素集合初始化 <see cref="DynamicXml"/> 的新实例。
        /// </summary>
        /// <param name="elements">xml 元素集合。</param>
        protected DynamicXml(IEnumerable<XElement> elements)
        {
            _elements = new List<XElement>(elements);
        }

        #endregion

        #region DynamicObject 成员

        /// <summary>为获取成员值的操作提供实现。从 <see cref="T:System.Dynamic.DynamicObject" /> 类派生的类可以重写此方法，以便为诸如获取属性值这样的操作指定动态行为。</summary>
        /// <param name="binder">提供有关调用了动态操作的对象的信息。binder.Name 属性提供针对其执行动态操作的成员的名称。例如，对于 Console.WriteLine(sampleObject.SampleProperty) 语句（其中 sampleObject 是派生自 <see cref="T:System.Dynamic.DynamicObject" /> 类的类的一个实例），binder.Name 将返回“SampleProperty”。binder.IgnoreCase 属性指定成员名称是否区分大小写。</param>
        /// <param name="result">获取操作的结果。例如，如果为某个属性调用该方法，则可以为 <paramref name="result" /> 指派该属性值。</param>
        /// <returns>如果此运算成功，则为 true；否则为 false。如果此方法返回 false，则该语言的运行时联编程序将决定行为。（大多数情况下，将引发运行时异常。）</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (binder.Name == "Value")
                result = _elements[0].Value;
            else if (binder.Name == "Count")
                result = _elements.Count;
            else
            {
                var attr = _elements[0].Attribute(XName.Get(binder.Name));
                if (attr != null)
                    result = attr;
                else
                {
                    var items = _elements.Descendants(XName.Get(binder.Name));
                    if (items == null || items.Count() == 0) return false;
                    result = new DynamicXml(items);
                }
            }
            return true;
        }

        /// <summary>为按索引获取值的操作提供实现。从 <see cref="T:System.Dynamic.DynamicObject" /> 类派生的类可以重写此方法，以便为索引操作指定动态行为。</summary>
        /// <param name="binder">提供有关该操作的信息。</param>
        /// <param name="indexes">该操作中使用的索引。例如，对于 C# 中的 sampleObject[3] 操作（Visual Basic 中为 sampleObject(3)）（其中 sampleObject 派生自 DynamicObject 类），<paramref name="indexes[0]" /> 等于 3。</param>
        /// <param name="result">索引操作的结果。</param>
        /// <returns>如果此运算成功，则为 true；否则为 false。如果此方法返回 false，则该语言的运行时联编程序将决定行为。（大多数情况下，将引发运行时异常。）</returns>
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            int ndx = (int)indexes[0];
            result = new DynamicXml(_elements[ndx]);
            return true;
        }

        #endregion

        #region IEnumerable 成员

        /// <summary>返回一个循环访问集合的枚举器。</summary>
        /// <returns>可用于循环访问集合的 <see cref="T:System.Collections.IEnumerator" /> 对象。</returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var element in _elements)
                yield return new DynamicXml(element);
        }

        #endregion

    }
}