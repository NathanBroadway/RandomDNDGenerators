using System;
using System.Collections.Generic;

namespace SupportClasses
{
    public class Weapons
    {
        public static List<Weapon> GetSwords()
        {
            return new List<Weapon> { Weapon.Greatsword, Weapon.Longsword, Weapon.Scimitar, Weapon.Rapier, Weapon.Shortsword };
        }
        public static List<Weapon> GetAxes()
        {
            return new List<Weapon> { Weapon.Handaxe, Weapon.Battleaxe, Weapon.Greataxe };
        }
        public static List<Weapon> GetSlashingSwords()
        {
            return new List<Weapon> { Weapon.Greatsword, Weapon.Longsword, Weapon.Scimitar };
        }
        public static List<Weapon> GetWeapons()
        {
            return new List<Weapon> { Weapon.Sickle, Weapon.Spear, Weapon.Net, Weapon.Club, Weapon.Sling, Weapon.Battleaxe, Weapon.Flail, Weapon.Lance, Weapon.Maul, Weapon.Shortsword, Weapon.Blowgun, Weapon.Longsword, Weapon.Morningstar, Weapon.Warhammer, Weapon.Dagger, Weapon.LightHammer, Weapon.Whip, Weapon.Greatclub, Weapon.Quarterstaff, Weapon.Glaive, Weapon.Halberd, Weapon.LightCrossbow, Weapon.Shortbow, Weapon.Rapier, Weapon.Scimitar, Weapon.Greataxe, Weapon.Dart, Weapon.Handaxe, Weapon.Mace, Weapon.Pike, Weapon.Trident, Weapon.WarPick, Weapon.Javelin, Weapon.Greatsword, Weapon.HeavyCrossbow, Weapon.Longbow, Weapon.HandCrossbow, Weapon.Boomerang , Weapon.Yklwa };
        }

        public static double PriceWeapon(Weapon weapon)
        {
            switch (weapon)
            {
                case Weapon.Sickle:
                case Weapon.Spear:
                case Weapon.Net:
                case Weapon.Yklwa:
                    return 1;
                case Weapon.Club:
                case Weapon.Sling:
                case Weapon.Boomerang:
                    return 0.1;
                case Weapon.Battleaxe:
                case Weapon.Flail:
                case Weapon.Lance:
                case Weapon.Maul:
                case Weapon.Shortsword:
                case Weapon.Blowgun:
                    return 10;
                case Weapon.Longsword:
                case Weapon.Morningstar:
                case Weapon.Warhammer:
                    return 15;
                case Weapon.Dagger:
                case Weapon.LightHammer:
                case Weapon.Whip:
                    return 2;
                case Weapon.Greatclub:
                case Weapon.Quarterstaff:
                    return 0.2;
                case Weapon.Glaive:
                case Weapon.Halberd:
                    return 20;
                case Weapon.LightCrossbow:
                case Weapon.Shortbow:
                case Weapon.Rapier:
                case Weapon.Scimitar:
                    return 25;
                case Weapon.Greataxe:
                    return 30;
                case Weapon.Dart:
                    return 0.05;
                case Weapon.Handaxe:
                case Weapon.Mace:
                case Weapon.Pike:
                case Weapon.Trident:
                case Weapon.WarPick:
                    return 5;
                case Weapon.Javelin:
                    return 0.5;
                case Weapon.Greatsword:
                case Weapon.HeavyCrossbow:
                case Weapon.Longbow:
                    return 50;
                case Weapon.HandCrossbow:
                    return 75;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weapon), weapon, null);
            }

            return 0;
        }

        public static string GetName(Weapon weapon)
        {
            return weapon switch
            {
                Weapon.LightHammer => "Light Hammer",
                Weapon.LightCrossbow => "Light Crossbow",
                Weapon.WarPick => "War Pick",
                Weapon.HandCrossbow => "Hand Crossbow",
                Weapon.HeavyCrossbow => "Heavy Crossbow",
                _ => weapon.ToString()
            };
        }
        public static void RandWeapon(Item temp, List<Weapon> weapons)
        {
            var rand = new Random();
            temp.Subcategory2 = GetName(weapons[rand.Next(0, weapons.Count - 1)]);
        }
    }

    public enum Weapon
    {
        Club,
        Dagger,
        Greatclub,
        Handaxe,
        Javelin,
        LightHammer,
        Mace,
        Quarterstaff,
        Sickle,
        Spear,
        Yklwa,
        LightCrossbow,
        Dart,
        Shortbow,
        Sling,
        Boomerang,
        Battleaxe,
        Flail,
        Glaive,
        Greataxe,
        Greatsword,
        Halberd,
        Lance,
        Longsword,
        Maul,
        Morningstar,
        Pike,
        Rapier,
        Scimitar,
        Shortsword,
        Trident,
        WarPick,
        Warhammer,
        Whip,
        Blowgun,
        HandCrossbow,
        HeavyCrossbow,
        Longbow,
        Net
    }
}