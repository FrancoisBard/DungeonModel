using System;
using System.Linq;
using Dungeon;

namespace DungeonModel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CharacterClassTest();
        }

        private static void CharacterClassTest()
        {
            using (var db = new DungeonContext())
            {
                // Create and save a new character
                Console.Write("Enter a name for a new character: ");
                string name = Console.ReadLine();

                var characterClass = new CharacterClass {Name = name};
                db.CharacterClasses.Add(characterClass);
                db.SaveChanges();

                // Display all Blogs from the database
                IOrderedQueryable<CharacterClass> query = from b in db.CharacterClasses
                                                          orderby b.Name
                                                          select b;

                Console.WriteLine("All characters in the database:");
                foreach (CharacterClass item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}