using System;

namespace CombatCharacterLibrary
{
    public class CombatCharacter
    {
        public int health { get; private set; } = 1000;
        public int level { get; set; } = 1;
        public bool alive { get; set; } = true;

        public CombatCharacter CausesDamage(CombatCharacter victim, int amountOfDamage)
        {
            if (victim.alive == true)
            {

                victim.health -= amountOfDamage;
                if (victim.health < 0)
                {
                    victim.health = 0;
                }
                if (victim.health == 0)
                {
                    victim.alive = false;
                }
            }


            return victim;

        }
    }
}
