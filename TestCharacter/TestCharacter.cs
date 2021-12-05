using CombatCharacter;
using System;
using Xunit;

namespace TestCharacter
{

    public class CharacterTests
    {

        [Fact]
        public void CurrentHealthOfCharacter()
        {
            CombatCharacters combatCharacter = new CombatCharacters();
            Assert.Equal(1000,combatCharacter.health);
        }
    }
 
}
