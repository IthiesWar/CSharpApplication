using System;
using System.IO;
namespace QwickFoodz;
class Program
{
    public static void Main(string[] args)
    {
        //File Creation
        FileHandling.Create();
        //Main Menu
        Operation.DefaultFoodItem();
        Operation.MainMenu();
        Operation.DefaultValues();
        FileHandling.WriteCsv();
        FileHandling.ReadCsv();

    }
}