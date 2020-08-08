using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using learn_net_core.Dtos.Student;
using learn_net_core.Models;
using Microsoft.EntityFrameworkCore;

namespace learn_net_core.services.StudentService
{

    public class StudentService : IStudentService
    {
        private readonly CharacterContext _db;
        private readonly IMapper _map;

        public StudentService(CharacterContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }
        public async Task<ServiceResponse<StudentDto>> AddStudent(StudentDto newStudent)
        {
            ServiceResponse<StudentDto> response = new ServiceResponse<StudentDto>();
            try
            {
                _db.students.Add(_map.Map<Student>(newStudent));
                await _db.SaveChangesAsync();
                response.Data = newStudent;
            }
            catch (System.Exception ex)
            {
                response.success = false;
                response.Message = "Error " + ex;
            }
            return response;
        }

        public async Task<ServiceResponse<List<StudentDto>>> GetAllStudents()
        {
            ServiceResponse<List<StudentDto>> response = new ServiceResponse<List<StudentDto>>();
            response.Data = (_db.students.Include(x => x.strengths).Select(s => _map.Map<Student, StudentDto>(s))).ToList();
            return response;
        }
        public List<StudentDto> GetStrength(ICollection<Strength> strength)
        {
            return (strength.Select(x => _map.Map<StudentDto>(x))).ToList();
        }
    }
}