





namespace CombatObjectLibrary 
{


    public abstract class ICombatObject
    {
        public ICombatObject() { }
       

        public int Health { get; set; } = 1000;
        public bool Alive { get; set; } = true;


        public abstract void IsDamaged(Character attacker, int amountOfDamage, int distance = 0);


        public bool InRange(Character attacker, int distance = 0)
        {
            int range = 0;
            switch (attacker.CType)
            {
                case CombatType.Melee:
                    range = 2;
                    break;
                case CombatType.Range:
                    range = 20;
                    break;
                default:
                    break;
            }
            return range >= distance;
        }






    }
}
