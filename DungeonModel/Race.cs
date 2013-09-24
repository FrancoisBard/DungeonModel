using System;
using System.Collections.Generic;

namespace DungeonModel
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public Size Size { get; set; }
        ////public Speed Speed { get; set; }
        //public int LevelAdjustment { get; set; }
        //public int Space { get; set; } //feet ? inches ? both (complex type ?)
        //public int Reach { get; set; } //btw Space and Reach aren't just consequences of the Size ? 

        ////Bonuses and others
        //public Ability AbilityAdjustments { get; set; }
        //public Language AutomaticLanguages { get; set; }
        //public Language BonusLanguages { get; set; }
        //public Vision Vision { get; set; }
        //public virtual ICollection<Feat> Feats { get; set; }
        //public virtual ICollection<SkillBonus> SkillBonuses { get; set; }

        //public virtual ICollection<OtherCharacteristic> Others { get; set; }
    }

    [Flags]
    public enum Language
    {
        None = 0,
        Common = 1,
    }

    [Flags]
    public enum Vision
    {
        None = 0,
        Dark = 1,
        LowLight = 2,
        Normal = 4
    }

    public class OtherCharacteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SkillBonus
    {
        public int Id { get; set; }
        public Skill Skill { get; set; }
        public int Bonus { get; set; }
    }

    [Flags]
    public enum Size
    {
        None = 0,
        Diminutive = 1,
        Tiny = 2,
        Small = 4,
        Medium = 8,
        Large = 16,
        Huge = 32,
        Gargantuan = 64,
        Colossal = 128,
    }

    //public class Speed
    //{
    //    public Medium Medium { get; set; }
    //    //public MediumSpeed Medium { get; set; }
    //}

    ////todo
    //public enum Medium
    //{
    //    None = 0
    //}
}