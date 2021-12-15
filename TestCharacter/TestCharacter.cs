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


        [Fact]
        public void MakeDeadTest()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacterDamaged.alive = combatCharacter.MakeDead(0);
            Assert.False(combatCharacterDamaged.alive);
        }


        [Fact]
        public void EnhanceDifferentCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacter.EnhancesHealth(combatCharacterEnhanced, 100);
            Assert.Equal(900, combatCharacterEnhanced.health);
        }


        [Fact]
        public void DamageToSelfCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacter, 100);
            Assert.Equal(1000, combatCharacter.health);
        }


        [Fact]
        public void EnhanceCharacterSelfHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacterEnhanced.EnhancesHealth(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.health);
        }

        [Fact]
        public void EnhanceCharacterSelfHealthBeyond1000()
        {
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacterEnhanced.EnhancesHealth(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.health);
        }
    }



}
