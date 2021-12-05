using System;

namespace CombatCharacter
{
    public class CombatCharacters
    {
        public int health { get; set; } = 1000;
        private int level { get; set; } = 1;
        private bool alive { get; set; }

        //public DateTime GetSupplierDispatchDate(DateTime orderdate)
        //{
        //    return orderdate.AddBusinessDays(LeadTime);
        //}
    }
}
