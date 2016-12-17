/**********************************************************************************************************************
 * 描述：
 *      序列化服务。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月03日	 新建
 * 
 *********************************************************************************************************************/
using System.Collections.Generic;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common.Serialize
{
    /// <summary>
    /// 序列化服务。
    /// </summary>
    public class SerializerService
    {
        #region 私有属性

        private static readonly Dictionary<SerializeType, ISerializer> Serializers = new Dictionary<SerializeType, ISerializer>();

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="SerializerService"/> 的静态实例。
        /// </summary>
        static SerializerService()
        {
            Serializers.Add(SerializeType.Xml, new XmlSerializer());
            Serializers.Add(SerializeType.Json, new JsonSerializer());
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取一个 <see cref="ISerializer"/> 的实例。
        /// </summary>
        /// <param name="type">序列化类型。</param>
        /// <returns>一个 <see cref="ISerializer"/> 类型的对象实例。</returns>
        public ISerializer GetSerializer(SerializeType type)
        {
            return Serializers[type];
        }

        /// <summary>
        /// 设置序列化者。
        /// </summary>
        /// <param name="type">序列化类型。</param>
        /// <param name="serializer">序列化者。</param>
        internal SerializerService SetSerializer(SerializeType type, ISerializer serializer)
        {
            #region 参数校验

            if (serializer == null)
                throw new ObjectNullException(nameof(serializer));

            #endregion

            //如果存在则更新，
            if (Serializers.ContainsKey(type))
                Serializers[type] = serializer;
            else
                Serializers.Add(type, serializer);

            return this;
        }

        /// <summary>
        /// 获取 Json 序列化者。
        /// </summary>
        /// <returns></returns>
        public ISerializer GetJsonSerializer()
        {
            return GetSerializer(SerializeType.Json);
        }

        /// <summary>
        /// 获取 Xml 序列化者。
        /// </summary>
        /// <returns></returns>
        public ISerializer GetXmlSerializer()
        {
            return GetSerializer(SerializeType.Xml);
        }

        #endregion
    }
}
