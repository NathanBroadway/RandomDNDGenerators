using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SupportClasses
{
    public class FileManipulation
    {
        public static void WriteStringToTxt(IEnumerable<string> lines, string path)
        {
            using TextWriter tw = new StreamWriter(@"..\..\..\Files\" + path + ".txt");
            foreach (var s in lines) tw.WriteLine(s);
        }

        public static string[] ReadTxt(string path)
        {
            return path.Contains("\\") ? File.ReadAllLines(path) : File.ReadAllLines(@"..\..\..\Files\" + path + ".txt");
        }

        public static Dictionary<string, Dictionary<string, object>> ReadJSON(string path)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(JObject.Parse(File.ReadAllText(@"..\..\..\Files\" + path + ".json")).ToString());
        }

        public static void WriteDictToTxt(Dictionary<string, Dictionary<string, object>> monsters, string path)
        {
            var thing = JsonConvert.SerializeObject(monsters);
            File.WriteAllText(@"..\..\..\Files\" + path + ".txt", thing);
        }

        public static void WriteDictToJson(Dictionary<string, Dictionary<string, object>> monsters, string path)
        {
            var thing = JsonConvert.SerializeObject(monsters);
            var pass = true;
            do
            {
                try
                {
                    File.WriteAllText(@"..\..\..\Files\" + path + ".json", thing);
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            } while (!pass);
        }

        public static void WriteDictToTxt<T>(Dictionary<string, List<T>> monsters, string path)
        {
            var thing = JsonConvert.SerializeObject(monsters);
            File.WriteAllText(path, thing);
        }
    }
}