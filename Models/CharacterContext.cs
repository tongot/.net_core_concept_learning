using Microsoft.EntityFrameworkCore;

namespace learn_net_core.Models
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {

        }

        public DbSet<Character> characters { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Strength> strengths { get; set; }
    }
}