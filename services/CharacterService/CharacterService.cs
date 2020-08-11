using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn_net_core.Models;
using learn_net_core.Dtos.Character;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;

namespace learn_net_core.services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly CharacterContext _db;
        public CharacterService(IMapper mapper, CharacterContext db)
        {
            _mapper = mapper;
            _db = db;

        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            Character charac = _mapper.Map<Character>(character);
            _db.characters.Add(charac);
            await _db.SaveChangesAsync();
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = (_db.characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(Guid id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character ch = _db.characters.FirstOrDefault(c => c.Id == id);
                _db.characters.Remove(ch);
                await _db.SaveChangesAsync();
                response.Data = (_db.characters.Select(x => _mapper.Map<GetCharacterDto>(x))).ToList();
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
            response.Data = await (_db.characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(Guid id)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = _mapper.Map<GetCharacterDto>(await _db.characters.FindAsync(id));
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character oldCharacter = await _db.characters.FindAsync(updatedCharacter.Id);
                oldCharacter.Name = updatedCharacter.Name;
                oldCharacter.Strength = updatedCharacter.Strength;
                oldCharacter.Defense = updatedCharacter.Defense;
                oldCharacter.Class = updatedCharacter.Class;
                oldCharacter.Intelligence = updatedCharacter.Intelligence;
                oldCharacter.HitPoints = updatedCharacter.HitPoints;

                _db.Entry(oldCharacter).State = EntityState.Modified;
                await _db.SaveChangesAsync();
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