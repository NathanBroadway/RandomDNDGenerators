using System;
using System.Collections.Generic;
using System.Linq;
using StringFilter;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                AccessClassDetails();
                Console.Clear();
                Console.WriteLine("Look at Class Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessClassDetails()
        {
            var title = "Class Detail";
            var input = AskForInput(title, new List<string> { "Spell Effects", "Sorcerer Effects", "Artificer Effects", "Barbarian Effects", "Druid Effects", "Monk Effects", "Ranger Effects", "Warlock Effects" }, "Effects");
            switch (input)
            {
                case "Spell Effects":
                    AccessSpells();
                    break;
                case "Sorcerer Effects":
                    AccessSorcerer();
                    break;
                case "Artificer Effects":
                    AccessArtificer();
                    break;
                case "Barbarian Effects":
                    AccessBarbarian();
                    break;
                case "Druid Effects":
                    AccessDruid();
                    break;
                case "Monk Effects":
                    AccessMonk();
                    break;
                case "Ranger Effects":
                    AccessRanger();
                    break;
                case "Warlock Effects":
                    AccessWarlock();
                    break;
            }
        }

        private static void AccessWarlock()
        {
            do
            {
                Console.Clear();
                var title = "Warlock";
                var input = AskForInput(title, new List<string> { "Genie Kind Table", "Genie's Vessel Table" }, "Table");
                switch (input)
                {
                    case "Genie Kind Table":
                        Console.WriteLine(GetFromList(new List<string> { "Dao - Earth", "Djinni - Air", "Efreeti - Fire", "Marid - Water" }));
                        break;
                    case "Genie's Vessel Table":
                        Console.WriteLine(GetFromList(new List<string> { "Oil Lamp", "Urn", "Ring with a compartment", "Stoppered bottle", "Hollow statuette", "Ornate lantern" }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessRanger()
        {
            do
            {
                Console.Clear();
                const string title = "Ranger";
                var input = AskForInput(title, new List<string> { "Drakewarden Origin Table", "Feywild Gifts Table", "Swarm Appearance Table" }, "Table");
                switch (input)
                {

                    case "Drakewarden Origin Table":
                        Console.WriteLine(GetFromList(new List<string> { "You studied a dragon’s scale or claw, or a trinket from its hoard, and created your bond through the token’s lingering draconic magic.", "A secret order of rangers who collect and guard draconic lore taught you their ways.", "A true dragon gave you a drake egg to care for. When it hatched, the drake bonded to you.", "You drank a few drops of dragon blood, forever infusing your nature magic with draconic power.", "An ancient Draconic inscription on a standing stone empowered you when you read it aloud.", "You had a vivid dream of a mysterious man, accompanied by seven yellow canaries, who warned you of impending doom. When you awoke, your drake was there, watching you." }));
                        break;
                    case "Feywild Gifts Table":
                        Console.WriteLine(GetFromList(new List<string> { "Illusory butterflies flutter around you while you take a short or long rest.", "Fresh, seasonal flowers sprout from your hair each dawn.", "You faintly smell of cinnamon, lavender, nutmeg, or another comforting herb or spice.", "Your shadow dances while no one is looking directly at it.", "Horns or antlers sprout from your head.", "Your skin and hair change color to match the season at each dawn." }));
                        break;
                    case "Swarm Appearance Table":
                        Console.WriteLine(GetFromList(new List<string> { "Swarming insects", "Miniature twig blights", "Fluttering birds", "Playful pixies" }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessMonk()
        {
            do
            {
                Console.Clear();
                const string title = "Monk";
                var input = AskForInput(title, new List<string> { "Merciful Mask Table", "Ascendant Dragon Origin Table" }, "Table");
                switch (input)
                {
                    case "Merciful Mask Table":
                        Console.WriteLine(GetFromList(new List<string> { "Raven", "Blank and white", "Crying visage", "Laughing visage", "Skull", "Butterfly" }));
                        break;
                    case "Ascendant Dragon Origin Table":
                        Console.WriteLine(GetFromList(new List<string> { "You honed your abilities by observing a dragon and aligning your ki with their world-altering power.", "A dragon personally took an active role in shaping your inner energy.", "You studied at a monastery that traces its teachings back centuries or more to a single dragon’s instruction.", "You spent long stretches meditating in the region of influence of an ancient dragon’s lair, absorbing its ambient magic.", "You found a scroll written in Draconic that contained inspiring new techniques.", "After a dream that featured a five-handed dragonborn you awoke with altered ki, reflecting the breaths of dragons." }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessDruid()
        {
            do
            {
                Console.Clear();
                const string title = "Druid";
                var input = AskForInput(title, new List<string> { "Star Map Table" }, "Table");
                switch (input)
                {
                    case "Star Map Table":
                        Console.WriteLine(GetFromList(new List<string> { "A scroll covered with depictions of constellations", "A stone tablet with fine holes drilled through it", "A speckled owlbear hide, tooled with raised marks", "A collection of maps bound in an ebony cover", "A crystal that projects starry patterns when placed before a light", "Glass disks that depict constellations" }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessBarbarian()
        {
            do
            {
                Console.Clear();
                const string title = "Barbarian";
                var input = AskForInput(title, new List<string> { "Origin of the Beast Table", "Wild Magic Table" }, "Table");
                switch (input)
                {
                    case "Origin of the Beast Table":
                        Console.WriteLine(GetFromList(new List<string> { "One of your parents is a lycanthrope, and you’ve inherited some of their curse.", "You are descended from an archdruid and inherited the ability to partially change shape.", "A fey spirit gifted you with the ability to adopt different bestial aspects.", "An ancient animal spirit dwells within you, allowing you to walk this path." }));
                        break;
                    case "Wild Magic Table":
                        Console.WriteLine(GetFromList(new List<string> { "Shadowy tendrils lash around you. Each creature of your choice that you can see within 30 feet of you must succeed on a Constitution saving throw or take 8 necrotic damage. You also gain 12 temporary hit points.", "You teleport up to 30 feet to an unoccupied space you can see. Until your rage ends, you can use this effect again on each of your turns as a bonus action.", "An intangible spirit, which looks like a flumph or a pixie (your choice), appears within 5 feet of one creature of your choice that you can see within 30 feet of you. At the end of the current turn, the spirit explodes, and each creature within 5 feet of it must succeed on a Dexterity saving throw or take 1 force damage. Until your rage ends, you can use this effect again, summoning another spirit, on each of your turns as a bonus action.", "Magic infuses one weapon of your choice that you are holding. Until your rage ends, the weapon’s damage type changes to force, and it gains the light and thrown properties, with a normal range of 20 feet and a long range of 60 feet. If the weapon leaves your hand, the weapon reappears in your hand at the end of the current turn.", "Whenever a creature hits you with an attack roll before your rage ends, that creature takes 6 force damage, as magic lashes out in retribution.", "Until your rage ends, you are surrounded by multi­colored, protective lights; you gain a +1 bonus to AC, and while within 10 feet of you, your allies gain the same bonus.", "Flowers and vines temporarily grow around you; until your rage ends, the ground within 15 feet of you is difficult terrain for your enemies.", "A bolt of light shoots from your chest. Another creature of your choice that you can see within 30 feet of you must succeed on a Constitution saving throw or take 4 radiant damage and be blinded until the start of your next turn. Until your rage ends, you can use this effect again on each of your turns as a bonus action." }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessArtificer()
        {
            do
            {
                Console.Clear();
                const string title = "Artificer";
                var input = AskForInput(title, new List<string> { "Experimental Elixir Table" }, "Table");
                switch (input)
                {
                    case "Experimental Elixir Table":
                        Console.WriteLine(GetFromList(new List<string> { "Healing. The drinker regains a number of hit points equal to 5 + your Intelligence modifier.", "Swiftness. The drinker’s walking speed increases by 10 feet for 1 hour.", "Resilience. The drinker gains a +1 bonus to AC for 10 minutes.", "Boldness. The drinker can add 3 to every attack roll and saving throw they make for the next minute.", "Flight. The drinker gains a flying speed of 10 feet for 10 minutes.", "Transformation. The drinker’s body is transformed as if by the alter self spell. The drinker determines the transformation caused by the spell, the effects of which last for 10 minutes." }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessSorcerer()
        {
            do
            {
                Console.Clear();
                const string title = "Sorcerer";
                var input = AskForInput(title, new List<string> { "Aberrant Origins Table", "Manifestations of Order Table", "Shadow Sorcerer Quirks Table", "Wild Magic Surge Table" }, "Table");
                switch (input)
                {
                    case "Aberrant Origins Table":
                        Console.WriteLine(GetFromList(new List<string> { "You were exposed to the Far Realm’s warping influence. You are convinced that a tentacle is now growing on you, but no one else can see it.", "A psychic wind from the Astral Plane carried psionic energy to you. When you use your powers, faint motes of light sparkle around you.", "You once suffered the dominating powers of an aboleth, leaving a psychic splinter in your mind.", "You were implanted with a mind flayer tadpole, but the ceremorphosis never completed. And now its psionic power is yours. When you use it, your flesh shines with a strange mucus.", "As a child, you had an imaginary friend that looked like a flumph or a strange platypus-like creature. One day, it gifted you with psionic powers, which have ended up being not so imaginary.", "Your nightmares whisper the truth to you: your psionic powers are not your own. You draw them from your parasitic twin!" }));
                        break;
                    case "Manifestations of Order Table":
                        Console.WriteLine(GetFromList(new List<string> { "Spectral cogwheels hover behind you.", "The hands of a clock spin in your eyes.", "Your skin glows with a brassy sheen.", "Floating equations and geometric objects overlay your body.", "Your spellcasting focus temporarily takes the form of a Tiny clockwork mechanism.", "The ticking of gears or ringing of a clock can be heard by you and those affected by your magic." }));
                        break;
                    case "Shadow Sorcerer Quirks Table":
                        Console.WriteLine(GetFromList(new List<string> { "You are always icy cold to the touch.", "When you are asleep, you don’t appear to breathe (though you must still breathe to survive).", "You barely bleed, even when badly injured.", "Your heart beats once per minute. This event sometimes surprises you.", "You have trouble remembering that living creatures and corpses should be treated differently.", "You blinked. Once. Last week." }));
                        break;
                    case "Wild Magic Surge Table":
                        Console.WriteLine(GetFromList(new List<string> { "Roll on this table at the start of each of your turns for the next minute, ignoring this result on subsequent rolls.", "For the next minute, you can see any invisible creature if you have line of sight to it.", "A modron chosen and controlled by the DM appears in an unoccupied space within 5 feet of you, then disappears 1 minute later.", "You cast fireball as a 3rd-level spell centered on yourself.", "You cast magic missile as a 5th-level spell.", "Your height changes by 4 inches. If the number is odd, you shrink. If the number is even, you grow.", "You cast confusion centered on yourself.", "For the next minute, you regain 5 hit points at the start of each of your turns.", "You grow a long beard made of feathers that remains until you sneeze, at which point the feathers explode out from your face.", "You cast grease centered on yourself.", "Creatures have disadvantage on saving throws against the next spell you cast in the next minute that involves a saving throw.", "Your skin turns a vibrant shade of blue. A remove curse spell can end this effect.", "An eye appears on your forehead for the next minute. During that time, you have advantage on Wisdom (Perception) checks that rely on sight.", "For the next minute, all your spells with a casting time of 1 action have a casting time of 1 bonus action.", "You teleport up to 60 feet to an unoccupied space of your choice that you can see.", "You are transported to the Astral Plane until the end of your next turn, after which time you return to the space you previously occupied or the nearest unoccupied space if that space is occupied.", "Maximize the damage of the next damaging spell you cast within the next minute.", "Your age changes by 10 years. If the number is odd, you get younger (minimum 1 year old). If the number is even, you get older.", "5 flumph(s) controlled by the DM appear in unoccupied spaces within 60 feet of you and are frightened of you. They vanish after 1 minute.", "You regain 12 hit points.", "You turn into a potted plant until the start of your next turn. While a plant, you are incapacitated and have vulnerability to all damage. If you drop to 0 hit points, your pot breaks, and your form reverts.", "For the next minute, you can teleport up to 20 feet as a bonus action on each of your turns.", "You cast levitate on yourself.", "A unicorn controlled by the DM appears in a space within 5 feet of you, then disappears 1 minute later.", "You can’t speak for the next minute. Whenever you try, pink bubbles float out of your mouth.", "A spectral shield hovers near you for the next minute, granting you a +2 bonus to AC and immunity to magic missile.", "You are immune to being intoxicated by alcohol for the next 13 days.", "Your hair falls out but grows back within 24 hours.", "For the next minute, any flammable object you touch that isn’t being worn or carried by another creature bursts into flame.", "You regain your lowest-level expended spell slot.", "For the next minute, you must shout when you speak.", "You cast fog cloud centered on yourself.", "Up to three creatures you choose within 30 feet of you take 24 lightning damage.", "You are frightened by the nearest creature until the end of your next turn.", "Each creature within 30 feet of you becomes invisible for the next minute. The invisibility ends on a creature when it attacks or casts a spell.", "You gain resistance to all damage for the next minute.", "A random creature within 60 feet of you becomes poisoned for 2 hour(s).", "You glow with bright light in a 30-foot radius for the next minute. Any creature that ends its turn within 5 feet of you is blinded until the end of its next turn.", "You cast polymorph on yourself. If you fail the saving throw, you turn into a sheep for the spell’s duration.", "Illusory butterflies and flower petals flutter in the air within 10 feet of you for the next minute.", "You can take one additional action immediately.", "Each creature within 30 feet of you takes 7 necrotic damage. You regain hit points equal to the sum of the necrotic damage dealt.", "You cast mirror image.", "You cast fly on a random creature within 60 feet of you.", "You become invisible for the next minute. During that time, other creatures can’t hear you. The invisibility ends if you attack or cast a spell.", "If you die within the next minute, you immediately come back to life as if by the reincarnate spell.", "Your size increases by one size category for the next minute.", "You and all creatures within 30 feet of you gain vulnerability to piercing damage for the next minute.", "You are surrounded by faint, ethereal music for the next minute.", "You regain all expended sorcery points." }));
                        break;
                }
                Console.WriteLine($"Look at {title} Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void AccessSpells()
        {
            do
            {
                Console.Clear();
                const string title = "Spells";
                var input = AskForInput(title, new List<string> { "Chaos Bolt", "Chromatic Orb", "Find Familiar", "Dragon's Breath", "Elemental Bane", "Reincarnation", "Conjure Minor Elementals", "Conjure Elemental", "Conjure Fey", "Conjure Celestial", "Conjure Greater Demon", "Animal Shapes", "Conjure Woodland Beings", "Conjure Animals", "Conjure Lesser Demons" }, "Conjure");
                List<string> listOfStrings;
                string damageType;
                Dictionary<string, string> dictOfMonsters;
                string monsterName;
                string numberConjured;

                switch (input)
                {
                    case "Chaos Bolt":
                        var damage1 = int.Parse(DiceRoller.RollDice("1d8"));
                        var damage2 = int.Parse(DiceRoller.RollDice("1d8"));
                        var damage3 = int.Parse(DiceRoller.RollDice("1d6"));
                        listOfStrings = new List<string> { "Acid", "Cold", "Fire", "Force", "Lightning", "Poison", "Psychic", "Thunder" };
                        Console.WriteLine($"You hurl an undulating, warbling mass of chaotic energy at one creature in with 120 feet. Make a ranged spell attack against the target. On a hit, the target takes {damage1 + damage2 + damage3} {(damage1 == damage2 ? listOfStrings[damage1 - 1] : $"{listOfStrings[damage1 - 1]} or {listOfStrings[damage2 - 1]}")} damage.");
                        break;
                    case "Chromatic Orb":
                        Console.WriteLine($"You hurl a 4-inch-diameter sphere of energy at a creature that you can see within range. Make a ranged spell attack against the target. If the attack hits, the creature takes {DiceRoller.RollDice("3d8")} {GetFromList(new List<string> { "Acid", "Cold", "Fire", "Lightning", "Poison", "Thunder" })} damage.");
                        break;
                    case "Find Familiar":
                        Console.WriteLine($"You gain the service of a familiar, a spirit that takes the form of an {GetFromList(new List<string> { "Celestial", "Fey", "Fiend" })} {GetFromList(new List<string> { "Bat", "Cat", "Crab", "Frog (Toad)", "Hawk", "Lizard", "Octopus", "Owl", "Poisonous Snake", "Quipper", "Rat", "Raven", "Sea Horse", "Spider", "Weasel" })}. Appearing in an unoccupied space within range, the familiar has the statistics of the chosen form.");
                        break;
                    case "Access Dragon's Breath":
                        damageType = GetFromList(new List<string> { "Acid", "Cold", "Fire", "Lightning", "Poison", "Acid", "Cold", "Fire", "Lightning", "Thunder" });
                        Console.WriteLine($"You touch one willing creature and imbue it with the power to spew magical energy from its mouth, provided it has one. Until the spell ends, the creature can use an action to exhale {damageType} in a 15-foot cone. Each creature in that area must make a Dexterity saving throw, taking {DiceRoller.RollDice("3d6")} {damageType} damage on a failed save, or half as much damage on a successful one.");
                        break;
                    case "Elemental Bane":
                        damageType = GetFromList(new List<string> { "Acid", "Cold", "Fire", "Lightning", "Thunder" });
                        Console.WriteLine($"Choose one creature you can see within range. The target must succeed on a Constitution saving throw or be affected by the spell for its duration. The first time each turn the affected target takes {damageType} damage, the target takes an extra {DiceRoller.RollDice("2d6")} {damageType} damage of that type. Moreover, the target loses any resistance to {damageType} damage type until the spell ends.");
                        break;
                    case "Reincarnation":
                        Console.WriteLine($"You touch a dead Humanoid or a piece of a dead Humanoid. Provided that the creature has been dead no longer than 10 days, the spell forms a new adult {GetFromList(new List<string> { "Dragonborn", "Hill Dwarf", "Mountain Dwarf", "Dark Elf", "High Elf", "Wood Elf", "Forest Gnome", "Rock Gnome", "Half-Elf", "Half-Orc", "Lightfoot Halfling", "Stout Halfling", "Human", "Tiefling" })} body for it and then calls the soul to enter that body. If the target's soul isn't free or willing to do so, the spell fails.\n\tThe reincarnated creature recalls its former life and experiences. It retains the capabilities it had in its original form, except it exchanges its original race for the new one and changes its racial Traits accordingly.");
                        break;
                    case "Conjure Minor Elementals":
                        dictOfMonsters = ListOfMonsters(MonsterTypes.elemental, "2");
                        monsterName = GetFromList(dictOfMonsters.Keys.ToList());
                        numberConjured = FindNumberConjured(dictOfMonsters[monsterName]);
                        Console.WriteLine($"You summon {numberConjured} {monsterName}{(numberConjured != "1" ? "s" : "")} that appear in unoccupied spaces that you can see within range.\n\tAn elemental summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\n\tThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.");
                        break;
                    case "Conjure Elemental":
                        Console.WriteLine($"You summon {GetFromList(ListOfMonsters(MonsterTypes.elemental, "5").Keys.ToList())} that appear in unoccupied spaces that you can see within range.\n\tAn elemental summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\n\tThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.");
                        break;
                    case "Conjure Fey":
                        listOfStrings = ListOfMonsters(MonsterTypes.fey, "5").Keys.ToList();
                        listOfStrings.AddRange(ListOfMonsters(MonsterTypes.beast, "5").Keys.ToList());
                        Console.WriteLine($"You summon a {GetFromList(listOfStrings)}. It appears in an unoccupied space that you can see within range. The fey creature disappears when it drops to 0 hit points or when the spell ends.\n\tThe fey creature is friendly to you and your companions for the duration. Roll initiative for the creature, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you), as long as they don't violate its alignment. If you don't issue any commands to the fey creature, it defends itself from hostile creatures but otherwise takes no actions.\n\tIf your concentration is broken, the fey creature doesn't disappear. Instead, you lose control of the fey creature, it becomes hostile toward you and your companions, and it might attack. An uncontrolled fey creature can't be dismissed by you, and it disappears 1 hour after you summoned it.");
                        break;
                    case "Conjure Celestial":
                        Console.WriteLine($"You summon a {GetFromList(ListOfMonsters(MonsterTypes.celestial, "4").Keys.ToList())}, which appears in an unoccupied space that you can see within range. The celestial disappears when it drops to 0 hit points or when the spell ends.\n\tThe celestial is friendly to you and your companions for the duration. Roll initiative for the celestial, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you), as long as they don't violate its alignment. If you don't issue any commands to the celestial, it defends itself from hostile creatures but otherwise takes no actions.");
                        break;
                    case "Conjure Greater Demon":
                        Console.WriteLine($"You utter foul words, summoning a {GetFromList(ListOfMonsters(MonsterTypes.demon, "4").Keys.ToList())} from the chaos of the Abyss. The demon appears in an unoccupied space you can see within range, and the demon disappears when it drops to 0 hit points or when the spell ends.\n\tRoll initiative for the demon, which has its own turns. When you summon it and on each of your turns thereafter, you can issue a verbal command to it (requiring no action on your part), telling it what it must do on its next turn. If you issue no command, it spends its turn attacking any creature within reach that has attacked it.\n\tAt the end of each of the demon’s turns, it makes a Charisma saving throw. The demon has disadvantage on this saving throw if you say its true name. On a failed save, the demon continues to obey you. On a successful save, your control of the demon ends for the rest of the duration, and the demon spends its turns pursuing and attacking the nearest non-demons to the best of its ability. If you stop concentrating on the spell before it reaches its full duration, an uncontrolled demon doesn’t disappear for 1d6 rounds if it still has hit points.\n\tAs part of casting the spell, you can form a circle on the ground with the blood used as a material component. The circle is large enough to encompass your space. While the spell lasts, the summoned demon can’t cross the circle or harm it, and it can’t target anyone within it. Using the material component in this manner consumes it when the spell ends.\n\tAt Higher Levels. When you cast this spell using a spell slot of 5th level or higher, the challenge rating increases by 1 for each slot level above 4th.");
                        break;
                    case "Animal Shapes":
                        Console.WriteLine($"Your magic turns others into Beasts. Choose any number of willing Creatures that you can see within range. You transform each target into the form of a {GetFromList(ListOfMonsters(MonsterTypes.beast, "4").Keys.ToList())}. On subsequent turns, you can use your Actions to transform affected Creatures into new forms.\n\tThe transformation lasts for the Duration for each target, or until the target drops to 0 Hit Points or dies. You can choose a different form for each target. A target's game Statistics are replaced by the Statistics of the chosen beast, though the target retains its Alignment and Intelligence, Wisdom, and Charisma scores. The target assumes the Hit Points of its new form, and when it reverts to its normal form, it returns to the number of hit point it had before it transformed. If it reverts as a result of dropping to 0 Hit Points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 Hit Points, it isn't knocked Unconscious. The creature is limited in the Actions it can perform by the Nature of its new form, and it can't speak or cast Spells.\n\tThe target's gear melds into the new form. The target can't activate, wield, or otherwise benefit from any of its Equipment.");
                        break;
                    case "Conjure Woodland Beings":
                        dictOfMonsters = ListOfMonsters(MonsterTypes.fey, "2");
                        monsterName = GetFromList(dictOfMonsters.Keys.ToList());
                        numberConjured = FindNumberConjured(dictOfMonsters[monsterName]);
                        Console.WriteLine($"You summon {numberConjured} {monsterName}{(numberConjured != "1" ? "s" : "")} that appear in unoccupied spaces that you can see within range.\n\tA fey summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\n\tThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.");
                        break;
                    case "Conjure Animals":
                        dictOfMonsters = ListOfMonsters(MonsterTypes.beast, "2");
                        monsterName = GetFromList(dictOfMonsters.Keys.ToList());
                        numberConjured = FindNumberConjured(dictOfMonsters[monsterName]);
                        Console.WriteLine($"You summon {numberConjured} {monsterName}{(numberConjured != "1" ? "s" : "")} that appear in unoccupied spaces that you can see within range.\n\tA beast summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\n\tThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.");
                        break;
                    case "Conjure Lesser Demons":
                        dictOfMonsters = ListOfMonsters(MonsterTypes.demon, "2");
                        monsterName = GetFromList(dictOfMonsters.Keys.ToList());
                        numberConjured = FindNumberConjured(dictOfMonsters[monsterName]);
                        Console.WriteLine($"You summon {numberConjured} {monsterName}{(numberConjured != "1" ? "s" : "")} that appear in unoccupied spaces that you can see within range.\n\tA demon summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\n\tThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.");
                        break;
                }
                Console.WriteLine("Look at Spell Detail? [Y/N]");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static string FindNumberConjured(string monsterCR)
        {
            switch (monsterCR)
            {
                case "2":
                    return "1";
                case "1":
                    return "2";
                case "1/2":
                    return "4";
                case "1/4":
                case "1/8":
                case "0":
                    return "8";
            }

            return monsterCR;
        }

        private enum MonsterTypes
        {
            beast = 1,
            celestial = 2,
            demon = 3,
            elemental = 4,
            fey = 5,
            fiend = 6
        }
        private static Dictionary<string, string> ListOfMonsters(MonsterTypes monsterType, string CR)
        {
            var listOfMonsters = new Dictionary<string, Dictionary<string, string>>
            {
                { "elemental", new Dictionary<string, string> {{ "Frost Salamander", "9"},{ "Big Xorn", "8"},{ "Air Elemental Myrmidon", "7"},{ "Earth Elemental Myrmidon", "7"},{ "Fire Elemental Myrmidon", "7"},{ "Fluxcharger", "7"},{ "Water Elemental Myrmidon", "7"},{ "Galeb Duhr", "6"},{ "Invisible Stalker", "6"},{ "Air Elemental", "5"},{ "Dust Devil", "5"},{ "Earth Elemental", "5"},{ "Fire Elemental", "5"},{ "Salamander", "5"},{ "Water Elemental", "5"},{ "Xorn", "5"},{ "Blistercoil Weird", "4"},{ "Poison Weird", "4"},{ "Flail Snail", "3"},{ "Water Weird", "3"},{ "Azer", "2"},{ "Four-Armed Gargoyle", "2"},{ "Gargoyle", "2"},{ "Lady Gondrafrey", "2"},{ "Fire Snake", "1"},{ "Galvanice Weird", "1"},{ "Dust Mephit", "1/2"},{ "Ice Mephit", "1/2"},{ "Magma Mephit", "1/2"},{ "Magmin", "1/2"},{ "Geonid", "1/4"},{ "Mud Mephit", "1/4"},{ "Smoke Mephit", "1/4"},{ "Steam Mephit", "1/4"},{ "Khargra", "1/8"},{ "Chwinga", "0"}}},
                { "fey", new Dictionary<string, string> { {"Korred", "7"}, {"Bheur Hag", "7"}, {"Annis Hag", "6"}, {"Yeth Hound", "4"}, {"Redcap", "3"}, {"Green Hag", "3"}, {"Sea Hag", "2"}, {"Meenlock", "2"}, {"Darkling Elder", "2"}, {"Quickling", "1"}, {"Dryad", "1"}, {"Satyr", "1/2"}, {"Darkling", "1/2"}, {"Sprite", "1/4"}, {"Pixie", "1/4"}, {"Blink Dog", "1/4"}, {"Boggle", "1/8"}, {"Fey Spirit", "0"}}},
                { "beast", new Dictionary<string, string> { { "Tyrannosaurus Rex", "8" }, { "Sperm Whale", "8" }, { "Giant Ape", "7" }, { "Mammoth", "6" }, { "Triceratops", "5" }, { "Swarm of Cranium Rats", "5" }, { "Giant Shark", "5" }, { "Giant Crocodile", "5" }, { "Giant Walrus", "4" }, { "Elephant", "4" }, { "Killer Whale", "3" }, { "Giant Scorpion", "3" }, { "Ankylosaurus", "3" }, { "Swarm of Poisonous Snakes", "2" }, { "Saber-Toothed Tiger", "2" }, { "Rhinoceros", "2" }, { "Quetzalcoatlus", "2" }, { "Polar Bear", "2" }, { "Plesiosaurus", "2" }, { "Hunter Shark", "2" }, { "Giant Elk", "2" }, { "Giant Constrictor Snake", "2" }, { "Giant Boar", "2" }, { "Aurochs", "2" }, { "Allosaurus", "2" }, { "Wild Dog Alpha", "1" }, { "Tiger", "1" }, { "Swarm of Quippers", "1" }, { "Lion", "1" }, { "Giant Vulture", "1" }, { "Giant Toad", "1" }, { "Giant Spider", "1" }, { "Giant Octopus", "1" }, { "Giant Hyena", "1" }, { "Giant Eagle", "1" }, { "Dire Wolf", "1" }, { "Brown Bear", "1" }, { "Warhorse", "1/2" }, { "Swarm of Rot Grubs", "1/2" }, { "Swarm of Insects", "1/2" }, { "Reef Shark", "1/2" }, { "Reef Manta Ray", "1/2" }, { "Giant Wasp", "1/2" }, { "Giant Two-Headed Goat", "1/2" }, { "Giant Sea Horse", "1/2" }, { "Giant Goat", "1/2" }, { "Crocodile", "1/2" }, { "Black Bear", "1/2" }, { "Ape", "1/2" }, { "Wolf", "1/4" }, { "Walrus", "1/4" }, { "Velociraptor", "1/4" }, { "Swarm of Ravens", "1/4" }, { "Swarm of Rats", "1/4" }, { "Swarm of Bats", "1/4" }, { "Riding Horse", "1/4" }, { "Pteranodon", "1/4" }, { "Panther", "1/4" }, { "Giant Wolf Spider", "1/4" }, { "Giant Poisonous Snake", "1/4" }, { "Giant Owl", "1/4" }, { "Giant Lizard", "1/4" }, { "Giant Frog", "1/4" }, { "Giant Centipede", "1/4" }, { "Giant Bat", "1/4" }, { "Giant Badger", "1/4" }, { "Elk", "1/4" }, { "Draft Horse", "1/4" }, { "Cow", "1/4" }, { "Constrictor Snake", "1/4" }, { "Boar", "1/4" }, { "Axe Beak", "1/4" }, { "Wild Dog", "1/8" }, { "Stirge", "1/8" }, { "Pony", "1/8" }, { "Poisonous Snake", "1/8" }, { "Mule", "1/8" }, { "Mountain Goat", "1/8" }, { "Mastiff", "1/8" }, { "Giant Weasel", "1/8" }, { "Giant Rat", "1/8" }, { "Giant Crab", "1/8" }, { "Flying Snake", "1/8" }, { "Dolphin", "1/8" }, { "Camel", "1/8" }, { "Blood Hawk", "1/8" }, { "Weasel", "0" }, { "Vulture", "0" }, { "Spider", "0" }, { "Seal", "0" }, { "Sea Horse", "0" }, { "Scorpion", "0" }, { "Raven", "0" }, { "Rat", "0" }, { "Quipper", "0" }, { "Owl", "0" }, { "Octopus", "0" }, { "Lizard", "0" }, { "Knucklehead Trout", "0" }, { "Jackal", "0" }, { "Hyena", "0" }, { "Hawk", "0" }, { "Hare", "0" }, { "Goat", "0" }, { "Giant Fire Beetle", "0" }, { "Frog", "0" }, { "Fox", "0" }, { "Eagle", "0" }, { "Deer", "0" }, { "Cranium Rat", "0" }, { "Crab", "0" }, { "Cat", "0" }, { "Bat", "0" }, { "Badger", "0" }, { "Baboon", "0" } }},
                { "celestial", new Dictionary<string, string> { {"Unicorn", "5"}, {"Couatl", "4"}, {"Pegasus", "2"}}},
                { "demon", new Dictionary<string, string> { {"Yochlol", "10"}, {"Glabrezu", "9"}, {"Shoosuva", "8"}, {"Hezrou", "8"}, {"Maurezhi", "7"}, {"Draegloth", "7"}, {"Armanite", "7"}, {"Vrock", "6"}, {"Chasme", "6"}, {"Tanarukk", "5"}, {"Barlgura", "5"}, {"Shadow Demon", "4"}, {"Dybbuk", "4"}, {"Babau", "4"}, {"Bulezau", "3"}, {"Rutterkin", "2"}, {"Quasit", "1"}, {"Maw Demon", "1"}, {"Dretch", "1/4"}, {"Manes", "1/8"}}}
            };

            var listOfStrings = listOfMonsters[monsterType.ToString()];
            listOfStrings = CR switch
            {
                "1/2" => listOfStrings.Where(x => new List<string> { "0", "1/4", "1/8", "1/2" }.Contains(x.Value)).ToDictionary(x => x.Key, x => x.Value),
                "1/4" => listOfStrings.Where(x => new List<string> { "0", "1/4", "1/8" }.Contains(x.Value)).ToDictionary(x => x.Key, x => x.Value),
                "1/8" => listOfStrings.Where(x => new List<string> { "0", "1/8" }.Contains(x.Value)).ToDictionary(x => x.Key, x => x.Value),
                _ => listOfStrings.Where(x => new List<string> { "0", "1/4", "1/8", "1/2" }.Contains(x.Value) || int.Parse(CR) >= int.Parse(x.Value)).ToDictionary(x => x.Key, x => x.Value)
            };

            return listOfStrings;
        }

        private static string AskForInput(string title, IReadOnlyList<string> listOfOptions, string filterOut = "")
        {
            listOfOptions = listOfOptions.OrderBy(x => x).ToList();
            var stringToReturn = "";
            Console.Clear();
            do
            {
                Console.WriteLine($"What would you like to do with the {title} options?");
                var dictOfOptions = new Dictionary<string, List<string>>();
                for (var i = 0; i < listOfOptions.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] Access {listOfOptions[i]}");
                    dictOfOptions.Add(listOfOptions[i], listOfOptions[i].ToLower().Split(" ").ToList());
                    dictOfOptions[listOfOptions[i]].Add($"{i + 1}");
                }
                Console.Write("Input: ");
                var originalResponse = Console.ReadLine();
                var response = originalResponse.ToLower().Replace(filterOut.ToLower(), "").Trim().Split(" ").ToList();
                if (dictOfOptions.ContainsKey(originalResponse)) return originalResponse;

                foreach (var (key, value) in dictOfOptions)
                {
                    if (string.Join(" ", value.ToArray()) == originalResponse.ToLower())
                    {
                        stringToReturn = originalResponse;
                        break;
                    }

                    if (value.Any(x => response.Contains(x)) && stringToReturn == "") stringToReturn = key;
                    else if (value.Any(x => response.Contains(x)))
                    {
                        stringToReturn = "";
                        break;
                    }
                }

                Console.Clear();
                if (stringToReturn != "") continue;
                Console.WriteLine($"Error in Input: {originalResponse} is invalid.");
            } while (stringToReturn == "");

            return stringToReturn;
        }

        private static string GetFromList(List<string> listOfStrings)
        {
            return listOfStrings[new Random().Next(0, listOfStrings.Count - 1)];
        }
    }
}