namespace Models.Response
{
    public class Result<T>
    {
        public int error_code { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }

}
