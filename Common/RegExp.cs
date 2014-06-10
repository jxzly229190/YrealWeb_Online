namespace Common
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// 正则处理类
    /// </summary>
    public class RegExp
    {
        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsNum(string text)
        {
            return Regex.IsMatch(text, @"^[\d]+$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 校验密码字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsPassword(string text)
        {
            return Regex.IsMatch(text, @"^\w{6,16}$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为汉字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsChinese(string text)
        {
            return Regex.IsMatch(text, @"^[\u4E00-\u9FA5]+$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 汉字，字母，数字和下划线
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns></returns>
        public static bool IsUserName(string text)
        {
            return Regex.IsMatch(text,@"^[\w\u4E00-\u9FA5]{4,30}$",RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为邮编号码
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsZipCode(string text)
        {
            return Regex.IsMatch(text, @"^\d{6}$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为身份证号码
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsID(string text)
        {
            return Regex.IsMatch(text, @"^(\d{17}[\d|X]|\d{15})$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为电话号码
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsPhone(string text)
        {
            return Regex.IsMatch(text, @"^(((\(\d{3,4}\))|(\d{3,4}-))?[1-9]\d{6,7}(-\d{0,4})?)?$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为手机号码
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsMobile(string text)
        {
            return Regex.IsMatch(text, @"^[1]+[3,4,5,8]+\d{9}$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为邮箱地址
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsEmail(string text)
        {
            return Regex.IsMatch(text, @"^([\w\.\-]+@[\w\.\-]+\.[\w\.\-]+)$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为数字和逗号
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsNumAndComma(string text)
        {
            return Regex.IsMatch(text, @"^[\d,]+$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为汉字|字母
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsChineseAndLetters(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z\u4E00-\u9FA5]+$", RegexOptions.ExplicitCapture);
        }
        /// <summary>
        /// 是否为汉字|字母|数字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsChineseAndChar(string text)
        {
            return Regex.IsMatch(text, @"^[-\w\u4E00-\u9FA5]+$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 是否为IP地址
        /// </summary>
        /// <param name="text">文本</param>
        public static bool isIpAddress(string text)
        {
            return Regex.IsMatch(text, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
            //return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$", RegexOptions.ExplicitCapture);
        }

        /// <summary>
        /// 检测文本是否包含SQL注入
        /// </summary>
        /// <param name="text">文本</param>
        public static bool IsSave(string text)
        {
            string regex = @"insert |delete |count\(|asc\(|mid\(|char\(|exec master|net user|net localgroup administrators|or |and |update |drop table|truncate |xp_cmdshell|create |alert | script|'";
            Regex check = new Regex(regex, RegexOptions.IgnoreCase);
            Match match = check.Match(text);

            if (match.Success) return false;
            return true;
        }
    }

}