using System.Collections.Generic;
using DiceLib;

namespace Dungeon
{
    public class SpecialAdvancement
    {
        public int Id { get; set; }
    }

    public class Throws
    {
        public int Bab { get; set; }
        public int Fortitude { get; set; }
        public int Reflex { get; set; }
        public int Will { get; set; }
    }

    public enum Throw
    {
        Fortitude,
        Reflex,
        Will
    }

    public class Advancement
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public Throws Throws { get; set; }
        public int BonusFeat { get; set; }
        //public SpecialAdvancement Special { get; set; }

        public virtual CharacterClass CharacterClass { get; set; }
    }

    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Alignment AllowedAlignments { get; set; }
        public Die HitDie { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ArmorType ArmorProficiency { get; set; }
        public ShieldType ShieldProficiency { get; set; }
        public int SkillsPerLevel { get; set; }
        public Die StartingGold { get; set; }

        public virtual ICollection<Advancement> Advancements { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }

    public class CharacterClassLevel
    {
        public int Id { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
        public int Level { get; set; }
    }
}