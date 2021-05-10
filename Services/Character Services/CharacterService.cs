using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using System;
using dotnet_rpg.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.Character_Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper, DataContext context)
        {
             _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDtoCharacter>>> AddCharacter(AddDtoCharacter newCharacter)
        {
            ServiceResponse<List<GetDtoCharacter>> serviceResponse = new ServiceResponse<List<GetDtoCharacter>>();

            Character character = (_mapper.Map<Character>(newCharacter));
           
             _context.Characters.Add(character);
             await _context.SaveChangesAsync();
            serviceResponse.Data = await (_context.Characters.Select(c => _mapper.Map<GetDtoCharacter>(c))).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDtoCharacter>>> GetAllCharacters()

        {
            ServiceResponse<List<GetDtoCharacter>> serviceResponse = new ServiceResponse<List<GetDtoCharacter>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = (dbCharacters.Select(c => _mapper.Map<GetDtoCharacter>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDtoCharacter>> GetCharacterById(int id)
        {
            ServiceResponse<GetDtoCharacter> serviceResponse = new ServiceResponse<GetDtoCharacter>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id==id);
            serviceResponse.Data = _mapper.Map<GetDtoCharacter>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDtoCharacter>> UpdateCharacter(UpdateDtoCharacter updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetDtoCharacter>();
            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                character.Name = updatedCharacter.Name;
                character.Strength = updatedCharacter.Strength;
                character.Intelligence = updatedCharacter.Intelligence;
                 character.Defence = updatedCharacter.Defence;
                character.Hitpoint = updatedCharacter.Hitpoint;
                character.Class = updatedCharacter.Class;
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetDtoCharacter>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;


        }

        public async Task<ServiceResponse<List<GetDtoCharacter>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetDtoCharacter>> serviceResponse = new ServiceResponse<List<GetDtoCharacter>>();
            try
            {
                Character character =await  _context.Characters.FirstAsync(c => c.Id == id);
                _context.Characters.Remove(character);
await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Characters.Select(c => _mapper.Map<GetDtoCharacter>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }


}
