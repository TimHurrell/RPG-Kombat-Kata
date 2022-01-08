using System;
using System.Collections.Generic;




namespace CombatObjectLibrary 
{


    public abstract class ICombatObject
    {
        public ICombatObject() { }
       

        public int Health { get; set; } = 1000;
        public bool Alive { get; set; } = true;

        public FactionType FType { get; set; }

        public HashSet<Enum> Faction { get; private set; } = new HashSet<Enum>();






    }
}
