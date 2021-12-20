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
            CombatCharacter combatCharacter = new MeleeCharacter();
            Assert.Equal(1000,combatCharacter.health);
        }

        [Fact]
        public void CurrentLevelOfCharacter()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            Assert.Equal(1, combatCharacter.level);
        }

        [Fact]
        public void CurrentStateOfCharacter()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            Assert.True(combatCharacter.alive);
        }


        [Fact]
        public void DamageToCharacterHealth()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.CausesDamage(combatCharacterDamaged,100);
            Assert.Equal(900, combatCharacterDamaged.health);
        }


        [Fact]
        public void DamageToCharacterCausingDeath()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.CausesDamage(combatCharacterDamaged, 1100);
            Assert.False(combatCharacterDamaged.alive);
        }



        [Fact]
        public void EnhanceDifferentCharacterHealth()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterEnhanced = new MeleeCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacter.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(900, combatCharacterEnhanced.health);
        }


        [Fact]
        public void DamageToSelfCharacterHealth()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            combatCharacter.CausesDamage(combatCharacter, 100);
            Assert.Equal(1000, combatCharacter.health);
        }


        [Fact]
        public void EnhanceCharacterSelfHealth()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterEnhanced = new MeleeCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.health);
        }

        [Fact]
        public void EnhanceCharacterSelfHealthBeyond1000()
        {
            CombatCharacter combatCharacterEnhanced = new MeleeCharacter();
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.health);
        }

        [Fact]
        public void DamageFactorIncrease()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.level = 6;
            Assert.Equal(1.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.level));
        }


        [Fact]
        public void DamageFactorDecrease()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacterDamaged.level = 6;
            Assert.Equal(0.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.level));
        }


        [Fact]
        public void DamageFactorSame()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            Assert.Equal(1.0m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.level));
        }

        [Fact]
        public void DamageIncreased()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.level = 6;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(850, combatCharacterDamaged.health);
        }


        [Fact]
        public void DamageDecrease()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacterDamaged.level = 6;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(950, combatCharacterDamaged.health);
        }


        [Fact]
        public void DamageSame()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.level = 6;
            combatCharacterDamaged.level = 5;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.health);
        }



        //[Fact]
        //public void DistanceOfCharacter()
        //{
        //    CombatCharacter combatCharacter = new MeleeCharacter();
        //    CombatCharacter combatCharacterDamaged = new MeleeCharacter();
        //    combatCharacter.location[0, 0] = 3;
        //    combatCharacter.location[0, 1] = 4;
        //    Assert.Equal(5, combatCharacter.GetDistanceFromVictim(combatCharacterDamaged.location));
        //}


        [Fact]
        public void CharacterInRangeFalse()
        {
            CombatCharacter combatCharacter = new MeleeCharacter();
            CombatCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.location[0, 0] = 3;
            combatCharacter.location[0, 1] = 4;
            Assert.False(combatCharacter.InRange(combatCharacterDamaged.location));
        }


        [Fact]
        public void CharacterInRangeTrue()
        {
            MeleeCharacter combatCharacter = new MeleeCharacter();
            MeleeCharacter combatCharacterDamaged = new MeleeCharacter();
            combatCharacter.location[0, 0] = 1;
            combatCharacter.location[0, 1] = 1;
            Assert.True(combatCharacter.InRange(combatCharacterDamaged.location));
        }
    }



}
