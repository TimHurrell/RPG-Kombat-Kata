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
            Assert.Equal(1000,combatCharacter.Health);
        }

        [Fact]
        public void CurrentLevelOfCharacter()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            Assert.Equal(1, combatCharacter.Level);
        }

        [Fact]
        public void CurrentStateOfCharacter()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            Assert.True(combatCharacter.Alive);
        }


        [Fact]
        public void DamageToCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterDamaged,100);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageToCharacterCausingDeath()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterDamaged, 1100);
            Assert.False(combatCharacterDamaged.Alive);
        }



        [Fact]
        public void EnhanceDifferentCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacter.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(900, combatCharacterEnhanced.Health);
        }


        [Fact]
        public void DamageToSelfCharacterHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacter, 100);
            Assert.Equal(1000, combatCharacter.Health);
        }


        [Fact]
        public void EnhanceCharacterSelfHealth()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.Health);
        }

        [Fact]
        public void EnhanceCharacterSelfHealthBeyond1000()
        {
            CombatCharacter combatCharacterEnhanced = new CombatCharacter();
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.Health);
        }

        [Fact]
        public void DamageFactorIncrease()
        {
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            var combatCharacter = new CombatCharacter(1000, 6, true);
            Assert.Equal(1.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.Level));
        }


        [Fact]
        public void DamageFactorDecrease()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            var combatCharacterDamaged = new CombatCharacter(1000, 6, true);
            Assert.Equal(0.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.Level));
        }


        [Fact]
        public void DamageFactorSame()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            Assert.Equal(1.0m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.Level));
        }

        [Fact]
        public void DamageIncreased()
        {
            CombatCharacter combatCharacterDamaged = new CombatCharacter();
            var combatCharacter = new CombatCharacter(1000, 6, true);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(850, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageDecrease()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            var combatCharacterDamaged = new CombatCharacter(1000, 6, true);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(950, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageSame()
        {
            var combatCharacter = new CombatCharacter(1000, 6, true);
            var combatCharacterDamaged = new CombatCharacter(1000, 5, true);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }



        //[Fact]
        //public void DistanceOfCharacter()
        //{
        //    CombatCharacter combatCharacter = new CombatCharacter();
        //    CombatCharacter combatCharacterDamaged = new CombatCharacter();
        //    combatCharacter.location[0, 0] = 3;
        //    combatCharacter.location[0, 1] = 4;
        //    Assert.Equal(5, combatCharacter.GetDistanceFromVictim(combatCharacterDamaged.location));
        //}


    //    [Fact]
    //    public void CharacterInRangeMeleeFalse()
    //    {
    //        CombatCharacter combatCharacter = new CombatCharacter();
    //        CombatCharacter combatCharacterDamaged = new CombatCharacter();
    //        combatCharacter.location[0, 0] = 3;
    //        combatCharacter.location[0, 1] = 4;
    //        Assert.False(combatCharacter.InRange(combatCharacterDamaged.location));
    //    }


    //    [Fact]
    //    public void CharacterInRangeMeleeTrue()
    //    {
    //        CombatCharacter combatCharacter = new CombatCharacter();
    //        CombatCharacter combatCharacterDamaged = new CombatCharacter();
    //        combatCharacter.location[0, 0] = 1;
    //        combatCharacter.location[0, 1] = 1;
    //        Assert.True(combatCharacter.InRange(combatCharacterDamaged.location));
    //    }


    //    [Fact]
    //    public void CharacterInRangeRangedTrue()
    //    {
    //        CombatCharacter combatCharacter = new RangedCharacter();
    //        CombatCharacter combatCharacterDamaged = new RangedCharacter();
    //        combatCharacter.location[0, 0] = 3;
    //        combatCharacter.location[0, 1] = 4;
    //        Assert.True(combatCharacter.InRange(combatCharacterDamaged.location));
    //    }


    //    [Fact]
    //    public void CharacterInRangeRangedFalse()
    //    {
    //        RangedCharacter combatCharacter = new RangedCharacter();
    //        RangedCharacter combatCharacterDamaged = new RangedCharacter();
    //        combatCharacter.location[0, 0] = 15;
    //        combatCharacter.location[0, 1] = 20;
    //        Assert.False(combatCharacter.InRange(combatCharacterDamaged.location));
    //    }
    }



}
