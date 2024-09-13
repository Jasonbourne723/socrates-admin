using System.ComponentModel;

namespace Models.Response
{
    public class RoleDto
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("名称")]
        public string name { get; set; }
        [DisplayName("编号")]
        public string code { get; set; }

        public int permission_space_id { get; set; }
    }

}
