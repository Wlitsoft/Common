/**********************************************************************************************************************
 * 描述：
 *      Http 请求客户端。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月06日	 新建
 * 
 *********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extensions;

namespace Wlitsoft.Framework.Common.Net
{
    /// <summary>
    /// Http 请求客户端。
    /// </summary>
    public class HttpReqeustClient
    {
        #region 公共属性

        /// <summary>
        /// 获取当前请求使用的 <see cref="HttpClient"/> 实例。
        /// </summary>
        public HttpClient HttpClient { get; private set; }

        /// <summary>
        /// 获取包含状态码和数据的 HTTP 相应消息。
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; private set; }

        /// <summary>
        /// 获取或设置Http请求头。
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="HttpReqeustClient"/> 类的新实例。
        /// </summary>
        public HttpReqeustClient()
        {
            this.Headers = new Dictionary<string, string>();
        }

        #endregion

        #region 根据 <paramref name="url"/> 发送 GET 请求获取响应的文本

        /// <summary>
        /// 根据 <paramref name="url"/> 发送 GET 请求获取响应的文本。
        /// </summary>
        /// <param name="url">要请求的 url 地址。</param>
        /// <returns>服务器响应的文本。</returns>
        public string HttpGet(string url)
        {
            this.HttpSend(url, HttpMethod.Get, null);
            return this.HttpResponseMessage.GetResultString();
        }

        #endregion

        #region 根据 <paramref name="url"/> 发送 POST 请求获取响应的文本

        /// <summary>
        /// 根据 <paramref name="url"/> 发送 POST 请求获取响应的文本。
        /// </summary>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="postData">要发送的数据。</param>
        /// <returns>服务器响应的文本。</returns>
        public string HttpPost(string url, Dictionary<string, string> postData)
        {
            #region 参数校验

            if (postData == null)
                throw new ObjectNullException(nameof(postData));

            #endregion

            HttpPostDataDictionary dic = new HttpPostDataDictionary();
            foreach (var item in postData)
                dic.AddText(item.Key, item.Value);
            return this.HttpPost(url, dic);
        }

        /// <summary>
        /// 根据 <paramref name="url"/> 发送 POST 请求获取响应的文本。
        /// </summary>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="postData">要发送的数据。</param>
        /// <returns>服务器响应的文本。</returns>
        public string HttpPost(string url, HttpPostDataDictionary postData)
        {
            string boundary = string.Format("----{0}", DateTime.Now.Ticks.ToString("x"));
            MultipartFormDataContent formDataContent = new MultipartFormDataContent(boundary);
            foreach (var item in postData)
            {
                object value = item.Value.Value;
                switch (item.Value.Key)
                {
                    case HttpPostDataType.Text:
                        formDataContent.Add(new StringContent(value.ToString()), item.Key);
                        break;
                    case HttpPostDataType.FilePath:
                        throw new System.NotImplementedException();
                    case HttpPostDataType.FileStream:
                        FileStream fileStream = (FileStream)value;
                        formDataContent.Add(new StreamContent(fileStream), item.Key, Path.GetFileName(fileStream.Name));
                        break;
                }
            }

            this.HttpPost(url, formDataContent);
            return this.HttpResponseMessage.GetResultString();
        }

        /// <summary>
        /// 根据 <paramref name="url"/> 发送 POST 请求获取响应的文本。
        /// </summary>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="httpContent">HTTP 实体正文对象。</param>
        /// <returns>服务器响应的文本。</returns>
        public string HttpPost(string url, HttpContent httpContent)
        {
            this.HttpSend(url, HttpMethod.Post, httpContent);
            return this.HttpResponseMessage.GetResultString();
        }

        #endregion

        #region 私有方法

        #region 根据 <paramref name="url"/> 和 <paramref name="httpMethod"/> 发送请求获取响应的文本

        /// <summary>
        /// 根据 <paramref name="url"/> 和 <paramref name="httpMethod"/> 发送请求获取响应的文本。
        /// </summary>
        /// <param name="url">要请求的 url 地址。</param>
        /// <param name="httpMethod">请求的方式。</param>
        /// <param name="httpContent">HTTP 实体正文对象。</param>
        private void HttpSend(string url, HttpMethod httpMethod, HttpContent httpContent)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(url))
                throw new StringNullOrEmptyException(nameof(url));

            #endregion

            this.HttpClient = this.CreateHttpClient();

            if (httpMethod == HttpMethod.Get)
                this.HttpResponseMessage = this.HttpClient.GetAsync(url).Result;
            if (httpMethod == HttpMethod.Post)
                this.HttpResponseMessage = this.HttpClient.PostAsync(url, httpContent).Result;
        }

        #endregion

        #endregion

        #region 创建 HttpClient

        /// <summary>
        /// 创建 <see cref="HttpClient"/> 对象。
        /// </summary>
        /// <returns>初始化完后的 <see cref="HttpClient"/> 对象。</returns>
        private HttpClient CreateHttpClient(HttpMessageHandler handler = null)
        {
            HttpClient client = handler == null ? new HttpClient() : new HttpClient(handler);

            #region Http头

            if (this.Headers.Any())
            {
                foreach (var item in this.Headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            #endregion

            return client;
        }

        #endregion
    }
}
