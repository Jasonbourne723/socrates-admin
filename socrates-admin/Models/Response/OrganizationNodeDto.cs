namespace Models.Response
{
    public class OrganizationNodeDto
    {
        public long id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public List<OrganizationNodeDto> items { get; set; }
    }

}
