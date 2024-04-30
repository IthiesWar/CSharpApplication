using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class FileHandling//static class
    {
        public static void Create()
        {
            //Creating a Directory
            if(!Directory.Exists("MetroCardManagement"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("MetroCardManagement");
            }
            //Creating a UserDetail File
            if(!File.Exists("UserDetails"))
            {
                Console.WriteLine("Creating a file....");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }
            //Creating a TicketFairDetails 
            if(!File.Exists("TicketFairDetails"))
            {
                Console.WriteLine("Creating a file....");
                File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }
             //Creating a TravelDetails 
            if(!File.Exists("TravelDetails"))
            {
                Console.WriteLine("Creating a file....");
                File.Create("MetroCardManagement/TravelDetails.csv").Close();
            }
        }
        //WriteCsv
        public static void WriteCsv()
        {
            //Write User Details
            string[]users=new string[Operation.user.Count];
            for(int i=0;i<Operation.user.Count;i++)
            {
                users[i]=Operation.user[i].CardNumber+","+Operation.user[i].Balance+","+Operation.user[i].UserName+","+Operation.user[i].PhoneNumber;
            }
            File.WriteAllLines("MetroCardManagement/UserDetails.csv",users);
            //Write Ticketfair Detail
            string[] ticketfairs=new string[Operation.ticketfair.Count];
            for(int i=0;i<Operation.ticketfair.Count;i++)
            {
                ticketfairs[i]=Operation.ticketfair[i].TicketID+","+Operation.ticketfair[i].FromLocation+","+Operation.ticketfair[i].ToLocation+","+Operation.ticketfair[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardManagement/TicketFairDetails.csv",ticketfairs);
            //Write Ticket Details
            string[]travels=new string[Operation.travel.Count];
            for(int i=0;i<Operation.travel.Count;i++)
            {
                travels[i]=Operation.travel[i].TravelId+","+Operation.travel[i].CardNumber+","+Operation.travel[i].FromLocation+","+Operation.travel[i].ToLocation+","+Operation.travel[i].Date.ToString("dd/MM/yyyy")+","+Operation.travel[i].TravelCost;
            }
            File.WriteAllLines("MetroCardManagement/TravelDetails.csv",travels);
        }
        //ReadCsv
        public static void ReadCsv()
        {
            //Read UserDetails
            string[]users=File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach(string user1 in users)
            {
                UserDetails user2=new UserDetails(user1);
                Operation.user.Add(user2);
            }
            //Read Ticket fair
            string[] ticketfairs=File.ReadAllLines("MetroCardManagement/TicketFairDetails.csv");
            foreach(string ticket1 in ticketfairs)
            {
                TicketFairDetails ticket2=new TicketFairDetails(ticket1);
                Operation.ticketfair.Add(ticket2);
            }
            //Read travel Details
            string[]travels=File.ReadAllLines("MetroCardManagement/TravelDetails.csv");
            foreach(string travel1 in travels)
            {
                TravelDetails travel2=new TravelDetails(travel1);
                Operation.travel.Add(travel2);
            }
        }

    }
}