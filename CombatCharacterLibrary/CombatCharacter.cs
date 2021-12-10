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
               
                victim.health = victim.health < 0 ? victim.health = 0 : victim.health;

                victim.alive = MakeDead(victim.health);
                
            }


            return victim;

        }


        public bool MakeDead(int healthvalue)
        {
            bool alive;
            alive = true;
            alive = healthvalue == 0 ? alive = false : alive;
            return alive;
        }


        public CombatCharacter EnhancesHealth(CombatCharacter patient, int amountOfHealth)
        {
            if (patient.alive == true)
            {
                patient.health += amountOfHealth;
                patient.health = patient.health > 1000 ? patient.health = 1000 : patient.health;
            }
            return patient;
        }
    }
}
