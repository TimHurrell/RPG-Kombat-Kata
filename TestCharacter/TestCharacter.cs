using CombatCharacterLibrary;
using System;
using Xunit;

namespace TestCharacter
{

    public class CharacterTests
    {

        [Fact]
        public void CurrentHealthOfCharacter()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            Assert.Equal(1000,combatCharacter.health);
        }

        [Fact]
        public void CurrentLevelOfCharacter()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            Assert.Equal(1, combatCharacter.level);
        }

        [Fact]
        public void CurrentStateOfCharacter()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            Assert.True(combatCharacter.alive);
        }


        [Fact]
        public void DamageToCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterDamaged,100);
            Assert.Equal(900, combatCharacterDamaged.health);
        }


        [Fact]
        public void DamageToCharacterCausingDeath()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterDamaged, 1100);
            Assert.False(combatCharacterDamaged.alive);
        }
    }
 
}
