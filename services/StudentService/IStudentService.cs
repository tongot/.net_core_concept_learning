using System.Collections.Generic;
using System.Threading.Tasks;
using learn_net_core.Dtos.Student;
using learn_net_core.Models;

namespace learn_net_core.services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<StudentDto>>> GetAllStudents();
        Task<ServiceResponse<StudentDto>> AddStudent(StudentDto newStudent);
        List<StudentDto> GetStrength(ICollection<Strength> strength);

    }
}