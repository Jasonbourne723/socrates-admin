using Models.Request;
using System.ComponentModel;

namespace Models.Response
{
    public class PolicyDto
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("名称")]
        public string name { get; set; }
        [DisplayName("描述")]
        public string description { get; set; }
        [DisplayName("资源")]
        public List<PolicyResourceDto> resources { get; set; } = new List<PolicyResourceDto>();
    }
}
