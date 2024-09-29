using Models.Request;

namespace Services
{
    public interface IAuthService
    {
        Task GitHubLogin(string code);
        Task Login(LoginDto dto);
        Task Register(RegisterDto dto);
    }
}