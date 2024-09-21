namespace Models.Request
{
    public class UpdateResourceDto
    {
        public string name { get; set; }

        public string code { get; set; }

        public string description { get; set; }

        public long permission_space_id { get; set; }

        public List<ResourceItemsDto> Items { get; set; }

        public List<string> actions { get; set; }
    }


}
