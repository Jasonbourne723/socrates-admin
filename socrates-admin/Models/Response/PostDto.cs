namespace Models.Response
{
    public class PostDto
    {
        public long id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public List<long> organization_ids { get; set; }
    }
}
