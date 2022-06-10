using WebApplication1.DBModels;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IUserAccountManagementRepo
    {
        Task<SignUpResponse> UserSignUp(SignUpRequest signUpRequest);
    }
}
