

using System.Collections.Generic;
using System;

public enum CombatType
{
    Melee,
    Range
}

public enum FactionType
{
    Freemason,
    OpusDei,
    Illuminati,
    TheRobins
}



namespace CombatObjectLibrary
{


    public class Character : ICombatObject
    {
        public Character() { }
        public Character(int health, int level, bool alive)
        {
            Health = health;
            Level = level;
            Alive = alive;
        }

        public int Level { get; set; } = 1;

        public CombatType CType { get; set; }


        public FactionType FType { get; set; }

        public HashSet<Enum> Faction { get; private set; } = new HashSet<Enum>();




        public override void IsDamaged(Character attacker, int amountOfDamage,int distance = 0)
        {
            if (Alive && attacker.Alive && attacker != this && InRange(attacker,distance) && ! Faction.Overlaps(attacker.Faction))
               
            {


                decimal weighteddamage = amountOfDamage * DamageFactorMultiplier(attacker.Level);

                Health -= (int)weighteddamage;


                Health = Health < 0 ? Health = 0 : Health;

                Alive = Health == 0 ? Alive = false : Alive;
                
            }


        }



        public Character Heals(Character patient, int amountOfHealth)
        {
            if (Alive && patient.Alive && (patient == this || Faction.Overlaps(patient.Faction)))
            {
                patient.Health += amountOfHealth;
                patient.Health = patient.Health > 1000 ? patient.Health = 1000 : patient.Health;
            }
            return patient;
        }


        public decimal DamageFactorMultiplier(int LevelAttacker)
        {
            decimal damageFactor;
            if (LevelAttacker -  Level >= 5)
            {
                damageFactor = 1.5M;
            }
            else if (LevelAttacker - Level <= -5)
            {
                damageFactor = 0.5M;
            }
            else
            {
                damageFactor = 1.0M;
            }
            return damageFactor;

        }




        public void join(FactionType faction)
        {
            //Faction.Add(faction.ToString());
            Faction.Add(faction);
        }



        public void leave(FactionType faction)
        {
            //Faction.Remove(faction.ToString());
            Faction.Remove(faction);
        }


    }
}
