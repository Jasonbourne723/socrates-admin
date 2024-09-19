using System.ComponentModel;

namespace Models.Response
{
    public class ApplicationDto
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("名称")]
        public string name { get; set; }
        [DisplayName("AppKey")]
        public string app_key { get; set; }
        [DisplayName("Secret")]
        public string app_secret { get; set; }
        [DisplayName("描述")]
        public string description { get; set; }
        [DisplayName("登录回调地址")]
        public string callback_url { get; set; }
    }
}
