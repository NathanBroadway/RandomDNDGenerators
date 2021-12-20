using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
var            txt = ReadTxt(@"C:\Users\Nathaniel.Broadway\source\Personal\StringFilter\Shopping\Shoppings.csv");
var dict = new System.Collections.Generic.Dictionary<string, object>();
foreach (var VARIABLE in txt)
{
    var split = VARIABLE.Split(",");
    
}
        }

        internal static string[] ReadTxt(string path) { return File.ReadAllLines(path); }
    }
}
