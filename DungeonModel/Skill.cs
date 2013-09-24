namespace DungeonModel
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }
        public bool TrainedOnly { get; set; }
        public bool ArmorCheckPenalty { get; set; }
    }
}