using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace learn_net_core.Models
{
    public class CharacterContext : IdentityDbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {

        }
        public DbSet<Character> characters { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Strength> strengths { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }

    }
}