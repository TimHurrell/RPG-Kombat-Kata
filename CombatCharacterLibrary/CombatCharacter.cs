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
       



        public Character CausesDamage(Character victim, int amountOfDamage,int distance = 0)
        {
            if (victim.Alive && victim != this && InRange(distance) && ! Faction.Overlaps(victim.Faction))
               
            {


                    decimal weighteddamage = amountOfDamage * DamageFactorMultiplier(victim.Level);

                victim.Health -= (int)weighteddamage;


                victim.Health = victim.Health < 0 ? victim.Health = 0 : victim.Health;

                victim.Alive = victim.Health == 0 ? victim.Alive = false : victim.Alive;
                
            }


            return victim;

        }


        public Thing CausesDamage(Thing victim, int amountOfDamage, int distance = 0)
        {
            if (victim.Alive && InRange(distance) && !Faction.Overlaps(victim.Faction))

            {

                victim.Health -= amountOfDamage;


                victim.Health = victim.Health < 0 ? victim.Health = 0 : victim.Health;

                victim.Alive = victim.Health == 0 ? victim.Alive = false : victim.Alive;

            }


            return victim;

        }


        public Character Heals(Character patient, int amountOfHealth)
        {
            if (patient.Alive && (patient == this || Faction.Overlaps(patient.Faction)))
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


        public bool InRange(int distance=0)
        {
            int range = 0;
            switch (CType)
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
