using System.Collections.Generic;
using System.IO;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Net;
using Xunit;

namespace Common.Test.Net
{
    /// <summary>
    /// Http 请求客户端 测试。
    /// </summary>
    public class HttpReqeustClientTest
    {

        [Fact]
        public void HttpGetStringTest()
        {
            HttpReqeustClient client = new HttpReqeustClient();
            string result = client.HttpGetString("http://localhost:5000/api/apitest/get");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);

            string[] resultObj = result.ToJsonObject<string[]>();
            Assert.NotNull(resultObj);
            Assert.Equal<string>("value1", resultObj[0]);

        }

        [Fact]
        public void HttpGetStringHasParaTest()
        {
            HttpReqeustClient client = new HttpReqeustClient();
            string result = client.HttpGetString("http://localhost:5000/api/apitest/get/1");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
            Assert.Equal<string>("1", result);
        }

        [Fact]
        public void HttpPostTest()
        {
            const string url = "http://localhost:5000/api/apitest/post";
            HttpReqeustClient client = new HttpReqeustClient();

            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                {"p1", "v1"},
                {"p2", "v2"}
            };

            string result = client.HttpPost(url, postData);

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void HttpSetHeadersTest()
        {
            HttpReqeustClient client = new HttpReqeustClient();
            client.Headers.Add("User-Agent", "HttpReqeustClient");

            string result = client.HttpGetString("http://localhost:5000/api/apitest/GetHttpHeaders");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
            Assert.True(result.Contains("HttpReqeustClient"));
        }

        [Fact]
        public void FileUploadTest()
        {
            const string url = "http://localhost:5000/api/apitest/FileUpload";
            const string filePath = "Resources/TextFile1.txt";
            HttpReqeustClient client = new HttpReqeustClient();

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                HttpPostDataDictionary postData = new HttpPostDataDictionary();
                postData.AddFile("file", fileStream);

                string result = client.HttpPost(url, postData);
                Assert.NotNull(result);
                Assert.True(result.Length > 0);
            }
        }
    }
}
