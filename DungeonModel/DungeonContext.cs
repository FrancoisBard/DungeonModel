using System.Data.Entity;

namespace Dungeon
{
    public class DungeonContext : DbContext
    {
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Feat> Feats { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Race> Races { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}