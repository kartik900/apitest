using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.DBModels;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserAccountManagementController : ControllerBase
    {
        private readonly IUserAccountManagementRepo _userAccountManagementRepo;

        public UserAccountManagementController(IUserAccountManagementRepo userAccountManagementRepo)
        {
            _userAccountManagementRepo = userAccountManagementRepo;
        }

        [HttpPost(Name = "UserSignUp")]
        public async Task<SignUpResponse> UserSignUp(SignUpRequest signUpRequest)
        {
            var response = new SignUpResponse();
            try
            {
                response = await _userAccountManagementRepo.UserSignUp(signUpRequest);
            }
            catch (Exception ex)
            {
                response = new SignUpResponse() { Status = ex.Message};
            }
            return response;
        }

    }
}
