using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Linq;
namespace dotnet_rpg.Services.Character_Services
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);

        List<Character> AddCharacter(Character newCharacter);
         
    }
}