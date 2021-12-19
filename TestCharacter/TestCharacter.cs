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
        public void EnhanceDifferentCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacter.Heals(combatCharacterEnhanced, 100);
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
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.health);
        }

        [Fact]
        public void EnhanceCharacterSelfHealthBeyond1000()
        {
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.health);
        }

        [Fact]
        public void DamageFactorIncrease()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.level = 6;
            Assert.Equal(1.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.level));
        }


        [Fact]
        public void DamageFactorDecrease()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacterDamaged.level = 6;
            Assert.Equal(0.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.level));
        }


        [Fact]
        public void DamageFactorSame()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            Assert.Equal(1.0m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.level));
        }

        [Fact]
        public void DamageIncreased()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.level = 6;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(850, combatCharacterDamaged.health);
        }


        [Fact]
        public void DamageDecrease()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacterDamaged.level = 6;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(950, combatCharacterDamaged.health);
        }


        [Fact]
        public void DamageSame()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.level = 6;
            combatCharacterDamaged.level = 5;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.health);
        }



        [Fact]
        public void DistanceOfCharacter()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.location[0, 0] = 3;
            combatCharacter.location[0, 1] = 4;
            Assert.Equal(5, combatCharacter.GetDistanceFromVictim(combatCharacterDamaged.location));
        }
    }



}
