using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SupportClasses;

namespace Shopping
{
    internal class Program
    {
        private static readonly Dictionary<string, List<Item>> Stores = ReadJSON<Item>(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\Shoppings.txt");
        private static readonly Dictionary<string, List<Drink>> Drinks = ReadJSON<Drink>(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\Drinks.txt");

        private static void Main()
        {
            MakingStores();
            //FixMagicItems();
            do
            {
                Console.Clear();
                WorkingStores();
                Console.Clear();
                Console.WriteLine("Look at another store? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void WorkingStores()
        {
            Console.WriteLine("Select Store Type");
            var i = 0;
            var orderedCategories = Stores.Keys.ToList();
            orderedCategories.AddRange(Drinks.Keys);
            orderedCategories = orderedCategories.OrderBy(x => x).ToList();

            foreach (var category in orderedCategories) Console.WriteLine($"{i++}: {category}");

            var readLine = Console.ReadLine();
            if (readLine == orderedCategories.IndexOf("Tavern").ToString()) SetTavernUp(orderedCategories, readLine);
            else if (readLine == orderedCategories.IndexOf("Jewelry Shop").ToString() || readLine == orderedCategories.IndexOf("Jewelry").ToString()) SetJewelryUp();
            else SetStoreUp(orderedCategories, readLine);
        }

        private static void SetJewelryUp()
        {
            var rand = new Random();
            var inStock = new List<Item>();
            var gems = new Dictionary<string, int> { { "Alexandrite", 500 }, { "Amber", 100 }, { "Amethyst", 100 }, { "Aquamarine", 500 }, { "Aquamarine Dust", 500 }, { "Azurite", 10 }, { "Black Onyx Stone", 150 }, { "Black Opal", 1000 }, { "Black Pearl", 500 }, { "Black Sapphire", 5000 }, { "Black Sapphire Dust", 5000 }, { "Bloodstone", 50 }, { "Blue Quartz", 10 }, { "Blue Sapphire", 1000 }, { "Blue Spinel", 500 }, { "Carnelian", 50 }, { "Chalcedony", 50 }, { "Chrysoberyl", 100 }, { "Chrysoprase", 50 }, { "Citrine", 50 }, { "Coral", 100 }, { "Crystal", 10 }, { "Diamond", 5000 }, { "Diamond (.5 carat)", 50 }, { "Diamond (10 carat)", 1000 }, { "Diamond (5 carat)", 500 }, { "Diamond (50 carat)", 5000 }, { "Diamond Dust", 5000 }, { "Emerald", 1000 }, { "Emerald Dust", 1000 }, { "Eye Agate", 10 }, { "Fire Opal", 1000 }, { "Fire Opal Dust", 1000 }, { "Garnet", 100 }, { "Hematite", 10 }, { "Jacinth", 5000 }, { "Jade", 100 }, { "Jade Dust", 100 }, { "Jasper", 50 }, { "Jet", 100 }, { "Lapis Lazuli", 10 }, { "Malachite", 10 }, { "Moonstone", 50 }, { "Moss Agate", 10 }, { "Obsidian", 10 }, { "Onyx", 50 }, { "Opal", 1000 }, { "Orb", 20 }, { "Pearl", 100 }, { "Peridot", 500 }, { "Quartz", 50 }, { "Rhodochrosite", 10 }, { "Ruby", 5000 }, { "Ruby Dust", 5000 }, { "Sapphire Dust", 1000 }, { "Sardonyx", 50 }, { "Spinel", 100 }, { "Star Rose Quartz", 50 }, { "Star Ruby", 1000 }, { "Star Sapphire", 1000 }, { "Tiger Eye", 10 }, { "Topaz", 500 }, { "Tourmaline", 100 }, { "Turquoise", 10 }, { "Yellow Sapphire", 1000 }, { "Zircon", 10 } };
            var metals = new Dictionary<string, double> { { "Adamantine", 5000 }, { "Brass", 0.3 }, { "Bronze", 0.4 }, { "Cold-Iron", 0.4 }, { "Copper", 0.5 }, { "Electrum", 25 }, { "Gold", 50 }, { "Iron", 0.1 }, { "Lead", 0.2 }, { "Mithral", 2500 }, { "Platinum", 500 }, { "Silver", 5 }, { "Steel", 4 }, { "Tin", 0.3 } };
            var items = new Dictionary<string, double> { { "Ring", 0.1 }, { "Necklace", 0.4 }, { "Circlet", 0.8 }, { "Encrusted Bowl", 0.5 }, { "Earrings", 0.2 }, { "Amulet", 0.4 }, { "Encrusted Dagger", 1 }, { "Bracelet", 0.3 } };
            while (inStock.Count < 10)
            {
                var gem = gems.Keys.ToList()[rand.Next(0, gems.Keys.ToList().Count)];
                var metal = metals.Keys.ToList()[rand.Next(0, metals.Keys.ToList().Count)];
                var item = items.Keys.ToList()[rand.Next(0, items.Keys.ToList().Count)];
                var temp = new Item("Jewelry", item, "", "", "NA", $"{gem} {metal} {item}", $"{gems[gem] + metals[metal] * items[item]}");

                if (!inStock.Contains(temp)) inStock.Add(temp);
            }

            do
            {
                Console.Clear();
                var i = 0;
                foreach (var ware in inStock) Console.WriteLine(i++ + ": " + ware.Stringify());

                var response = Console.ReadLine();
                if (!int.TryParse(response, out var respInt))
                {
                    Console.WriteLine("Leave? [Y/N]");
                    if (Console.ReadKey().Key == ConsoleKey.Y) break;
                }

                var lookInto = inStock[respInt];
                Console.WriteLine(lookInto);
            } while (true);

            AddToCurrentWares(inStock);
        }

        private static void SetStoreUp(List<string> orderedCategories, string readLine)
        {
            var wares = Stores[orderedCategories[int.Parse(readLine)]];
            var inStock = new List<Item>();
            var rand = new Random();

            if (wares.Count >= 10)
            {
                while (inStock.Count < 10)
                {
                    var temp = wares[rand.Next(0, wares.Count)];
                    switch (temp.Subcategory)
                    {
                        case "Armor":
                            {
                                var armors = new List<Armor>();
                                switch (temp.Subcategory2)
                                {
                                    case "\"Breastplate, Half Plate, or Plate\"":
                                        {
                                            armors = new List<Armor> { Armor.Breastplate, Armor.HalfPlate, Armor.Plate };
                                            break;
                                        }
                                    case "Any Heavy Armor":
                                        {
                                            armors = Armors.HeavyArmors();
                                            break;
                                        }
                                    case "Any Medium or Heavy":
                                        {
                                            armors = Armors.MediumArmors();
                                            armors.AddRange(Armors.HeavyArmors());
                                            break;
                                        }
                                    case "\"Medium or Heavy, but Not Hide\"":
                                        {
                                            armors = Armors.MediumArmors();
                                            armors.AddRange(Armors.HeavyArmors());
                                            armors.Remove(Armor.Hide);
                                            break;
                                        }
                                    case "\"Light, Medium, or Heavy\"":
                                    case "Any Armor":
                                        {
                                            armors = Armors.LightArmors();
                                            armors.AddRange(Armors.MediumArmors());
                                            armors.AddRange(Armors.HeavyArmors());
                                            break;
                                        }
                                    case "\"Light, Medium, or Heavy (with Resistance)\"":
                                        {
                                            armors = Armors.LightArmors();
                                            armors.AddRange(Armors.MediumArmors());
                                            armors.AddRange(Armors.HeavyArmors());
                                            var damageTypes = DamageTypes.GetDamageTypes();
                                            temp.Subcategory2 = Armors.GetName(armors[rand.Next(0, armors.Count - 1)]) + $" ({damageTypes[rand.Next(0, damageTypes.Count - 1)]})";
                                            armors = new List<Armor>();
                                            break;
                                        }
                                }
                                if (armors.Count > 0) Armors.RandArmor(temp, armors);
                                break;
                            }
                        case "Weapon":
                            {
                                var weapons = new List<Weapon>();
                                switch (temp.Subcategory2)
                                {
                                    case "Any Sword":
                                        {
                                            weapons = Weapons.GetSwords();
                                            break;
                                        }
                                    case "Any Weapon":
                                        {
                                            weapons = Weapons.GetWeapons();
                                            break;
                                        }
                                    case "Any Sword that Deals Slashing Damage":
                                        {
                                            weapons = Weapons.GetSlashingSwords();
                                            break;
                                        }
                                    case "Any Axe":
                                        {
                                            weapons = Weapons.GetAxes();
                                            break;
                                        }
                                    case "Any Axe or Sword":
                                        {
                                            weapons = Weapons.GetSwords();
                                            weapons.AddRange(Weapons.GetAxes());
                                            break;
                                        }
                                    case "Ammunition":
                                        {
                                            var ammunitions = Ammunitions.GetAmmunitions();
                                            Ammunitions.RandAmmunition(temp, ammunitions);
                                            break;
                                        }
                                }
                                if (weapons.Count > 0) Weapons.RandWeapon(temp, weapons);
                                break;
                            }
                    }
                    if (!inStock.Contains(temp)) inStock.Add(temp);
                }
            }
            else inStock = wares;

            do
            {
                Console.Clear();
                var i = 0;
                foreach (var ware in inStock) Console.WriteLine(i++ + ": " + ware.Stringify());
                Console.WriteLine("Would you like to drill into one?");

                var response = Console.ReadLine();
                if (!int.TryParse(response, out var respInt))
                {
                    Console.WriteLine("Leave? [Y/N]");
                    if (Console.ReadKey().Key == ConsoleKey.Y) break;
                }

                var lookInto = inStock[respInt];
                Console.Clear();
                Console.WriteLine(lookInto.Stringify());
                switch (lookInto.Category)
                {
                    case "Blacksmith":
                        switch (lookInto.Subcategory)
                        {
                            case "Armor":
                                Launch(@"https://roll20.net/compendium/dnd5e/Armors#content");
                                break;
                            case "Weapon":
                                Launch(@"https://roll20.net/compendium/dnd5e/Weapons#content");
                                break;
                        }

                        break;
                    case "Magic Items":
                    case "Potions":
                        LaunchMagicItems(lookInto);
                        break;
                }

                Console.ReadLine();
            } while (true);

            AddToCurrentWares(wares);
        }

        static void CheckPotions()
        {
            int i = 0;
            var names = new List<string>() { };
            foreach (var lookInto in Stores["Potions"])
            {
                if (names.Contains(lookInto.Name)) Debugger.Break();
                LaunchMagicItems(lookInto);
            }

        }
        private static void LaunchMagicItems(Item lookInto)
        {
            if (new List<string> { "Cartographer's Map Case", "Coin of Decisionry", "Spyglass of Clairvoyance", "Revenant Double-Bladed Scimitar", "Tankard of Plenty", "Documancy Satchel", "Elder's Cartographer's Glossgraphy", "Hew", "Piercer", "\"Mithral Half Plate, +1\"", "Inquisitive's Goggles", "Lightbringer", "Bag of Bounty", "Propeller Helm", "Portfolio Keeper", "Restorative Ointment", "Rings of Shared Suffering", "Winter's Dark Bite", "Ring of Preferred Death", "Dragonguard", "Failed Experiment Wand", "Master's Amulet", "Shield of the Uven Rune", "Potion of Watchful Rest", "Potion of Comprehension", "Antitoxin", "Poisoner's Kit", "Herbalism Kit", "Alchemist's Supplies", "Alchemist's Fire (Flask)", "Vial of Acid", "Explorer's Pack", "Truth Serum", "Vial of Basic Poison", "Dust of the Mummy", "Blood of the Lycanthrope", "Torpor", "Dreamlily", "Thessaltoxin", "Dragon's Blood", "Wyvern Poison", "Purple Worm Poison", "Serpent Venom", "Pale Tincture", "Essence of Ether", "Midnight Tears", "Oil of Taggit", "Drow Poison", "Malice", "Burnt Othur Fumes" }.Contains(lookInto.Name)) LocalLaunch(lookInto.Name);
            else if (new List<string> { "Fernian Ash Focus", "Kythrian Manchineel Focus", "Lamannian Oak Focus", "Mabaran Ebony Focus", "Risian Pine Focus", "Shavarran Birch Focus" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:imbued-wood-focus");
            else if (new List<string> { "Doss Lute", "Fochlucan Bandore", "Mac-Fuirmidh Cittern", "Canaith Mandolin", "Cli Lyre", "Anstruth Harp", "\"Instruments of the Bards, +1" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:instrument-of-the-bards");
            else if (new List<string> { "Potion of Greater Healing", "Potion of Superior Healing", "Potion of Supreme Healing" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:instrument-of-the-bards");
            else if (new List<string> { "Potion of Hill Giant Strength", "Potion of Frost Giant Strength", "Potion of Stone Giant Strength", "Potion of Fire Giant Strength", "Potion of Cloud Giant Strength", "Potion of Storm Giant Strength" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:potion-of-giant-strength");
            else if (new List<string> { "Crawler Mucus" }.Contains(lookInto.Name)) Launch(@"https://www.dndbeyond.com/equipment/" + lookInto.Name.Replace(" ", "-").Replace("'", "") + "-contact");
            else if (new List<string> { "Assassin's Blood" }.Contains(lookInto.Name)) Launch(@"https://www.dndbeyond.com/equipment/" + lookInto.Name.Replace(" ", "-").Replace("'", "") + "-ingested");
            else if (new List<string> { "\"Armor, +1\"", "\"Armor, +2\"", "\"Armor, +3\"" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:armor-1-2-3");
            else if (new List<string> { "Uncommon Glamerweave" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:glamerweave");
            else if (new List<string> { "Piwafwi (Cloak of Elvenkind)" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:piwafwi");
            else if (new List<string> { "\"Vicious Rapier, +1\"" }.Contains(lookInto.Name)) Launch(@"https://www.dndbeyond.com/magic-items/vicious-weapon");
            else if (new List<string> { "Stone of Good Luck" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:luckstone");
            else if (new List<string> { "\"Rod of the Pact Keeper, +1\"", "\"Rod of the Pact Keeper, +2\"", "\"Rod of the Pact Keeper, +3\"", "\"Amulet of the Devout, +1\"", "\"Amulet of the Devout, +2\"", "\"Amulet of the Devout, +3\"", "\"Ammunition, +1\"", "\"Ammunition, +2\"", "\"Ammunition, +3\"", "\"Shield, +1\"", "\"Shield, +2\"", "\"Shield, +3\"", "\"Moon Sickle, +1\"", "\"Moon Sickle, +2\"", "\"Moon Sickle, +3\"", "Rhythm Maker's Drum", "\"Rhythm Maker’s Drum, +1\"", "\"Rhythm Maker’s Drum, +2\"", "\"Rhythm Maker’s Drum, +3\"", "\"Bloodwell Vial, +1\"", "\"Bloodwell Vial, +2\"", "\"Bloodwell Vial, +3\"", "\"Arcane Grimoire, +1\"", "\"Arcane Grimoire, +2\"", "\"Arcane Grimoire, +3\"", "\"All-Purpose Tool, +1\"", "\"All-Purpose Tool, +2\"", "\"All-Purpose Tool, +3\"" }.Contains(lookInto.Name)) Launch(@"http://dnd5e.wikidot.com/wondrous-items:" + lookInto.Name.Substring(1, lookInto.Name.IndexOf(",")).Replace(" ", "-").Replace("'", ""));
            else Launch(@"http://dnd5e.wikidot.com/wondrous-items:" + lookInto.Name.Replace(" ", "-").Replace("'", ""));
        }

        private static void LocalLaunch(string lookIntoName)
        {
            switch (lookIntoName)
            {
                case "Cartographer's Map Case":
                    Console.WriteLine("Your cartographer's map case can be used to generate special map identifying a shortcut. You can use your action to make a DC I 5 Wisdom (Perception) check, with a success revealing a map buried in your cartographer's map case noting a relevant shortcut. Your travel time is reduced by half while you follow that route.If you succeed at the check by 5 or more, the map includes notes on the terrain, granting you advantage on the next ability check you make to travel through the mapped area in the next hour. Once you use this feature, you cannot use it again until you finish a long rest.");
                    break;
                case "Elder's Cartographer's Glossgraphy":
                    Console.WriteLine("The elder cartographer's glossography grants advantage on Intelligence or Wisdom checks related to geographical features or locations.");
                    break;
                case "Coin of Decisionry":
                    Console.WriteLine("When you flip the coin, it always lands with the Acquisitions Incorporated sigil face down.and a message appears on the \"tails\" face. Roll a d4 on the following table to determine the message.\nd4\tDecision\n1\tLucrative\n2\tBrand Appeal\n3\tIndeterminate\n4\tRuinous\nThe coin has absolutely no divination abilities, and its results when you use it are random. But nobody else knows that. When a creature within 10 feet of you flips the coin (after having had its powerful prognostication powers dutifully explained), you can exert your will to control its operation as a bonus action, choosing the result that appears after it lands as a means of gently coercing the user toward a specific course of action. The creature flipping the coin can detect your manipulation with a successful DC 13 Wisdom(Insight) check.");
                    break;
                case "Spyglass of Clairvoyance":
                    Console.WriteLine("As an action, you can look through the spyglass of clairvoyance at a location within 1 mile of you that is obstructing your view, such as a mountain, castle, or forest. You must then succeed on a DC 15 Wisdom check using cartographer's tools to map the natural terrain found within three miles of that chosen point. You do not gain any knowledge of creatures, structures, or anything other than natural terrain. This property of the spyglass cannot be used again until the next dawn.");
                    break;
                case "Documancy Satchel":
                    Console.WriteLine("Allowing you to magically send and receive documents to and from Head Office through a special pouch. Your documancy satchel magically produces prewritten and signature-ready contracts at your request, covering most common contractual needs. It also occasionally produces sticky notes printed with useful information and inspirational quotes from Head Office.");
                    break;
                case "Piercer":
                    Console.WriteLine("Piercer is a rare magic item that requires attunement.The sword is a +1 shortsword, and a character attuned to the sword regains the maximum possible number of hit points from expended Hit Dice. However, the attuned character must eat twice as much food each day (a minimum of 2 pounds) to avoid exhaustion (see \"The Environment\" in chapter 8 of the Player's Handbook.)");
                    break;
                case "Portfolio Keeper":
                    Console.WriteLine("The portfolio keeper holds and organizes notes, brochures, and business cards bearing your contact information. It also has an inexhaustible supply of brochures related to your franchise's current branding scheme.\n\tWhen you meet someone for the first time, their details and a rough sketch are magically stored on a small parchment card in the portfolio keeper. You can access the details of any such stored card as a bonus action.");
                    break;
                case "Failed Experiment Wand":
                    Console.WriteLine("(requires attunement by a spellcaster)\n\tThis wand has 2 charges. While holding it, you can use an action to expend 1 or more of its charges to cast the either a green-flamed fireball or a blue lightning bolt at random (save DC 15) from it. For 1 charge, you cast the 3rd-level version of the spell. You can increase the spell slot level by one for each additional charge you expend.\n\tThe wand regains 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.");
                    break;
                case "Tankard of Plenty":
                    Console.WriteLine("This is a tankard of plenty.Speaking the command word(\"Illefarn\") while grasping the handle fills the tankard with three pints of rich dwarven ale. This power can be used up to three times per day.");
                    break;
                case "Revenant Double-Bladed Scimitar": break;
                case "Hew": break;
                case "Inquisitive's Goggles": break;
                case "Lightbringer": break;
                case "Bag of Bounty": break;
                case "Propeller Helm": break;
                case "Restorative Ointment": break;
                case "Rings of Shared Suffering": break;
                case "Winter's Dark Bite": break;
                case "Ring of Preferred Death": break;
                case "Dragonguard": break;
                case "Master's Amulet": break;
                case "Shield of the Uven Rune": break;
                case "Potion of Watchful Rest": break;
                case "Potion of Comprehension": break;
                case "Antitoxin": break;
                case "Poisoner's Kit": break;
                case "Herbalism Kit": break;
                case "Alchemist's Supplies": break;
                case "Alchemist's Fire (Flask)": break;
                case "Vial of Acid": break;
                case "Explorer's Pack": break;
                case "Truth Serum": break;
                case "Vial of Basic Poison": break;
                case "Dust of the Mummy": break;
                case "Blood of the Lycanthrope": break;
                case "Torpor": break;
                case "Dreamlily": break;
                case "Thessaltoxin": break;
                case "Dragon's Blood": break;
                case "Wyvern Poison": break;
                case "Purple Worm Poison": break;
                case "Serpent Venom": break;
                case "Pale Tincture": break;
                case "Essence of Ether": break;
                case "Midnight Tears": break;
                case "Oil of Taggit": break;
                case "Drow Poison": break;
                case "Malice": break;
                case "Burnt Othur Fumes": break;
            }
        }

        private static void FixMagicItems()
        {
            foreach(var lookInto in new List<string> { "Revenant Double-Bladed Scimitar", "Hew", "Inquisitive's Goggles", "Lightbringer", "Bag of Bounty", "Propeller Helm", "Restorative Ointment", "Rings of Shared Suffering", "Winter's Dark Bite", "Ring of Preferred Death", "Dragonguard", "Master's Amulet", "Shield of the Uven Rune", "Potion of Watchful Rest", "Potion of Comprehension", "Antitoxin", "Poisoner's Kit", "Herbalism Kit", "Alchemist's Supplies", "Alchemist's Fire (Flask)", "Vial of Acid", "Explorer's Pack", "Truth Serum", "Vial of Basic Poison", "Dust of the Mummy", "Blood of the Lycanthrope", "Torpor", "Dreamlily", "Thessaltoxin", "Dragon's Blood", "Wyvern Poison", "Purple Worm Poison", "Serpent Venom", "Pale Tincture", "Essence of Ether", "Midnight Tears", "Oil of Taggit", "Drow Poison", "Malice", "Burnt Othur Fumes" }) Launch(@"http://dnd5e.wikidot.com/search:site/q/" + lookInto.Replace(" ", "%20"));
            foreach (var lookInto in new List<string> { "Cartographer's Map Case", "Elder's Cartographer's Glossgraphy", "Coin of Decisionry", "Spyglass of Clairvoyance", "Documancy Satchel", "Piercer", "Portfolio Keeper", "Failed Experiment Wand", "Tankard of Plenty", }) Launch(@"http://dnd5e.wikidot.com/search:site/q/" + lookInto.Replace(" ", "%20"));
        }
        private static void Launch(string site) { Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", site); }

        private static void SetTavernUp(List<string> orderedCategories, string readLine)
        {
            int i;
            var wares = Drinks[orderedCategories[int.Parse(readLine)]];
            var inStock = new List<Drink>();
            var rand = new Random();

            if (wares.Count >= 10)
            {
                while (inStock.Count < 10)
                {
                    var temp = wares[rand.Next(0, wares.Count)];
                    if (!inStock.Contains(temp)) inStock.Add(temp);
                }
            }
            else inStock = wares;

            do
            {
                Console.Clear();
                i = 0;
                foreach (var ware in inStock) Console.WriteLine(i++ + ": " + ware.Stringify());

                var response = Console.ReadLine();
                if (!int.TryParse(response, out var respInt))
                {
                    Console.WriteLine("Leave? [Y/N]");
                    if (Console.ReadKey().Key == ConsoleKey.Y) break;
                }

                var lookInto = inStock[respInt];
                Console.WriteLine(lookInto);
            } while (true);

            AddToCurrentWares(wares);
        }

        private static void AddToCurrentWares(List<BaseItem> wares)
        {
            var currentWares = ReadJSON<BaseItem>(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\CurrentWares.txt");
            if (currentWares.ContainsKey(wares[0].Category)) currentWares[wares[0].Category] = wares;
            else currentWares.Add(wares[0].Category, wares);
            FileManipulation.WriteDictToTxt(currentWares, @"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\CurrentWares.txt");
        }
        private static void AddToCurrentWares(List<Item> wares)
        {
            var currentWares = ReadJSON<Item>(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\CurrentWares.txt");
            if (currentWares.ContainsKey(wares[0].Category)) currentWares[wares[0].Category] = wares;
            else currentWares.Add(wares[0].Category, wares);
            FileManipulation.WriteDictToTxt(currentWares, @"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\CurrentWares.txt");
        }
        private static void AddToCurrentWares(List<Drink> wares)
        {
            var currentWares = ReadJSON<Drink>(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\CurrentWares.txt");
            if (currentWares.ContainsKey(wares[0].Category)) currentWares[wares[0].Category] = wares;
            else currentWares.Add(wares[0].Category, wares);
            FileManipulation.WriteDictToTxt(currentWares, @"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\CurrentWares.txt");
        }

        internal static Dictionary<string, List<T>> ReadJSON<T>(string path)
        {
            if (!File.Exists(path)) return new Dictionary<string, List<T>>();
            var file = File.ReadAllText(path);
            return file == "" ? new Dictionary<string, List<T>>() : JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(JObject.Parse(file).ToString());
        }

        private static void MakingStores()
        {
            var txt = FileManipulation.ReadTxt(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\Shoppings.csv");
            var dict = new Dictionary<string, List<Item>>();
            var dictUnused = new Dictionary<string, List<Item>>();
            var tavern = new Dictionary<string, List<Drink>>();

            foreach (var VARIABLE in txt)
            {
                if (txt.First() == VARIABLE) continue;
                var splitArray = VARIABLE.Split(",");
                var split = new List<string>();
                var making = "";
                foreach (var word in splitArray)
                {
                    if (word.Contains("\"") && making != "")
                    {
                        making += word;
                        split.Add(making);
                        making = "";
                    }
                    else if (word.Contains("\"") || making != "") making += word + ",";
                    else split.Add(word);
                }
                if (split[0] == "Tavern") AddDrinkToDict(tavern, split);
                else if (new List<string> { "Metamagic", "", "Eldritch Invocations", "Feat", "Spells" }.Contains(split[0])) AddItemToDict(dictUnused, split);
                else AddItemToDict(dict, split);
            }

            FileManipulation.WriteDictToTxt(dict, @"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\Shoppings.txt");
            FileManipulation.WriteDictToTxt(tavern, @"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\Drinks.txt");
            FileManipulation.WriteDictToTxt(dictUnused, @"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\SaveForLater.txt");
        }

        private static void AddItemToDict(Dictionary<string, List<Item>> dict, List<string> split)
        {
            dict.TryAdd(split[0], new List<Item>());
            dict[split[0]].Add(new Item(split[0], split[1], split[2], split[3], split[4], split[5], split[6]));
        }
        private static void AddDrinkToDict(Dictionary<string, List<Drink>> dict, List<string> split)
        {
            dict.TryAdd(split[0], new List<Drink>());
            var drinks = FileManipulation.ReadTxt(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Store\Drinks.csv");
            var splitDList = new List<string>();

            foreach (var VARIABLE in drinks)
            {
                if (drinks.First() == VARIABLE) continue;
                var splitArray = VARIABLE.Split(",");
                var making = "";
                if (splitArray[0] != split[5] && !(split[5] == "\"Hop, Skip, & Go Naked\"" && splitArray[0] + "," + splitArray[1] + "," + splitArray[2] == "\"Hop, Skip, & Go Naked\"")) continue;
                foreach (var word in splitArray)
                {
                    if (word.Contains("\"") && making != "")
                    {
                        making += word;
                        splitDList.Add(making);
                        making = "";
                    }
                    else if (word == "\"Have you ever wondered what hell fire would taste like? Then fireball is for you! \"\"Man i chugged a quart of fireball before the dance and the guards were all over my ass as soon as i walked in.\"\" Best night ever!\"") splitDList.Add(word);
                    else if (word.Contains("\"") || making != "") making += word + ",";
                    else splitDList.Add(word);
                }
            }

            dict[split[0]].Add(new Drink(split[5], splitDList[1], splitDList[2], splitDList[3], splitDList[4], split[6]));
        }
    }
}