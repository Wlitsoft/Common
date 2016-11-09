/**********************************************************************************************************************
 * 描述：
 *      字符串加密。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月07日	 新建
 *********************************************************************************************************************/
using System;
using System.Security.Cryptography;
using System.Text;

namespace Wlitsoft.Framework.Common.Security
{
    /// <summary>
    /// 文本加密。
    /// </summary>
    public class StringEncrypt
    {
        #region 私有属性

        //字符串。
        private readonly string _str;

        //字符串编码。
        private readonly Encoding _encoding;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="StringEncrypt"/> 类的新实例。
        /// </summary>
        /// <param name="str">要加密的字符串。</param>
        public StringEncrypt(string str)
            : this(str, Encoding.UTF8)
        {

        }

        /// <summary>
        /// 初始化 <see cref="StringEncrypt"/> 类的新实例。
        /// </summary>
        /// <param name="str">要加密的字符串。</param>
        /// <param name="encoding">字符串编码。</param>
        public StringEncrypt(string str, Encoding encoding)
        {
            this._str = str;
            this._encoding = encoding;
        }

        #endregion

        #region 获取32位大写 MD5 加密字符串

        /// <summary>
        /// 获取32位大写 MD5 加密字符串。
        /// </summary>
        /// <returns>加密字符串。</returns>
        public string GetMD5()
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(this._encoding.GetBytes(this._str));
                return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
            }
        }

        #endregion

        #region 获取大写 SHA1 加密字符串

        /// <summary>
        /// 获取大写 MD5 加密字符串。
        /// </summary>
        /// <returns>加密字符串。</returns>
        public string GetSHA1()
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] bytes = sha1.ComputeHash(this._encoding.GetBytes(this._str));
                return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
            }
        }

        #endregion

    }
}
