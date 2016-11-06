/**********************************************************************************************************************
 * 描述：
 *      Http 提交数据字典。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月06日	 新建
 * 
 *********************************************************************************************************************/
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common.Net
{
    /// <summary>
    /// Http 提交数据字典。
    /// </summary>
    public class HttpPostDataDictionary : Dictionary<string, KeyValuePair<HttpPostDataType,object>>
    {

        /// <summary>
        /// 添加文本数据。
        /// </summary>
        /// <param name="name">HTTP 内容的名称。</param>
        /// <param name="value">文本值。</param>
        public void AddText(string name, string value)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            if (string.IsNullOrEmpty(value))
                throw new StringNullOrEmptyException(nameof(value));

            #endregion

            this.Add(name, new KeyValuePair<HttpPostDataType, object>(HttpPostDataType.Text, value));
        }

        /// <summary>
        /// 添加文件数据。
        /// </summary>
        /// <param name="name">HTTP 内容的名称。</param>
        /// <param name="filePath">文件路径。</param>
        public void AddFile(string name, string filePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            if (string.IsNullOrEmpty(filePath))
                throw new StringNullOrEmptyException(nameof(filePath));

            #endregion

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加文件流。
        /// </summary>
        /// <param name="name">HTTP 内容的名称。</param>
        /// <param name="fileStream">文件流。</param>
        public void AddFile(string name, FileStream fileStream)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            if (fileStream == null)
                throw new ObjectNullException(nameof(fileStream));

            #endregion

            this.Add(name, new KeyValuePair<HttpPostDataType, object>(HttpPostDataType.FileStream, fileStream));
        }
    }
}
