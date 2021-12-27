using System;
using Store;

namespace StringFilter
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            bool exit;
            do
            {
                exit = false;
                Console.WriteLine("How may I help you?\n[1] Random Effects?\n[2] Monster Blocks?\n[3] Store?\n[x] Exit");
                //var task = Console.ReadLine()?.ToLower();
                var task = "2";
                switch (task)
                {
                    case "randomeffects":
                    case "random":
                    case "effcts":
                    case "1":
                        RandomEffects.GetRandomEffects();
                        break;
                    case "monster":
                    case "monsterblocks":
                    case "blocks":
                    case "block":
                    case "2":
                        GenerateMonsterBlocks.GenerateBlocks();
                        break;
                    case "store":
                    case "3":
                        FullStore.EnterStore();
                        break;
                    case "exit":
                    case "x":
                        exit = true;
                        break;
                    default:
                        break;
                }

                exit = true;
            } while (!exit);
        }
    }
}