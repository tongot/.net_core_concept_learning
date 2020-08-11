using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using learn_net_core.Dtos.UserAccount;
using learn_net_core.Models;
using Microsoft.AspNetCore.Identity;

namespace learn_net_core.services.UserAccountService
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly IMapper _map;

        public UserAccountService(UserManager<UserAccount> userManager, IMapper map)
        {
            _userManager = userManager;
            _map = map;
        }
        public Task<ServiceResponse<List<UserAccount>>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<UserInfoDTO>> GetUserDetails(string user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<UserInfoDTO>> Register(RegisterDTO newUser)
        {
            ServiceResponse<UserInfoDTO> response = new ServiceResponse<UserInfoDTO>();
            if (newUser.Password != newUser.PasswordConfirm)
            {
                response.success = false;
                response.Message = "Password did not match";
                return response;
            }
            UserAccount user = _map.Map<UserAccount>(newUser);
            user.UserName = newUser.Email;
            var createdUser = await _userManager.CreateAsync(user, newUser.Password);
            if (createdUser.Succeeded)
            {
                response.Data = _map.Map<UserInfoDTO>(await _userManager.FindByEmailAsync(newUser.Email));
                return response;
            }
            response.success = false;
            string errors = "";
            foreach (var error in createdUser.Errors)
            {
                errors += $"{error.Description},";
            }
            response.Message = errors;
            return response;

        }

        public Task<bool> SignIn(LogInDto user)
        {
            throw new System.NotImplementedException();
        }
    }
}