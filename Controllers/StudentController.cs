using System.Threading.Tasks;
using learn_net_core.services.StudentService;
using Microsoft.AspNetCore.Mvc;
using learn_net_core.Dtos.Student;
using learn_net_core.Models;
using Microsoft.AspNetCore.Authorization;

namespace learn_net_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _students;
        public StudentController(IStudentService students)
        {
            _students = students;

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _students.GetAllStudents());
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto newStudent)
        {
            ServiceResponse<StudentDto> response = await _students.AddStudent(newStudent);
            if (response.Data != null)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}