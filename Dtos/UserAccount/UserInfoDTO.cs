using System.Collections.Generic;

namespace learn_net_core.Dtos.UserAccount
{
    public class UserInfoDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Roles { get; set; }
    }
}