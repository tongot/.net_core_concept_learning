using System.Linq;
using AutoMapper;
using learn_net_core.Dtos.Character;
using learn_net_core.Dtos.Student;
using learn_net_core.Models;
using learn_net_core.services.StudentService;

namespace learn_net_core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Student, StudentDto>()
            //.ForMember(d => d.strengths, opt => opt.MapFrom(source => (source.strengths)))
            .ForMember(d => d.DateOfBirth, opt =>
            opt.MapFrom(src => src.DateOfBirth.ToString("dd/MM/yyy"))); ;
            CreateMap<StudentDto, Student>();
            CreateMap<StrengthDto, Strength>();
            CreateMap<Strength, StrengthDto>();
        }
    }
}