namespace Models.Request
{
    public class CraeteRoleDto
    {
        public string name { get; set; }

        public string code { get; set; }

        public long permission_space_id { get; set; }
    }
}
