using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DiceLib;

namespace DungeonModel.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DungeonContext>
    {
        public Configuration()
        {
            //change it to false when the code has reached a certain stability
            AutomaticMigrationsEnabled = true; 
        }

        //todo separate Seed in several classes ? need to read Julie again..
        protected override void Seed(DungeonContext context)
        {
            //races
            context.Races.AddOrUpdate(
                c => c.Name,
                new Race { Name = "Dwarf", Description = "test"},
                new Race { Name = "Elf", Description = "test" },
                new Race { Name = "Gnome", Description = "test" },
                new Race { Name = "Half-Elf", Description = "test" },
                new Race { Name = "Half-Orc", Description = "test" },
                new Race { Name = "Halfling", Description = "test" },
                new Race { Name = "Human", Description = "test" }
                );

            //maybe i should write a helper to generate the advancements for each character class. The progressions are always the same no ?
            var fighterAdvancement = new List<Advancement>
                        {
                            new Advancement {Level = 1, Throws = new Throws {Bab = 1, Fortitude = 2, Reflex = 0, Will = 0}, BonusFeat = 1},
                            new Advancement {Level = 2, Throws = new Throws {Bab = 2, Fortitude = 3, Reflex = 0, Will = 0}, BonusFeat = 1},
                            new Advancement {Level = 3, Throws = new Throws {Bab = 3, Fortitude = 3, Reflex = 1, Will = 1}, BonusFeat = 0},
                            new Advancement {Level = 4, Throws = new Throws {Bab = 4, Fortitude = 4, Reflex = 1, Will = 1}, BonusFeat = 1},
                            new Advancement {Level = 5, Throws = new Throws {Bab = 5, Fortitude = 4, Reflex = 1, Will = 1}, BonusFeat = 0},
                            new Advancement {Level = 6, Throws = new Throws {Bab = 6, Fortitude = 5, Reflex = 2, Will = 2}, BonusFeat = 1},
                            new Advancement {Level = 7, Throws = new Throws {Bab = 7, Fortitude = 5, Reflex = 2, Will = 2}, BonusFeat = 0},
                            new Advancement {Level = 8, Throws = new Throws {Bab = 8, Fortitude = 6, Reflex = 2, Will = 2}, BonusFeat = 1},
                            new Advancement {Level = 9, Throws = new Throws {Bab = 9, Fortitude = 6, Reflex = 3, Will = 3}, BonusFeat = 0},
                            new Advancement {Level = 10, Throws = new Throws {Bab = 10, Fortitude = 7, Reflex = 3, Will = 3}, BonusFeat = 1},
                            new Advancement {Level = 11, Throws = new Throws {Bab = 11, Fortitude = 7, Reflex = 3, Will = 3}, BonusFeat = 0},
                            new Advancement {Level = 12, Throws = new Throws {Bab = 12, Fortitude = 8, Reflex = 4, Will = 4}, BonusFeat = 1},
                            new Advancement {Level = 13, Throws = new Throws {Bab = 13, Fortitude = 8, Reflex = 4, Will = 4}, BonusFeat = 0},
                            new Advancement {Level = 14, Throws = new Throws {Bab = 14, Fortitude = 9, Reflex = 4, Will = 4}, BonusFeat = 1},
                            new Advancement {Level = 15, Throws = new Throws {Bab = 15, Fortitude = 9, Reflex = 5, Will = 5}, BonusFeat = 0},
                            new Advancement {Level = 16, Throws = new Throws {Bab = 16, Fortitude = 10, Reflex = 5, Will = 5}, BonusFeat = 1},
                            new Advancement {Level = 17, Throws = new Throws {Bab = 17, Fortitude = 10, Reflex = 5, Will = 5}, BonusFeat = 0},
                            new Advancement {Level = 18, Throws = new Throws {Bab = 18, Fortitude = 11, Reflex = 6, Will = 6}, BonusFeat = 1},
                            new Advancement {Level = 19, Throws = new Throws {Bab = 19, Fortitude = 11, Reflex = 6, Will = 6}, BonusFeat = 0},
                            new Advancement {Level = 20, Throws = new Throws {Bab = 20, Fortitude = 12, Reflex = 6, Will = 6}, BonusFeat = 1}
                                };

            context.CharacterClasses.AddOrUpdate(
                c => c.Name,
                new CharacterClass
                    {
                        Name = "Barbarian",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        Weapons = context.Weapons.Where(w => w.Type != WeaponType.Simple || w.Type == WeaponType.Martial).ToList()
                    },
                new CharacterClass
                    {
                        Name = "Bard",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.NonLawful,
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(6),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                new CharacterClass
                    {
                        Name = "Cleric",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                new CharacterClass
                    {
                        Name = "Druid",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                new CharacterClass
                    {
                        Name = "Fighter",
                        Advancements = fighterAdvancement,
                        AllowedAlignments = Alignment.All,
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium | ArmorType.Heavy,
                        HitDie = new DungeonDie(10),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy | ShieldType.Tower,
                        Skills = new List<Skill>(), //climb, craft, handleAnimal, intimidate, jump, ride, swim,
                        SkillsPerLevel = 2,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial | WeaponType.Exotic
                    },
                    new CharacterClass
                    {
                        Name = "Monk",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                    new CharacterClass
                    {
                        Name = "Paladin",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                    new CharacterClass
                    {
                        Name = "Ranger",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                    new CharacterClass
                    {
                        Name = "Rogue",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                    new CharacterClass
                    {
                        Name = "Sorcerer",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    },
                    new CharacterClass
                    {
                        Name = "Wizard",
                        Advancements = null, //todo
                        AllowedAlignments = Alignment.All, //unsure...
                        ArmorProficiency = ArmorType.Light | ArmorType.Medium,
                        HitDie = new DungeonDie(12),
                        ShieldProficiency = ShieldType.Light | ShieldType.Heavy,
                        Skills = new List<Skill>(), //todo
                        SkillsPerLevel = 4,
                        //WeaponProficiency = WeaponType.Simple | WeaponType.Martial
                    }
                );

            //skills (3.5)
            context.Skills.AddOrUpdate(
                s => s.Name,
                new Skill { Name = "Appraise", Ability = "INT", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Balance", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Bluff", Ability = "CHA", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Climb", Ability = "STR", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Concentration", Ability = "CON", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Craft", Ability = "INT", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Decipher Script", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Diplomacy", Ability = "CHA", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Disable Device", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Disguise", Ability = "CHA", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Escape Artist", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Forgery", Ability = "INT", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Gather Information", Ability = "CHA", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Handle Animal", Ability = "CHA", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Heal", Ability = "WIS", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Jump", Ability = "STR", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Knowledge (arcana)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (architecture and engineering)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (dungeoneering)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (geography)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (history)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (local)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (nature)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (nobility and royalty)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (religion)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Knowledge (the planes)", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Hide", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Intimidate", Ability = "CHA", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Listen", Ability = "WIS", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Move Silently", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Open Lock", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Perform", Ability = "CHA", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Profession", Ability = "WIS", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Ride", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Search", Ability = "INT", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Sense Motive", Ability = "WIS", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Sleight of Hand", Ability = "DEX", TrainedOnly = true, ArmorCheckPenalty = true },
                new Skill { Name = "Speak Language", Ability = "NONE", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Spellcraft", Ability = "INT", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Spot", Ability = "WIS", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Survival", Ability = "WIS", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Swim", Ability = "STR", TrainedOnly = false, ArmorCheckPenalty = true },
                new Skill { Name = "Tumble", Ability = "DEX", TrainedOnly = true, ArmorCheckPenalty = true },
                new Skill { Name = "Use Magic Device ", Ability = "CHA", TrainedOnly = true, ArmorCheckPenalty = false },
                new Skill { Name = "Use Rope", Ability = "DEX", TrainedOnly = false, ArmorCheckPenalty = false },
                new Skill { Name = "Use Psionic Device", Ability = "CHA", TrainedOnly = true, ArmorCheckPenalty = false }
                );

            //feats (3.5) todo multi1 multi2 Requirements
            context.Feats.AddOrUpdate(
                f => f.Name,
                new Feat { Name = "Acrobatic", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Agile", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Alertness", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Animal Affinity", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Armor Proficiency (heavy)", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Armor Proficiency (light)", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Armor Proficiency (medium)", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Athletic", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Augment Summoning", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Blind-Fight", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Brew Potion", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Cleave", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Combat Casting", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Combat Expertise", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Combat Reflexes", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Craft Magic Arms and Armor", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Craft Rod", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Craft Staff", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Craft Wand", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Craft Wondrous Item", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Deceitful", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Deflect Arrows", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Deft Hands", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Diehard", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Diligent", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Dodge", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Empower Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Endurance", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Enlarge Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Eschew Materials", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Exotic Weapon Proficiency", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Extend Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Extra Turning", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Far Shot", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Forge Ring", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Great Cleave", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Great Fortitude", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Greater Spell Focus", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Greater Spell Penetration", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Greater Two-Weapon Fighting", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Greater Weapon Focus", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Greater Weapon Specialization", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Heighten Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Bull Rush", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Counterspell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Critical", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Disarm", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Feint", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Grapple", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Initiative", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Overrun", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Precise Shot", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Shield Bash", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Sunder", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Trip", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Turning", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Two-Weapon Fighting", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Improved Unarmed Strike", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Investigator", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Iron Will", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Leadership", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Lightning Reflexes", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Magical Aptitude", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Manyshot", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Martial Weapon Proficiency", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Maximize Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Mobility", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Mounted Archery", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Mounted Combat", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Natural Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Negotiator", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Nimble Fingers", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Persuasive", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Point Blank Shot", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Power Attack", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Precise Shot", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Quick Draw", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Quicken Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Rapid Reload", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Rapid Shot", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Ride-By Attack", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Run", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Scribe Scroll", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Self-Sufficient", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Shield Proficiency", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Shot on the Run", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Silent Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Simple Weapon Proficiency", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Skill Focus", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Snatch Arrows", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Spell Focus", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Spell Mastery", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Spell Penetration", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Spirited Charge", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Spring Attack", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Stealthy", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Still Spell", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Stunning Fist", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Sunder", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Toughness", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Tower Shield Proficiency", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Track", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Trample", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Two-Weapon Defense", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Two-Weapon Fighting", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Weapon Finesse", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Weapon Focus", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Weapon Specialization", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Whirlwind Attack", Multi1 = false, Multi2 = false, Requirements = null },
                new Feat { Name = "Widen Spell", Multi1 = false, Multi2 = false, Requirements = null }
                );
        }
    }
}