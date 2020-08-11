using Microsoft.AspNetCore.Identity;

namespace learn_net_core.Models
{
    public class UserAccount : IdentityUser
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}