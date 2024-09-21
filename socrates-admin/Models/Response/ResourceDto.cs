using Models.Request;
using System.ComponentModel;

namespace Models.Response
{
    public class ResourceDto
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("名称")]
        public string name { get; set; }

        [DisplayName("编号")]
        public string code { get; set; }
        [DisplayName("描述")]
        public string description { get; set; }
        [DisplayName("权限空间")]
        public long permission_space_id { get; set; }
        [DisplayName("类别")]
        public short category { get; set; }
        public List<ResourceItemsDto> Items { get; set; }

        public List<string> actions { get; set; }
    }
}
