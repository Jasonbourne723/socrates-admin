using System.ComponentModel;

namespace Models.Response
{
    public class UserDto
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("姓名")]
        public string name { get; set; }
        [DisplayName("手机号")]

        public string mobile { get; set; }
        [DisplayName("角色")]

        public List<long> role_ids { get; set; }
        [DisplayName("职位")]

        public long post_id { get; set; }
        [DisplayName("部门")]

        public long organization_id { get; set; }
    }
}
