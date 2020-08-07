using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn_net_core.Models;
using learn_net_core.Dtos.Character;
using AutoMapper;
using System;

namespace learn_net_core.services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character{Id=1,Name="same"}
        };
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            Character charac = _mapper.Map<Character>(character);
            charac.Id = characters.Max(c => c.Id) + 1;
            characters.Add(charac);
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character ch = characters.FirstOrDefault(c => c.Id == id);
                characters.Remove(ch);
                response.Data = (characters.Select(x => _mapper.Map<GetCharacterDto>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Message = "Error " + ex;
                response.success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(x => x.Id == id));
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character oldCharacter = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                oldCharacter.Name = updatedCharacter.Name;
                oldCharacter.Strength = updatedCharacter.Strength;
                oldCharacter.Defense = updatedCharacter.Defense;
                oldCharacter.Class = updatedCharacter.Class;
                oldCharacter.Intelligence = updatedCharacter.Intelligence;
                oldCharacter.HitPoints = updatedCharacter.HitPoints;

                response.Data = _mapper.Map<GetCharacterDto>(oldCharacter);
            }
            catch (Exception ex)
            {
                response.Message = "Error :" + ex;
                response.success = false;
            }
            return response;

        }
    }
}