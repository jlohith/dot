using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using System;

namespace dotnet_rpg.Services.Character_Services
{
    public class CharacterService : ICharacterService
    {

       private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper=mapper;
        }
         private static List<Character> characters =new List<Character>{
           new Character(),
           new Character{Id=1,Name="Sam"}
        };
        public async Task<ServiceResponse<List<GetDtoCharacter>>> AddCharacter(AddDtoCharacter newCharacter)
        {
            ServiceResponse<List<GetDtoCharacter>> serviceResponse=new ServiceResponse<List<GetDtoCharacter>>();

            Character character=   (_mapper.Map<Character>(newCharacter));
            character.Id = characters.Max(c => c.Id)+1;
            characters.Add(character);
             serviceResponse.Data=(characters.Select(c=>_mapper.Map<GetDtoCharacter>(c))).ToList();
             return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDtoCharacter>>> GetAllCharacters()
        
        {
            ServiceResponse<List<GetDtoCharacter>> serviceResponse=new ServiceResponse<List<GetDtoCharacter>>();
            serviceResponse.Data= (characters.Select(c=>_mapper.Map<GetDtoCharacter>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDtoCharacter>> GetCharacterById(int id)
        {
             ServiceResponse<GetDtoCharacter> serviceResponse=new ServiceResponse<GetDtoCharacter>();
             serviceResponse.Data = _mapper.Map<GetDtoCharacter>(characters.FirstOrDefault(c => c.Id==id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDtoCharacter>> UpdateCharacter(UpdateDtoCharacter updatedCharacter)
        {
           ServiceResponse<GetDtoCharacter> serviceResponse = new ServiceResponse<GetDtoCharacter>();
           try{
           Character character = characters.FirstOrDefault(c => c.Id==updatedCharacter.Id);
           character.Name=updatedCharacter.Name;
           character.Strength=updatedCharacter.Strength;
           character.Intelligence=updatedCharacter.Intelligence;
           character.Hitpoint=updatedCharacter.Hitpoint;
           character.Class=updatedCharacter.Class;

           serviceResponse.Data = _mapper.Map<GetDtoCharacter>(character);
           }
           catch(Exception ex){
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
           }
           return serviceResponse;
       

        }

        public async Task<ServiceResponse<List<GetDtoCharacter>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetDtoCharacter>> serviceResponse = new ServiceResponse<List<GetDtoCharacter>>();
           try{
           Character character= characters.First(c => c.Id == id);
           characters.Remove(character);
          

           serviceResponse.Data = (characters.Select(c=>_mapper.Map<GetDtoCharacter>(c))).ToList();
           }
           catch(Exception ex){
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
           }
           return serviceResponse;
        }
    }

    
}
