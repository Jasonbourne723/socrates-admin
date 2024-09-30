using System.Text.Json.Serialization;

namespace Models.Request
{
    public class PolicyResourceDto
    {
        [JsonIgnore]
        public int index { get; set; }

        public long permission_space_id { get; set; }

        public long resource_id { get; set; }

        public short effect { get; set; }

        public List<PolicyResourceItemDto> items { get; set; }

    }
}
