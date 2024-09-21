namespace Models.Request
{
    public class CreateResourceDto
    {
        public string name { get; set; }

        public string code { get; set; }

        public string description { get; set; }

        public long permission_space_id { get; set; }

        public short category { get; set; }

        public List<ResourceItemsDto> items { get; set; }

        public List<string> actions { get; set; }
    }


}
