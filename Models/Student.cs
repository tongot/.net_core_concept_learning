using System.Collections.Generic;

namespace learn_net_core.Models
{
    public class Student : Person
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public ICollection<Strength> strengths { get; set; }

    }
}