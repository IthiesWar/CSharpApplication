using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class Operation
    {
        //static variavle
        static UserDetails USERSLOGIN;
        //static List user details
       public static CustomList<UserDetails> user=new CustomList<UserDetails>();//Making public for accessthe filehandling class
        //travel history
        public static CustomList<TravelDetails> travel=new CustomList<TravelDetails>();
        //ticket fair
        public static CustomList<TicketFairDetails> ticketfair=new CustomList<TicketFairDetails>();

        //Main menu
        public static void MainMenu()
        {
            //bool for stpo the loop
            bool value=true;
            do
            {
                Console.WriteLine("Main Menu\n1. New User Registration\n2. Login User\n3. Exit");
                Console.WriteLine("Enter your choice");
                int mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("****Registration****");
                        Registration();
                        break;

                    }
                    case 2:
                    {
                        Console.WriteLine("****lOGIN****");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Exit****");
                        Console.WriteLine("Main Exit Successfully");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }//Main Menu ends here
        //Registration
        public static void Registration()
        {
            Console.Write("Enter your name :");
            string name=Console.ReadLine();
            Console.Write("Enter your Phone number :");
            long phoneNumber=long.Parse(Console.ReadLine());
            Console.Write("Enter your Balance :");
            int balance=int.Parse(Console.ReadLine());
            //creating a object
            UserDetails user1=new UserDetails(balance,name,phoneNumber);
            user.Add(user1);
            Console.WriteLine("Your CardNumer is "+user1.CardNumber);
        }//Registration ends here
        //Login
        public static void Login()
        {
            //bool for wrong id
            bool value=true;
            Console.WriteLine("Enter your CardNumber");
            string cardNumber=Console.ReadLine();
            for(int i=0;i<user.Count;i++)
            {
                if(cardNumber.Equals(user[i].CardNumber))
                {
                    USERSLOGIN=user[i];
                    value=false;
                    SubMenu();
                    break;
                }
            }
            if(value)
            {
                Console.WriteLine("Invalid Card Number");
            }

        }
        //SubMenu
        public static void SubMenu()
        {
            bool value=true;
            do
            {
                Console.WriteLine("Sub Menu\n1. Balance Check\n2. Recharge\n3. ViewTravel History\n4. Travel\n5 Exit");
                Console.WriteLine("Enter your choice");
                int mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("***Balance Check****");
                        BalanceCheck();
                        break;

                    }
                    case 2:
                    {
                        Console.WriteLine("****Recharge****");
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****ViewTravel History****");
                        TravelHistory();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("****Travel*****");
                        Travel();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("****Exit****");
                        Console.WriteLine("SubMenu Exit Successfully");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }//Submenu ends here
        //Balance check
        public static void BalanceCheck()
        {
            Console.WriteLine($"Balance :"+USERSLOGIN.Balance);
        }//Balance check ends here
        //Recharge
        public static void Recharge()
        {
            Console.WriteLine("Enter your Amount");
            int amount=int.Parse(Console.ReadLine());
            USERSLOGIN.WalletRecharge(amount);
            Console.WriteLine("Current Balance "+USERSLOGIN.Balance);
        }//Recharge ends here
        //travel history
        public static void DefaultTravelHistory()//Default values for travel history
        {
            //creating a obeject
            TravelDetails travel1=new TravelDetails("CMRL1001",	"Airport","Egmore",new DateTime(10/10/2023),55);
            TravelDetails travel2=new TravelDetails("CMRL1001",	"Egmore","Koyambedu",new DateTime(10/10/2023),32);
            TravelDetails travel3=new TravelDetails("CMRL1002",	"Alandur","Koyambedu",new DateTime(10/11/2023),25);
            TravelDetails travel4=new TravelDetails("CMRL1002","Egmore","Thirumangalam",new DateTime(10/11/2023),25);
            //adding to the list
            travel.Add(travel1);
            travel.Add(travel2);
            travel.Add(travel3);
            travel.Add(travel4);
        }
        public static void TravelHistory()
        {
            
            for(int i=0;i<travel.Count;i++)
            {
                if(USERSLOGIN.CardNumber.Equals(travel[i].CardNumber))
                {
                    Console.WriteLine($"{travel[i].CardNumber}|{travel[i].FromLocation}|{travel[i].ToLocation}|{travel[i].Date}|{travel[i].TravelCost}");
                }
            }
        }//travel history ends here
        //travel
         public static void DefaultTicketFair()
        {
            TicketFairDetails ticket1=new TicketFairDetails("Airport","Egmore",	55);
            TicketFairDetails ticket2=new TicketFairDetails("Airport","Koyambedu",25);
            TicketFairDetails ticket3=new TicketFairDetails("Alandur","	Koyambedu",25);
            TicketFairDetails ticket4=new TicketFairDetails("Koyambedu","Egmore",32);
            TicketFairDetails ticket5=new TicketFairDetails("Vadapalani","Egmore",45);
            //adding to the list
            ticketfair.Add(ticket1);
            ticketfair.Add(ticket2);
            ticketfair.Add(ticket3);
            ticketfair.Add(ticket4);
            ticketfair.Add(ticket5);
            
        }
        //Travel starts 
        public static void Travel()
        {
            //Show the Ticket fair details 
            for(int i=0;i<ticketfair.Count;i++)
            {
                Console.WriteLine($"Ticket ID {ticketfair[i].TicketID}From Location {ticketfair[i].FromLocation}|ToLocation {ticketfair[i].ToLocation}|Ticket price {ticketfair[i].TicketPrice}");
            }
            bool value=true;//check the id is valid
             //travesing a ticketfair
             bool value1=true;//check the user sufficient balance
              Console.WriteLine("Choose the ticket iD");
                string ticketId=Console.ReadLine();
            for(int i=0;i<ticketfair.Count;i++)
            {
                
                //where the user wishes to travel by getting TicketID
              
                 //Check the ticketID is valid
                if(ticketfair[i].TicketID.Equals(ticketId))
                {
                    //Check the balance from the user object whether it has sufficient balance to travel
                    if(USERSLOGIN.Balance>=ticketfair[i].TicketPrice)
                    {
                        //If “Yes” deduct the respective amount 
                        int price=ticketfair[i].TicketPrice;//Store the ticket price
                        USERSLOGIN.DeductBalance(price);
                        Console.WriteLine("After deduction Balance "+USERSLOGIN.Balance);
                        //creating object
                        TravelDetails travel1=new TravelDetails(USERSLOGIN.CardNumber,ticketfair[i].FromLocation,ticketfair[i].ToLocation,DateTime.Now,ticketfair[i].TicketPrice);
                        travel.Add(travel1);
                        Console.WriteLine("Your Travel Id "+travel[i].TravelId);
                        value1=false;
                        
                    }
                    value=false;
                    break;
                }
            }
            //Invalid id
            if(value)
            {
                Console.WriteLine("Invalid ID");
            }
            //Insuffient balance
            if(value1)
            {
                Console.WriteLine("Insuffient Balance");
            }


        }//travel ends here
        //Adding default values
        public static void Default()
        {
           //creating a object
            UserDetails user1=new UserDetails(1000,"Ravi",9848812345);
            UserDetails user2=new UserDetails(1000,"Baskaran",9948854321);
            //adding to the list
            user.Add(user1);
            user.Add(user2);
        /*
        
            //creating a obeject
            TravelDetails travel1=new TravelDetails("CMRL1001",	"Airport","Egmore",new DateTime(10/10/2023),	55);
            TravelDetails travel2=new TravelDetails("CMRL1001",	"Egmore",	"Koyambedu",new DateTime(10/10/2023),32);
            TravelDetails travel3=new TravelDetails("CMRL1002",	"Alandur",	"Koyambedu",new DateTime(10/11/2023),	25);
            TravelDetails travel4=new TravelDetails("CMRL1002","Egmore","Thirumangalam",new DateTime	(10/11/2023),	25);
            //adding to the list
            travel.Add(travel1);
            travel.Add(travel2);
            travel.Add(travel3);
            travel.Add(travel4);

            //creating a object
            TicketFairDetails ticket1=new TicketFairDetails("	Airport",	"Egmore",	55);
            TicketFairDetails ticket2=new TicketFairDetails("	Airport	","Koyambedu",	25);
            TicketFairDetails ticket3=new TicketFairDetails("	Alandur","	Koyambedu",	25);
            TicketFairDetails ticket4=new TicketFairDetails("Koyambedu",	"Egmore",	32);
            TicketFairDetails ticket5=new TicketFairDetails("Vadapalani",	"Egmore",	45);
            //adding to the list
            ticketfair.Add(ticket1);
            ticketfair.Add(ticket2);
            ticketfair.Add(ticket3);
            ticketfair.Add(ticket4);
            ticketfair.Add(ticket5);*/

            //traveing a user
           /* for(int i=0;i<user.Count;i++)
            {
                Console.WriteLine($"{user[i].CardNumber}| Name {user[i].UserName}| phone {user[i].PhoneNumber}| {user[i].Balance}");
            }
            Console.WriteLine();

            //traversing a travel history
            for(int i=0;i<travel.Count;i++)
            {
                Console.WriteLine($"Travel ID{travel[i].TravelId} | card Number {travel[i].CardNumber} |From Location {travel[i].FromLocation}|To Location {travel[i].ToLocation}|Date {travel[i].Date}|Travel Cost {travel[i].TravelCost}");
            }
            Console.WriteLine();

            //travesing a ticketfair
            for(int i=0;i<ticketfair.Count;i++)
            {
                Console.WriteLine($"Ticket ID {ticketfair[i].TicketID}From Location {ticketfair[i].FromLocation}|ToLocation {ticketfair[i].ToLocation}|Ticket price {ticketfair[i].TicketPrice}");
            }
            Console.WriteLine();*/
        }
    }
}