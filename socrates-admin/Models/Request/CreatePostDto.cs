namespace Models.Request
{
    public class CreatePostDto
    {
        public string name { get; set; }

        public string code { get; set; }

        public List<long> organization_ids { get; set; }
    }
}
