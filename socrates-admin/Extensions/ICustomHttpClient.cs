namespace Extensions
{
    public interface ICustomHttpClient
    {
        Task DeleteAndHandleBusinessErrorAsync(string requestUri);
        Task<T> GetAndHandleBusinessErrorAsync<T>(string requestUri);
        Task<TResult> PostAndHandleBusinessErrorAsync<TRequst, TResult>(string requestUri, TRequst requst);
        Task PostAndHandleBusinessErrorAsync<TRequst>(string requestUri, TRequst requst);
        Task<TResult> PutAndHandleBusinessErrorAsync<TRequst, TResult>(string requestUri, TRequst requst);
        Task PutAndHandleBusinessErrorAsync<TRequst>(string requestUri, TRequst requst);
    }
}