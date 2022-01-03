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
            Assert.Equal(1000, combatCharacter.Health);
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
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
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

        [Fact]
        public void IsRightCharacterType()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CType = CombatType.Melee;
            Assert.Equal(0, (int)combatCharacter.CType);
            Assert.NotEqual(1, (int)combatCharacter.CType);
            combatCharacter.CType = CombatType.Range;
            Assert.Equal(1, (int)combatCharacter.CType);
            Assert.NotEqual(2, (int)combatCharacter.CType);
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


        [Fact]
        public void CharacterInRangeMeleeFalse()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CType = CombatType.Melee;
            Assert.False(combatCharacter.InRange(3));
        }
        [Fact]
        public void CharacterInRangeMeleeTrue()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CType = CombatType.Melee;
            Assert.True(combatCharacter.InRange(2));
        }

        [Fact]
        public void CharacterInRangeRangedFalse()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CType = CombatType.Range;
            Assert.False(combatCharacter.InRange(21));
        }
        [Fact]
        public void CharacterInRangeRangedTrue()
        {
            CombatCharacter combatCharacter = new CombatCharacter();
            combatCharacter.CType = CombatType.Range;
            Assert.True(combatCharacter.InRange(20));
        }


        [Fact]
        public void DamageFalseAsOutofRangeMelee()
        {
            var combatCharacter = new CombatCharacter(1000, 6, true);
            var combatCharacterDamaged = new CombatCharacter(1000, 6, true);
            combatCharacter.CType = CombatType.Melee;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100,3);
            Assert.Equal(1000, combatCharacterDamaged.Health);
        }

        [Fact]
        public void DamageTrueAsInRangeMelee()
        {
            var combatCharacter = new CombatCharacter(1000, 6, true);
            var combatCharacterDamaged = new CombatCharacter(1000, 6, true);
            combatCharacter.CType = CombatType.Melee;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100, 2);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageFalseAsOutofRangeRanged()
        {
            var combatCharacter = new CombatCharacter(1000, 6, true);
            var combatCharacterDamaged = new CombatCharacter(1000, 6, true);
            combatCharacter.CType = CombatType.Range;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100, 21);
            Assert.Equal(1000, combatCharacterDamaged.Health);
        }

        [Fact]
        public void DamageTrueAsInRangeRanged()
        {
            var combatCharacter = new CombatCharacter(1000, 6, true);
            var combatCharacterDamaged = new CombatCharacter(1000, 6, true);
            combatCharacter.CType = CombatType.Range;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100, 20);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void FactionMembership()
        {
            var combatCharacter = new CombatCharacter(1000, 6, true);
            combatCharacter.FType = FactionType.TheRobins;
            Assert.Equal(3, (int)combatCharacter.FType);
            Enum myColors = combatCharacter.FType;

            combatCharacter.Faction.Add("TheRobins");
            //Assert.Contains("TheRobins", combatCharacter.Faction);
        }


    }
}