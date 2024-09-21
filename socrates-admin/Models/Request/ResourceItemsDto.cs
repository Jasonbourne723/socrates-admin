namespace Models.Request
{
    public class ResourceItemsDto
    {
        public long id { get; set; }
        public string name { get; set; }

        public string code { get; set; }

        public string description { get; set; }

        public string value { get; set; }

        public List<ResourceItemsDto> Items { get; set; }
    }


}
