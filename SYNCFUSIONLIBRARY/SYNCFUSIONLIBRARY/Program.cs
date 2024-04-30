using System;
namespace SYNCFUSIONLIBRARY;
class Program
{
    public static void Main(string[] args)
    {   FileHandling.Create();
        //Geting Default data
        //Operations.DefaultData();
        //Getting MainMenu
        Operations.MainMenu();
        FileHandling.WriteCsv();
        //Getting Submenu()
        Operations.SubMenu();
        FileHandling.ReadCsv();
    }
}