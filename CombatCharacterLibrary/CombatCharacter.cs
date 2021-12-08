using System;

namespace CombatCharacterLibrary
{
    public class CombatCharacter
    {
        public int health { get; private set; } = 1000;
        public int level { get; set; } = 1;
        public bool alive { get; set; } = true;

        //public DateTime GetSupplierDispatchDate(DateTime orderdate)
        //{
        //    return orderdate.AddBusinessDays(LeadTime);
        //}
    }
}
