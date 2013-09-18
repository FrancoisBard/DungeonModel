using System;
using System.Collections.Generic;

namespace Dungeon
{
    //should we separate character and character state
    //should we have two states (a base state and a current state)?
    //(three or more) to handle things like lost levels, etc...?

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public virtual ICollection<CharacterClassLevel> ClassLevels { get; set; }
        public int HitPoints { get; set; }
        public Ability Ability { get; set; }
        public Throws Throws { get; set; }
        public CharacterState CurrentState { get; set; }
    }

    public class Ability
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }

    public enum AbilityType
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public class CharacterState
    {
        public int Id { get; set; }
        public int HitPoints { get; set; }
    }
}