using System.Threading.Tasks;
using learn_net_core.Dtos.UserAccount;
using learn_net_core.Models;
using learn_net_core.services.UserAccountService;
using Microsoft.AspNetCore.Mvc;

namespace learn_net_core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _user;
        public UserAccountController(IUserAccountService user)
        {
            _user = user;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO newUser)
        {
            ServiceResponse<UserInfoDTO> response = await _user.Register(newUser);
            if (response.Data != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}