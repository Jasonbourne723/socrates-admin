namespace Models.Response
{
    public class OrganizationDto
    {
        public long id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public long parent_id { get; set; }
    }

}
