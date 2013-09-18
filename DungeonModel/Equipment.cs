using System;

namespace Dungeon
{
    public enum WeaponType
    {
        Simple,
        Martial,
        Exotic,
    }

    [Flags]
    public enum ArmorType
    {
        Light = 1,
        Medium = 2,
        Heavy = 4,
    }

    [Flags]
    public enum ShieldType
    {
        Light = 1,
        Heavy = 2,
        Tower = 4,
    }

    public class Weapon
    {
        public int Id { get; set; }
        public WeaponType Type { get; set; }
    }

    public class Armor
    {
        public int Id { get; set; }
        public ArmorType Type { get; set; }
    }

    public class Shield
    {
        public int Id { get; set; }
        public ShieldType Type { get; set; }
    }
}