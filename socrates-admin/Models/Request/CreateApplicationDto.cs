namespace Models.Request
{
    public class CreateApplicationDto
    {
        public string name { get; set; }

        public string description { get; set; }

        public string callback_url { get; set; }
    }
}
