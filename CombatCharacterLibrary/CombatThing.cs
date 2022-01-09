using System;
using System.Collections.Generic;


public enum FactionN
{
    Neutral
}



namespace CombatObjectLibrary
{


    public class Thing : ICombatObject
    {
        public Thing(int health)
        {
            Health = health;
        }




        public override void IsDamaged(Character attacker, int amountOfDamage, int distance = 0)
        {
            if (Alive && attacker.Alive && InRange(attacker, distance))

            {

                Health -= amountOfDamage;


                Health = Health < 0 ? Health = 0 : Health;

                Alive = Health == 0 ? Alive = false : Alive;

            }

        }


    }
}
