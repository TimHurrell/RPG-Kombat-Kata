using System;
using System.Collections.Generic;

public enum CombatType
{
    Melee,
    Range
}

namespace CombatCharacterLibrary
{
    public class CombatCharacter
    {
        public CombatCharacter() { }
        public CombatCharacter(int health, int level, bool alive)
        {
            Health = health;
            Level = level;
            Alive = alive;
        }

        public int Health { get; private set; } = 1000;
        public int Level { get; private set; } = 1;
        public bool Alive { get; private set; } = true;
        public CombatType CType { get; set; }


        //public int[,] Location = new int[1,2] { { 0, 0 }};


        //public abstract int range { get; set; }



        public CombatCharacter CausesDamage(CombatCharacter victim, int amountOfDamage)
        {
            if (victim.Alive && victim != this)
            {
                decimal weighteddamage = amountOfDamage * DamageFactorMultiplier(victim.Level);
                victim.Health -= (int)weighteddamage;


                victim.Health = victim.Health < 0 ? victim.Health = 0 : victim.Health;

                victim.Alive = victim.Health == 0 ? victim.Alive = false : victim.Alive;
                
            }


            return victim;

        }


        public CombatCharacter Heals(CombatCharacter patient, int amountOfHealth)
        {
            if (patient.Alive && patient == this)
            {
                patient.Health += amountOfHealth;
                patient.Health = patient.Health > 1000 ? patient.Health = 1000 : patient.Health;
            }
            return patient;
        }


        public decimal DamageFactorMultiplier(int LevelVictim)
        {
            decimal damageFactor;
            if (Level - LevelVictim >= 5)
            {
                damageFactor = 1.5M;
            }
            else if (Level - LevelVictim <= -5)
            {
                damageFactor = 0.5M;
            }
            else
            {
                damageFactor = 1.0M;
            }
            return damageFactor;

        }

        //public abstract bool InRange(int[,] locationVictim);
       

}
}
