using System.ComponentModel;

namespace Models.Response
{
    public class PermissionSpaceDto
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("名称")]
        public string name { get; set; }
        [DisplayName("编号")]
        public string code { get; set; }

        [DisplayName("描述")]
        public string description { get; set; }
    }

}
