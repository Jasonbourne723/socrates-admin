namespace Models.Request
{
    public class CreateOrganizationDto
    {
        public string name { get; set; }

        public string code { get; set; }

        public long parent_id { get; set; } = 0;
    }
}
