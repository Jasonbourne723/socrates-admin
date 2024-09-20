namespace Models.Request
{
    public class CreateUserDto
    {
        public string name { get; set; }

        public string mobile { get; set; }

        public List<long> role_ids { get; set; }

        public long post_id { get; set; }

        public long organization_id { get; set; }

    }
}
