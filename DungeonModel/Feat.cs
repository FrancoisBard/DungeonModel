namespace DungeonModel
{
    public class Feat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Requirements { get; set; }
        public bool Multi1 { get; set; } //multiselection
        public bool Multi2 { get; set; } //cumulable
    }

    public enum RequirementType
    {
        Class,
        Feat,
        Ability,
        Bab,
        SpellCaster,
    }

    public class Requirement
    {
        public RequirementType Type { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public int MinimumValue { get; set; }
        public AbilityType Ability { get; set; }
    }
}