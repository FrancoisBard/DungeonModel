namespace Dungeon
{
    public class Skill
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }
        public bool TrainedOnly { get; set; }
        public bool ArmorCheckPenalty { get; set; }
    }
}