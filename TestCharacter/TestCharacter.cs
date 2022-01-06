using CombatObjectLibrary;
using System;
using Xunit;

namespace TestCharacter
{

    public class CharacterTests
    {

        [Fact]
        public void CurrentHealthOfCharacter()
        {
            Character combatCharacter = new Character();
            Assert.Equal(1000, combatCharacter.Health);
        }

        [Fact]
        public void CurrentLevelOfCharacter()
        {
            Character combatCharacter = new Character();
            Assert.Equal(1, combatCharacter.Level);
        }

        [Fact]
        public void CurrentStateOfCharacter()
        {
            Character combatCharacter = new Character();
            Assert.True(combatCharacter.Alive);
        }


        [Fact]
        public void DamageToCharacterHealth()
        {
            Character combatCharacter = new Character();
            Character combatCharacterDamaged = new Character();
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageToCharacterCausingDeath()
        {
            Character combatCharacter = new Character();
            Character combatCharacterDamaged = new Character();
            combatCharacter.CausesDamage(combatCharacterDamaged, 1100);
            Assert.False(combatCharacterDamaged.Alive);
        }



        [Fact]
        public void EnhanceDifferentCharacterHealthButNotAlly()
        {
            Character combatCharacter = new Character();
            Character combatCharacterEnhanced = new Character();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacter.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(900, combatCharacterEnhanced.Health);
        }


        [Fact]
        public void DamageToSelfCharacterHealth()
        {
            Character combatCharacter = new Character();
            combatCharacter.CausesDamage(combatCharacter, 100);
            Assert.Equal(1000, combatCharacter.Health);
        }


        [Fact]
        public void EnhanceCharacterSelfHealth()
        {
            Character combatCharacter = new Character();
            Character combatCharacterEnhanced = new Character();
            combatCharacter.CausesDamage(combatCharacterEnhanced, 100);
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.Health);
        }

        [Fact]
        public void EnhanceCharacterSelfHealthBeyond1000()
        {
            Character combatCharacterEnhanced = new Character();
            combatCharacterEnhanced.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.Health);
        }

        [Fact]
        public void DamageFactorIncrease()
        {
            Character combatCharacterDamaged = new Character();
            var combatCharacter = new Character(1000, 6, true);
            Assert.Equal(1.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.Level));
        }


        [Fact]
        public void DamageFactorDecrease()
        {
            Character combatCharacter = new Character();
            var combatCharacterDamaged = new Character(1000, 6, true);
            Assert.Equal(0.5m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.Level));
        }


        [Fact]
        public void DamageFactorSame()
        {
            Character combatCharacter = new Character();
            Character combatCharacterDamaged = new Character();
            Assert.Equal(1.0m, combatCharacter.DamageFactorMultiplier(combatCharacterDamaged.Level));
        }

        [Fact]
        public void DamageIncreased()
        {
            Character combatCharacterDamaged = new Character();
            var combatCharacter = new Character(1000, 6, true);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(850, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageDecrease()
        {
            Character combatCharacter = new Character();
            var combatCharacterDamaged = new Character(1000, 6, true);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(950, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageSame()
        {
            var combatCharacter = new Character(1000, 6, true);
            var combatCharacterDamaged = new Character(1000, 5, true);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }

        [Fact]
        public void IsRightCharacterType()
        {
            Character combatCharacter = new Character();
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
        //    Character combatCharacter = new Character();
        //    Character combatCharacterDamaged = new Character();
        //    combatCharacter.location[0, 0] = 3;
        //    combatCharacter.location[0, 1] = 4;
        //    Assert.Equal(5, combatCharacter.GetDistanceFromVictim(combatCharacterDamaged.location));
        //}


        [Fact]
        public void CharacterInRangeMeleeFalse()
        {
            Character combatCharacter = new Character();
            combatCharacter.CType = CombatType.Melee;
            Assert.False(combatCharacter.InRange(3));
        }
        [Fact]
        public void CharacterInRangeMeleeTrue()
        {
            Character combatCharacter = new Character();
            combatCharacter.CType = CombatType.Melee;
            Assert.True(combatCharacter.InRange(2));
        }

        [Fact]
        public void CharacterInRangeRangedFalse()
        {
            Character combatCharacter = new Character();
            combatCharacter.CType = CombatType.Range;
            Assert.False(combatCharacter.InRange(21));
        }
        [Fact]
        public void CharacterInRangeRangedTrue()
        {
            Character combatCharacter = new Character();
            combatCharacter.CType = CombatType.Range;
            Assert.True(combatCharacter.InRange(20));
        }


        [Fact]
        public void DamageFalseAsOutofRangeMelee()
        {
            var combatCharacter = new Character(1000, 6, true);
            var combatCharacterDamaged = new Character(1000, 6, true);
            combatCharacter.CType = CombatType.Melee;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100,3);
            Assert.Equal(1000, combatCharacterDamaged.Health);
        }

        [Fact]
        public void DamageTrueAsInRangeMelee()
        {
            var combatCharacter = new Character(1000, 6, true);
            var combatCharacterDamaged = new Character(1000, 6, true);
            combatCharacter.CType = CombatType.Melee;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100, 2);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageFalseAsOutofRangeRanged()
        {
            var combatCharacter = new Character(1000, 6, true);
            var combatCharacterDamaged = new Character(1000, 6, true);
            combatCharacter.CType = CombatType.Range;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100, 21);
            Assert.Equal(1000, combatCharacterDamaged.Health);
        }

        [Fact]
        public void DamageTrueAsInRangeRanged()
        {
            var combatCharacter = new Character(1000, 6, true);
            var combatCharacterDamaged = new Character(1000, 6, true);
            combatCharacter.CType = CombatType.Range;
            combatCharacter.CausesDamage(combatCharacterDamaged, 100, 20);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void FactionMembership()
        {
            var combatCharacter = new Character(1000, 6, true);
            Assert.Empty(combatCharacter.Faction);
            combatCharacter.join(FactionType.TheRobins);
            combatCharacter.join(FactionType.Freemason);
            Assert.Contains(FactionType.TheRobins, combatCharacter.Faction);
            Assert.Contains(FactionType.Freemason, combatCharacter.Faction);
            combatCharacter.leave(FactionType.Freemason);
            Assert.DoesNotContain(FactionType.Freemason, combatCharacter.Faction);
            Assert.DoesNotContain(FactionType.Illuminati, combatCharacter.Faction);
        }


        [Fact]
        public void DamageToAllyCharacterHealth()
        {
            Character combatCharacter = new Character();
            Character combatCharacterDamaged = new Character();
            combatCharacter.join(FactionType.TheRobins);
            combatCharacter.join(FactionType.Freemason);
            combatCharacterDamaged.join(FactionType.TheRobins);
            combatCharacterDamaged.join(FactionType.OpusDei);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(1000, combatCharacterDamaged.Health);
        }


        [Fact]
        public void DamageToNonAllyCharacterHealth()
        {
            Character combatCharacter = new Character();
            Character combatCharacterDamaged = new Character();
            combatCharacter.join(FactionType.TheRobins);
            combatCharacter.join(FactionType.Freemason);
            combatCharacterDamaged.join(FactionType.OpusDei);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }

        [Fact]
        public void DamageToNonAllyCharacterHealthWhenBlank()
        {
            Character combatCharacter = new Character();
            Character combatCharacterDamaged = new Character();
            combatCharacterDamaged.join(FactionType.OpusDei);
            combatCharacter.CausesDamage(combatCharacterDamaged, 100);
            Assert.Equal(900, combatCharacterDamaged.Health);
        }


        [Fact]
        public void EnhanceCharacterAllyHealth()
        {
            var combatCharacter = new Character(1000, 6, true);
            var combatCharacterEnhanced = new Character(900, 6, true);
            combatCharacter.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(900, combatCharacterEnhanced.Health);
            combatCharacter.join(FactionType.TheRobins);          
            combatCharacter.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(900, combatCharacterEnhanced.Health);
            combatCharacterEnhanced.join(FactionType.TheRobins);
            combatCharacter.Heals(combatCharacterEnhanced, 100);
            Assert.Equal(1000, combatCharacterEnhanced.Health);
        }


    }
}