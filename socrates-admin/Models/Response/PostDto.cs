using System.ComponentModel;

namespace Models.Response
{
    public class PostDto
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("名称")]
        public string name { get; set; }
        [DisplayName("编号")]
        public string code { get; set; }
        [DisplayName("关联部门")]
        public List<long> organization_ids { get; set; }
    }
}
