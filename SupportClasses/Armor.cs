using System;
using System.Collections.Generic;

namespace SupportClasses
{
    public enum Armor
    {
        Padded,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ScaleMail,
        Breastplate,
        HalfPlate,
        RingMail,
        ChainMail,
        Splint,
        Plate,
        SpikedArmor,
        PrideSilkOutfit,
        Shield
    }

    public class Armors
    {
        public static List<Armor> HeavyArmors()
        {
            return new List<Armor> { Armor.RingMail, Armor.ChainMail, Armor.PrideSilkOutfit, Armor.Splint, Armor.Plate };
        }
        public static List<Armor> MediumArmors()
        {
            return new List<Armor> { Armor.Hide, Armor.ChainShirt, Armor.SpikedArmor, Armor.ScaleMail, Armor.Breastplate, Armor.HalfPlate };
        }
        public static List<Armor> LightArmors()
        {
            return new List<Armor> { Armor.Padded, Armor.Leather, Armor.StuddedLeather };
        }

        public static int PriceArmor(Armor armor)
        {
            switch (armor)
            {
                case Armor.Padded:
                    return 5;
                case Armor.Leather:
                case Armor.Hide:
                    return 10;
                case Armor.PrideSilkOutfit:
                    return 500;
                case Armor.StuddedLeather:
                    return 45;
                case Armor.ChainShirt:
                case Armor.ScaleMail:
                    return 50;
                case Armor.Breastplate:
                    return 400;
                case Armor.HalfPlate:
                    return 750;
                case Armor.RingMail:
                    return 30;
                case Armor.ChainMail:
                case Armor.SpikedArmor:
                    return 75;
                case Armor.Splint:
                    return 200;
                case Armor.Plate:
                    return 1500;
                case Armor.Shield:
                    return 10;
            }

            return 0;
        }

        public static string GetName(Armor armor)
        {
            return armor switch
            {
                Armor.StuddedLeather => "Studded Leather",
                Armor.ChainShirt => "Chain Shirt",
                Armor.ScaleMail => "Chain Mail",
                Armor.HalfPlate => "Half Plate",
                Armor.RingMail => "Ring Mail",
                Armor.ChainMail => "Chain Mail",
                Armor.SpikedArmor => "Spiked Armor",
                Armor.PrideSilkOutfit => "Pride Silk Outfit",
                _ => armor.ToString()
            };
        }

        public static void RandArmor(Item temp, List<Armor> armors)
        {
            var rand = new Random();
            temp.Subcategory2 = Armors.GetName(armors[rand.Next(0, armors.Count - 1)]);
        }
    }
}