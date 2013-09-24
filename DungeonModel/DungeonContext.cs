using System.Data.Entity;
using DiceLib;

namespace DungeonModel
{
    public class DungeonContext : DbContext
    {
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Feat> Feats { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Race> Races { get; set; }

        //hack for LinqPad...
        public DungeonContext() : base("DungeonModel.DungeonContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ComplexType<DungeonDie>();
        }
    }
}