namespace Models.Response
{
    public class ApplicationDto
    {
        public long id { get; set; }

        public string name { get; set; }

        public string app_key { get; set; }

        public string app_secret { get; set; }

        public string description { get; set; }

        public string callback_url { get; set; }
    }
}
