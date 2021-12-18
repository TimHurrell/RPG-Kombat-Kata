using System;

namespace CombatCharacterLibrary
{
    public class CombatCharacter
    {
  
        public float health { get; private set; } = 1000;
        public int level { get; set; } = 1;
        public bool alive { get; set; } = true;


        public CombatCharacter CausesDamage(CombatCharacter victim, float amountOfDamage)
        {
            if (victim.alive & victim.GetHashCode() != GetHashCode())
            {

                victim.health -= amountOfDamage * DamageFactorMultiplier(victim.level);
               
                victim.health = victim.health < 0 ? victim.health = 0 : victim.health;

                victim.alive = victim.health == 0 ? victim.alive = false : victim.alive;
                
            }


            return victim;

        }


        public CombatCharacter EnhancesHealth(CombatCharacter patient, int amountOfHealth)
        {
            if (patient.alive & patient.GetHashCode() == GetHashCode())
            {
                patient.health += amountOfHealth;
                patient.health = patient.health > 1000 ? patient.health = 1000 : patient.health;
            }
            return patient;
        }


        public float DamageFactorMultiplier(int levelVictim)
        {
            float damageFactor;
            if (level - levelVictim >= 5)
            {
                damageFactor = 1.5F;
            }
            else if (level - levelVictim <= -5)
            {
                damageFactor = 0.5F;
            }
            else
            {
                damageFactor = 1.0F;
            }
            return damageFactor;

        }
    }
}
