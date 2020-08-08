using System;
using System.Collections.Generic;

namespace learn_net_core.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string DateOfBirth { get; set; }
        public List<StrengthDto> strengths { get; set; }
    }
}