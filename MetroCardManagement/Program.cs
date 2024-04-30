using System;
namespace MetroCardManagement;
class Program{
    public static void Main(string[] args)
    {
        //Creating File
        FileHandling.Create();
        //Default values for travelhistory
        Operation.DefaultTravelHistory();
        //Default value for Ticketfair
        Operation.DefaultTicketFair();
        //Main Menu
        Operation.MainMenu();
        //Default Values
        Operation.Default();
       FileHandling.WriteCsv();
       FileHandling.ReadCsv();
    }
}