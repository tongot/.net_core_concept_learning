using AutoMapper;
using learn_net_core.Dtos.Character;
using learn_net_core.Models;

namespace learn_net_core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}