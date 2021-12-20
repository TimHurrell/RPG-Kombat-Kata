using System;
using System.Collections.Generic;

namespace CombatCharacterLibrary
{
    public abstract class CombatCharacter
    {
  
        public int health { get; private set; } = 1000;
        public int level { get; set; } = 1;
        public bool alive { get; set; } = true;

        public int[,] location = new int[1,2] { { 0, 0 }};


        public abstract int range { get; set; }



        public CombatCharacter CausesDamage(CombatCharacter victim, int amountOfDamage)
        {
            if (victim.alive && victim.GetHashCode() != GetHashCode())
            {
                decimal weighteddamage = amountOfDamage * DamageFactorMultiplier(victim.level);
                victim.health -= (int)weighteddamage;


                victim.health = victim.health < 0 ? victim.health = 0 : victim.health;

                victim.alive = victim.health == 0 ? victim.alive = false : victim.alive;
                
            }


            return victim;

        }


        public CombatCharacter Heals(CombatCharacter patient, int amountOfHealth)
        {
            if (patient.alive && patient.GetHashCode() == GetHashCode())
            {
                patient.health += amountOfHealth;
                patient.health = patient.health > 1000 ? patient.health = 1000 : patient.health;
            }
            return patient;
        }


        public decimal DamageFactorMultiplier(int levelVictim)
        {
            decimal damageFactor;
            if (level - levelVictim >= 5)
            {
                damageFactor = 1.5M;
            }
            else if (level - levelVictim <= -5)
            {
                damageFactor = 0.5M;
            }
            else
            {
                damageFactor = 1.0M;
            }
            return damageFactor;

        }

        public abstract bool InRange(int[,] locationVictim);
       

}
}
