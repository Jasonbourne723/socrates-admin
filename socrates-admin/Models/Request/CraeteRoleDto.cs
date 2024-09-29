namespace Models.Request
{
    public class CreateRoleDto
    {
        public string name { get; set; }

        public string code { get; set; }

        public long permission_space_id { get; set; }
    }

    public class GitHubLoginDto
    {
        public string code { get; set; }
    }
}
