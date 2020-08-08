using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_net_core.Models
{
    public abstract class Person
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}