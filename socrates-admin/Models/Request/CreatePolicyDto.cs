namespace Models.Request
{
    public class CreatePolicyDto
    {
        public string name { get; set; }

        public string description { get; set; }

        public List<PolicyResourceDto> resources { get; set; }


    }
}
