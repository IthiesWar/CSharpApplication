using System;
namespace StudentAdmission;
class Program{
    public static void Main(string[] args)
    {
        //Getting DefaultValues
        FileHandling.Create();
        Operation.DefaultValues();
        Operation.MainMenu();
        FileHandling.WriteToCsv();
     FileHandling.ReadFromCsv();
    }
}