
using CombatObjectLibrary;
using System;
using Xunit;


namespace TestCharacter
{

    public class ThingTests
    {

        [Fact]
public void CurrentHealthOfThing()
{
    ICombatObject combatThing = new Thing(2000);
    Assert.Equal(2000, combatThing.Health);
    Assert.True(combatThing.Alive);
    Assert.Contains(FactionN.Neutral, combatThing.Faction);
}

        [Fact]
        public void IsDamaged()
        {
            Thing combatThing = new Thing(2000);
            Character combatCharacter = new Character();
            combatCharacter.CType = CombatType.Melee;
            combatCharacter.CausesDamage(combatThing, 100, 2);
            Assert.Equal(1900, combatThing.Health);
        }





    }
}

