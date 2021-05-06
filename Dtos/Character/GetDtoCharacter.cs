using dotnet_rpg.Models;

namespace dotnet_rpg.Dtos.Character
{
    public class GetDtoCharacter
    {
         public int Id{get;set;}
        public string Name{get;set;}="Frodo";
        public int Hitpoint{get;set;}=100;
        public int Strength{get;set;}=10;
        public int Defence{get;set;}=10;
        public int Intelligence{get;set;}=10;

        public RPGClass Class{get;set;}=RPGClass.Knight;
    }
}