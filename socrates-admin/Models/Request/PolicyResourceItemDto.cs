namespace Models.Request
{
    public class PolicyResourceItemDto
    {
        public long resource_item_id { get; set; }

        public string resource_item_name { get; set; }

        public string resource_item_actions { get; set; }

        public List<PolicyResourceItemDto> items { get; set; }
    }
}
