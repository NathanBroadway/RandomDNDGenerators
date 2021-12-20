using System;
using System.Collections.Generic;

namespace SupportClasses
{
    public class Ammunitions
    {
        public static List<Ammunition> GetAmmunitions()
        {
            return new List<Ammunition> { Ammunition.Arrows, Ammunition.BlowgunNeedles, Ammunition.CrossbowBolts, Ammunition.SlingBullets };
        }

        public static double PriceWeapon(Ammunition ammunition)
        {
            switch (ammunition)
            {
                case Ammunition.Arrows:
                case Ammunition.BlowgunNeedles:
                case Ammunition.CrossbowBolts:
                    return 1;
                case Ammunition.SlingBullets:
                    return 0.04;
            }

            return 0;
        }

        public static string GetName(Ammunition ammunition)
        {
            return ammunition switch
            {
                Ammunition.BlowgunNeedles => "Blowgun Needles",
                Ammunition.CrossbowBolts => "Crossbow Bolts",
                Ammunition.SlingBullets => "Sling Bullets",
                _ => ammunition.ToString()
            };
        }
        public static void RandAmmunition(Item temp, List<Ammunition> ammunitions)
        {
            var rand = new Random();
            temp.Subcategory2 = GetName(ammunitions[rand.Next(0, ammunitions.Count - 1)]);
        }
    }

    public enum Ammunition
    {
        Arrows,
        BlowgunNeedles,
        CrossbowBolts,
        SlingBullets
    }

}
