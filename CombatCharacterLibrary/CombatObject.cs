using System;
using System.Collections.Generic;




namespace CombatObjectLibrary 
{


    public abstract class ICombatObject
    {
        public ICombatObject() { }
        public ICombatObject(int health, int level, bool alive)
        {
            Health = health;
            Level = level;
            Alive = alive;
        }

        public int Health { get; set; } = 1000;
        public int Level { get; set; } = 1;
        public bool Alive { get; set; } = true;
       





    }
}
