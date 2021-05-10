using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Services.Character_Services;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddDtoCharacter newCharacter)
        {
             return Ok(await _characterService.AddCharacter(newCharacter));
        }

  [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateDtoCharacter updatedCharacter)
        {
            var response =await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data==null){
                return NotFound(response);
            }
             return Ok(response);
        }
 [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
     
             return Ok(await _characterService.DeleteCharacter(id));
        }


    }
}