using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.Character_Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetDtoCharacter>>> GetAllCharacters();
        Task<ServiceResponse<GetDtoCharacter>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetDtoCharacter>>> AddCharacter(AddDtoCharacter newCharacter);

         Task<ServiceResponse<GetDtoCharacter>> UpdateCharacter(UpdateDtoCharacter updatedCharacter);

         Task<ServiceResponse<List<GetDtoCharacter>>> DeleteCharacter(int id);
         
    }
}