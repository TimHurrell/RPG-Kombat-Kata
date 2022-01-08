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
            Faction.Add(FactionN.Neutral);
        }



    }
}
