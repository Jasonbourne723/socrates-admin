namespace Extensions
{
    public interface ICustomHttpClient
    {
        Task<T> GetAndHandleBusinessErrorAsync<T>(string requestUri);
    }
}