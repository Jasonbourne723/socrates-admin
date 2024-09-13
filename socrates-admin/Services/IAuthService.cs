using Models.Request;

namespace Services
{
    public interface IAuthService
    {
        Task Login(LoginDto dto);
        Task Register(RegisterDto dto);
    }
}