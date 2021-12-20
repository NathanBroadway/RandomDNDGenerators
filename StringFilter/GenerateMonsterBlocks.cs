using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;
using SupportClasses;

namespace StringFilter
{
    class GenerateMonsterBlocks
    {
        static readonly Dictionary<string, List<string>> lookAt = new Dictionary<string, List<string>>();
        private static readonly List<string> _knownSkills = new List<string> { "Acrobatics", "Persuasion", "Intimidation", "Deception", "Performance", "Perception", "Insight", "Arcana", "Stealth", "Athletics", "Survival" };

        internal static void GenerateBlocks()
        {
            var count = 0;
            do
            {
                var rawFile = FileManipulation.ReadJSON("Critters");
                var returnFile = ParseLines(rawFile);
                FileManipulation.WriteDictToJson(returnFile, "Critters");
            } while (++count < 9);
        }

        private static Dictionary<string, Dictionary<string, object>> ParseLines(Dictionary<string, Dictionary<string, object>> monsters)
        {
            var newMonsters = new Dictionary<string, Dictionary<string, object>>();

            foreach (var monster in monsters)
            {
                var newMonster = new Dictionary<string, object>();
                foreach (var value in monster.Value)
                {
                    if (value.Key == "Excess")
                    {
                        foreach (var traits in (JArray)value.Value)
                        {
                            var splitLines = traits.ToString().Split(" ").ToList();
                            if (new List<string> { "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan" }.Contains(splitLines[0]) && (splitLines.Count > 1 && !new List<string> { "Huge Pike.", "Huge serpentine", "Large Shortsword.", "Huge Longsword." }.Contains(GetWords(splitLines, 2))))
                            {
                                newMonster.Add("Size", splitLines[0]);
                                Remove(splitLines, 1);
                            }
                            else if (new List<string>
                                {"fiend,", "fiend", "undead,", "humanoid","dragon,","construct,","fey,","plant,","elemental,","celestial,","ooze,","giant,","aberration,","monstrosity,"}.Contains(splitLines[0]))
                            {
                                newMonster.Add("Type", ToProper(splitLines[0].Trim(',')));
                                Remove(splitLines, 1);
                            }
                            else if (new List<string> { "(goblinoid)", "(bladeling)", "(crucian),", "(bladeling),", "(catfolk)," }.Contains(splitLines[0]))
                            {
                                newMonster.Add("Subtype", ToProper(splitLines[0].Trim('(', ')')));
                                Remove(splitLines, 1);
                            }
                            else if (new List<string> { "lawful", "neutral", "chaotic", "unaligned" }.Contains(splitLines[0]) || new List<string> { "any lawful", "any neutral", " any chaotic" }.Contains(GetWords(splitLines, 2)))
                            {
                                if (new List<string> { "neutral", "unaligned" }.Contains(splitLines[0]) && (splitLines.Count == 1 || !new List<string> { "good", "evil" }.Contains(splitLines[1]))) newMonster.Add("Alignment", ToProper(splitLines[0]));
                                else if (new List<string> { "any lawful", "any neutral", " any chaotic" }.Contains(GetWords(splitLines, 2)))
                                {
                                    newMonster.Add("Alignment", GetWords(splitLines, 3));
                                    Remove(splitLines, 2);
                                }
                                else
                                {
                                    newMonster.Add("Alignment", ToProper(splitLines[0]) + " " + ToProper(splitLines[1]));
                                    Remove(splitLines, 1);
                                }

                                Remove(splitLines, 1);
                            }
                            else if (splitLines[0] == "Armor")
                            {
                                newMonster.Add("AC", splitLines[2]);
                                Remove(splitLines, 3);
                                if (splitLines[0].Contains('(')) GetACNotes(splitLines, newMonster);
                            }
                            else if (new List<string> { "Hit Points" }.Contains(GetWords(splitLines, 2)))
                            {
                                Remove(splitLines, 2);
                                newMonster.Add("HP", splitLines[0]);
                                Remove(splitLines, 1);
                                if (splitLines[0].Contains('(')) GetHPDice(splitLines, newMonster);
                            }
                            else if (new List<string> { "Speed" }.Contains(splitLines[0]))
                            {
                                newMonster.Add("Walking", splitLines[1]);
                                Remove(splitLines, 3);
                            }
                            else if (new List<string> { "fly", "climb", "burrow", "swim" }.Contains(splitLines[0]))
                            {
                                newMonster.Add(ToProper(splitLines[0]) + splitLines[0] == "swim" ? "m" : "" + "ing", splitLines[1]);
                                Remove(splitLines, 3);
                                if (splitLines.Count > 0 && splitLines[0] == "(hover)")
                                {
                                    newMonster.Add("Hovering", newMonster["Flying"]);
                                    newMonster.Remove("Flying");
                                    Remove(splitLines, 1);
                                }
                            }
                            else if (new List<string> { "STR", "DEX", "CON", "WIS", "INT", "CHA" }.Contains(splitLines[0]))
                            {
                                newMonster.Add(splitLines[0], splitLines[1]);
                                Remove(splitLines, 3);
                            }
                            else if (new List<string> { "Damage Immunities", "Damage Resistances", "Condition Immunities", "Damage Vulnerabilities" }.Contains(GetWords(splitLines, 2))) GetVRI(splitLines, newMonster, GetWords(splitLines, 2));
                            else if (new List<string> { "frightened,", "paralyzed,", "poisoned,", "unconscious," }.Contains(GetWords(splitLines, 1))) GetVRI(splitLines, newMonster, "Condition Immunities");
                            else if (new List<string> { "Senses" }.Contains(splitLines[0]))
                            {
                                Remove(splitLines, 1);
                                newMonster.Add("Senses", new Dictionary<string, int>());

                                var count = 0;
                                var sense = "";
                                foreach (var word in splitLines)
                                {
                                    switch (word)
                                    {
                                        case "darkvision":
                                            sense = word;
                                            count++;
                                            break;
                                        case "passive":
                                            count++;
                                            break;
                                        case "Perception":
                                            sense = word;
                                            count++;
                                            break;
                                        case "Blindsight":
                                            sense = word;
                                            count++;
                                            break;
                                        case "Tremorsense":
                                            sense = word;
                                            count++;
                                            break;
                                        case "Truesight":
                                            sense = word;
                                            count++;
                                            break;
                                        default:
                                            switch (sense)
                                            {
                                                case "darkvision":
                                                    ((Dictionary<string, int>)newMonster["Senses"]).Add(sense,
                                                        int.Parse(word));
                                                    sense = "";
                                                    count += 2;
                                                    break;
                                                case "Perception":
                                                    ((Dictionary<string, int>)newMonster["Senses"]).Add(
                                                        "passive " + sense, int.Parse(word));
                                                    sense = "";
                                                    count++;
                                                    break;
                                                default:
                                                    break;
                                            }

                                            break;
                                    }

                                }

                                for (var i = 0; i < count; i++) Remove(splitLines, 1);
                            }
                            else if (new List<string> { "Languages" }.Contains(splitLines[0]))
                            {
                                Remove(splitLines, 1);
                                GetLanguages(newMonster, splitLines);
                            }
                            else if (new List<string> { "Infernal", "Abyssal", "Feline" }.Contains(splitLines[0])) GetLanguages(newMonster, splitLines);
                            else if (new List<string> { "Challenge" }.Contains(splitLines[0]))
                            {
                                Remove(splitLines, 1);
                                GetCR(splitLines[0], newMonster);
                                Remove(splitLines, 3);
                            }
                            else if (new List<string> { "Tools" }.Contains(splitLines[0]))
                            {
                                Remove(splitLines, 1);
                                var exit = false;
                                var line = "";
                                do
                                {
                                    if (new List<string> { "Senses", "Damage" }.Contains(splitLines[1])) exit = true;
                                    line += splitLines[0] + " ";
                                    Remove(splitLines, 1);
                                } while (!exit);
                                newMonster.TryAdd("Tools", line);
                            }
                            else if (new List<string> { "Spider Climb.", "Magic Resistance.", "Undead Fortitude.", "Sunlight Hypersensitivity.", "Magic Weapons.", "Immutable Form." }.Contains(GetWords(splitLines, 2)))
                            {
                                newMonster.TryAdd("Shorthand Abilities", new JArray());
                                ((JArray)newMonster["Shorthand Abilities"]).Add(GetWords(splitLines, 2));
                                var dotCount = 1;
                                if (new List<string> { "Undead Fortitude.", "Sunlight Hypersensitivity." }.Contains(GetWords(splitLines, 2))) dotCount = 2;
                                Remove(splitLines, 2);
                                do
                                {
                                    if (splitLines[0].Last() == '.') dotCount--;
                                    Remove(splitLines, 1);
                                } while (dotCount > 0);
                            }
                            else if (new List<string> { "Actions" }.Contains(splitLines[0]))
                            {
                                newMonster.TryAdd("Actions", new List<object>());
                                Remove(splitLines, 1);
                            }
                            else if (new List<string> { "Multiattack." }.Contains(splitLines[0]))
                            {
                                var line = "";
                                Remove(splitLines, 1);
                                var exit = false;
                                do
                                {
                                    if (splitLines[0].Last() == '.') exit = true;
                                    line += splitLines[0] + " ";
                                    Remove(splitLines, 1);
                                } while (!exit && splitLines.Count > 0);
                                newMonster.TryAdd("Actions", new List<object>());
                                ((List<object>)newMonster["Actions"]).Add(line.Trim());
                            }
                            else if (new List<string> { "Bonedrink.", "Claw.", "Maul.", "Tentacle.", "Spiralling Presence.", "Distorting Breath.", "Impale.", "Swallow.", "Filament.", "Spikes.", "Shriek.", "Dart", "Tentacles.", "Bite.", "Pseudopods.", "Claws.", "Scimitar.", "Shortbow.", "Rapier.", "Longsword.", "Blowgun.", "Longswords.", "Fist.", "Firethrow.", "Tail.", "Rock.", "Slam.", "Sack." }.Contains(splitLines[0]) || new List<string> { "Throat Dart.", "Voracious Acid.", "Paralyzing Breath", "Scorching Burst", "Necrotic Aura.", "Razor Storm", "Dart Salvo", "Flame Burst.", "Stinking Gob.", "Absorb Duplicate.", "Shadow Step.", "Unarmed Strike.", "Frightful Presence.", "Black Cloud.", "Freezing Blast.", "Arcane Surge", "Caustic Cloud", "Lightning Blast.", "Frost Staff.", "Corrosive Touch.", "Burning Touch.", "Necrotic Blast." }.Contains(GetWords(splitLines, 2)) || new List<string> { "Touch of Madness.", "Blizzard (Recharge 4–6)." }.Contains(GetWords(splitLines, 3))) GetActions(splitLines, newMonster, "", "Actions");
                            else if (new List<string> { "Pincers." }.Contains(splitLines[0]) || new List<string> { }.Contains(GetWords(splitLines, 2)) || new List<string> { }.Contains(GetWords(splitLines, 3))) GetActions(splitLines, newMonster, "damage.", "Actions");
                            else if (new List<string> { "Scatter Intruders" }.Contains(splitLines[0]) || new List<string> { }.Contains(GetWords(splitLines, 2)) || new List<string> { }.Contains(GetWords(splitLines, 3))) GetActions(splitLines, newMonster, "object.", "Actions");
                            else if (new List<string> { "Skills" }.Contains(splitLines[0]))
                            {
                                Remove(splitLines, 1);
                                GetSkills(splitLines, newMonster);
                            }
                            else if (new List<string> { "Legendary" }.Contains(splitLines[0]))
                            {
                                var legendaryActions = CompleteLine(splitLines).Trim();
                                Remove(splitLines, (byte)splitLines.Count);
                                newMonster.Add("Legendary Actions", legendaryActions);
                            }
                            else if (_knownSkills.Contains(splitLines[0])) GetSkills(splitLines, newMonster);
                            else if (new List<string> { "Babble.", "Withdraw.", "Multilimbed.", "Bloodthirst.", "Unreliable.", "Camouflage.", "Briarstride.", "Pounce.", "Quickness.", "Amorphous.", "Spellcasting.", "Dweomersight." }.Contains(splitLines[0]) || new List<string> { "Scatter Intruders", "Ethereal Sight.", "Innate Spellcasting.", "Flyby Attack.", "Incorporeal Movement.", "Perfect Symmetry.", "Arcane Surge", "Shadow Stealth.", "Drag Away.", "Singing Bones.", "Toxic Filament.", "Volatile Blood.", "Blowgun Flute.", "Resonant Connection.", "Deadly Attack.", "Elusive Prey.", "Bardic Inspiration", "Burning Blood.", "No Passing.", "Dimensional Rift.", "Savannah Stalker.", "Forest Camouflage.", "Duplication (Psionics).", "Sylvan Warrior.", "Ruin Camouflage.", "Death Gaze.", "Cooperative Magic.", "Quick Reaction.", "Boggoul Bile.", "Distracting Frenzy" }.Contains(GetWords(splitLines, 2)) || new List<string> { "Mind of Madness.", "Elude Chance (3/Day).", "Immunity to Illusion.", "Wind of Death.", "Duplicate Pack Tactics." }.Contains(GetWords(splitLines, 3))) GetActions(splitLines, newMonster, "target.", "Abilities");
                            else if (traits.ToString().Length > 1000)
                            {
                                newMonster.Add("Detail", traits.ToString());
                                continue;
                            }
                            newMonster.TryAdd("Excess", new List<string>());
                            var excess = CompleteLine(splitLines).Trim();
                            if (excess != "")
                            {
                                lookAt.TryAdd(monster.Key, new List<string>());
                                lookAt[monster.Key].Add(excess);
                                ((List<string>)newMonster["Excess"]).Add(excess);
                            }
                        }
                    }
                    else
                    {
                        if (new List<string> { "Actions", "Abilities", "Shorthand Abilities" }.Contains(value.Key))
                        {
                            var val = (JArray)value.Value;
                            switch (val.Count > 0)
                            {
                                case true when newMonster.ContainsKey(value.Key):
                                    {
                                        foreach (var v in val) ((JArray)newMonster[value.Key]).Add(v);
                                        break;
                                    }
                                case true:
                                    newMonster.Add(value.Key, value.Value);
                                    break;
                            }
                        }
                        else if (value.Key == "Skills")
                        {
                            var val = (JObject)value.Value;
                            switch (val.Count > 0)
                            {
                                case true when newMonster.ContainsKey(value.Key):
                                    {
                                        foreach (var (key, jToken) in val) ((Dictionary<string, int>)newMonster[value.Key]).Add(key, jToken.Value<int>());
                                        break;
                                    }
                                case true:
                                    newMonster.Add(value.Key, value.Value);
                                    break;
                            }
                        }
                        else if (value.Key == "CR")
                        {
                            if (new List<string> { "System.Int64", "System.Double" }.Contains(value.Value.GetType().ToString())) newMonster.Add(value.Key, value.Value);
                            else GetCR(((JArray)value.Value)[0].ToString(), newMonster);
                        }
                        else if (new List<string> { "Languages", "Condition Immunities" }.Contains(value.Key))
                        {
                            var val = (JArray)value.Value;
                            switch (val.Count > 0)
                            {
                                case true when newMonster.ContainsKey(value.Key):
                                    {
                                        foreach (var v in val) ((JArray)newMonster[value.Key]).Add(v);
                                        break;
                                    }
                                case true:
                                    newMonster.Add(value.Key, value.Value);
                                    break;
                            }
                        }
                        else
                        {
                            if (value.Value.GetType().ToString() == "System.String")
                            {
                                if (int.TryParse(value.Value.ToString(), out var score)) newMonster.Add(value.Key, score);
                                else newMonster.Add(value.Key, value.Value.ToString().Trim(' ', ',', ';'));
                            }
                            else newMonster.Add(value.Key, value.Value);
                        }
                    }
                }
                newMonsters.Add(monster.Key, newMonster);
            }
            if (lookAt.Count > 0) Debugger.Break();
            return newMonsters;
        }

        private static void Remove(List<string> splitLines, byte num) { for (var i = 0; i < num; i++) splitLines.Remove(splitLines[0]); }

        private static void GetCR(string splitLines, Dictionary<string, object> newMonster)
        {
            switch (splitLines)
            {
                case "1/2":
                    newMonster.Add("CR", 0.5);
                    break;
                case "1/4":
                    newMonster.Add("CR", 0.25);
                    break;
                case "1/8":
                    newMonster.Add("CR", 0.16);
                    break;
                default:
                    newMonster.Add("CR", int.Parse(splitLines));
                    break;
            }
        }

        private static void GetLanguages(Dictionary<string, object> newMonster, List<string> splitLines)
        {
            newMonster.TryAdd("Languages", new JArray());
            while (splitLines.Count > 0 && splitLines[0] != "Challenge")
            {
                if (GetWords(splitLines, 2) == "Deep Speech")
                {
                    ((JArray)newMonster["Languages"]).Add(GetWords(splitLines, 2));
                    Remove(splitLines, 1);
                }
                else ((JArray)newMonster["Languages"]).Add(splitLines[0].Trim(','));
                Remove(splitLines, 1);
            }
        }

        private static void GetActions(List<string> splitLines, Dictionary<string, object> newMonster, string stopAt, string key)
        {
            var line = "";
            var exit = false;
            var excessDot = 0;
            do
            {
                if (stopAt == "" && line.Count(x => x == '.') - excessDot > 1 && splitLines[0].Contains('.') && splitLines.Count > 1) Debugger.Break();
                if (new List<string> { "ft.,", "target." }.Contains(splitLines[0])) excessDot++;
                if (splitLines[0] == stopAt) exit = true;
                line += splitLines[0] + " ";
                Remove(splitLines, 1);
            } while (!exit && splitLines.Count > 0);

            newMonster.TryAdd(key, new JArray());
            ((JArray)newMonster[key]).Add(line.Trim());
        }

        private static void GetSkills(List<string> splitLines, Dictionary<string, object> newMonster)
        {
            var skills = new Dictionary<string, int>();
            while (_knownSkills.Contains(splitLines[0]))
            {
                skills.Add(splitLines[0], int.Parse(splitLines[1][1..].Trim(',')));
                Remove(splitLines, 2);
            }

            newMonster.TryAdd("Skills", skills);
        }

        private static string GetWords(List<string> splitLines, int num)
        {
            var returnWords = "";
            for (var i = 0; i < num; i++) if (splitLines.Count > num) returnWords += " " + splitLines[i];
            return returnWords.Trim();
        }

        private static string ToProper(string word) { return word[0].ToString().ToUpper() + word[1..].ToLower(); }

        private static Dictionary<string, List<string>> ParseLines(string[] lines)
        {
            var newMonster = new Dictionary<string, List<string>>();
            var currentMonster = "";
            foreach (var line in lines)
            {
                if (line == "") continue;
                var splitLines = line.Split(" ");
                if (splitLines.Length == 1)
                {
                    if (splitLines[0] == "Actions" || int.TryParse(splitLines[0], out var result)) continue;
                    currentMonster = splitLines[0];
                    newMonster.Add(currentMonster, new List<string>());
                }
                else
                {
                    newMonster[currentMonster].Add(CompleteLine(splitLines).Trim());
                }
            }

            return newMonster;
        }

        private static string CompleteLine(IEnumerable<string> splitLines) { return splitLines.Aggregate("", (current, lineS) => current + (lineS + " ")); }

        private static void GetVRI(List<string> splitLines, Dictionary<string, object> newMonster, string key)
        {
            if (new List<string> { "Damage Immunities", "Damage Resistances", "Condition Immunities", "Damage Vulnerabilities" }.Contains(GetWords(splitLines, 2))) Remove(splitLines, 2);

            newMonster.Add(key, new JArray { splitLines[0] });
            Remove(splitLines, 1);

            var count = 0;
            foreach (var word in splitLines)
            {
                var temp = word[0];
                if (temp.ToString() == word[0].ToString().ToUpper()) break;
                ((JArray)newMonster[key]).Add(word);
                count++;
            }

            for (var i = 0; i < count; i++) Remove(splitLines, 1);
        }

        private static void GetHPDice(List<string> splitLines, Dictionary<string, object> newMonster)
        {
            var count = 0;
            foreach (var word in splitLines)
            {
                count++;
                if (word.Contains(")")) break;
            }

            var acNotes = "";
            for (var i = 0; i < count; i++)
            {
                acNotes += splitLines[0] + " ";
                Remove(splitLines, 1);
            }

            newMonster.Add("HP Rolls", acNotes);
        }

        private static void GetACNotes(List<string> splitLines, Dictionary<string, object> newMonster)
        {
            var count = 0;
            foreach (var word in splitLines)
            {
                count++;
                if (word.Contains(")")) break;
            }

            var acNotes = "";
            for (var i = 0; i < count; i++)
            {
                acNotes += splitLines[0] + " ";
                Remove(splitLines, 1);
            }

            newMonster.Add("AC Notes", acNotes);
        }
    }
}
