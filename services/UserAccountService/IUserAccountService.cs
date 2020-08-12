using System.Collections.Generic;
using System.Threading.Tasks;
using learn_net_core.Models;
using learn_net_core.Dtos.UserAccount;

namespace learn_net_core.services.UserAccountService
{
    public interface IUserAccountService
    {
        Task<ServiceResponse<List<UserAccount>>> GetAllUsers();
        Task<ServiceResponse<UserInfoDTO>> SignIn(LogInDto user);
        Task SignOut();
        Task<ServiceResponse<UserInfoDTO>> Register(RegisterDTO user);
        Task<ServiceResponse<UserInfoDTO>> GetUserDetails(string user);

    }
}