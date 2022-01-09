
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
        }

        [Fact]
        public void IsDamaged()
        {
            Thing combatThing = new Thing(2000);
            Character combatCharacter = new Character();
            combatCharacter.CType = CombatType.Melee;
            combatThing.IsDamaged(combatCharacter, 100, 2);
            Assert.Equal(1900, combatThing.Health);
        }





    }
}

