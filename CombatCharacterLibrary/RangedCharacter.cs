
using System;
namespace CombatCharacterLibrary
{

    public class RangedCharacter : CombatCharacter
    {


        public override int range { get; set; } = 20;

        public override bool InRange(int[,] locationVictim)
        {
            var distance = Math.Sqrt((Math.Pow(locationVictim[0, 0] - location[0, 0], 2) + Math.Pow(locationVictim[0, 1] - location[0, 1], 2)));
            return (int)distance <= range;
        }

    }
}