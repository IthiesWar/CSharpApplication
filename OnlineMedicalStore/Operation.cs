using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OnlineMedicalStore
{
    public static class Operation
    {
        static UserDetails USERID;
        static CustomList<UserDetails> user=new CustomList<UserDetails>();
        static CustomList<MedicineDetails> medicine=new CustomList<MedicineDetails>();
        static CustomList<OrderDetails> orderDetails=new CustomList<OrderDetails>();
        public static void Default()
        {
            UserDetails user1=new UserDetails(400,"	Ravi",	33,	"Theni","9877774440");
            UserDetails user2=new UserDetails(500,"Baskaran",	33	,"Chennai",	"8847757470");
            user.Add(user1);
            user.Add(user2);
            for(int i=0;i<user.Count;i++)
            {
                Console.WriteLine($"{user[i].UserID}|{user[i].Name}|{user[i].Phone}|{user[i].Age}|{user[i].WalletBalance}");
            }
            Console.WriteLine();
            //medicine details
            MedicineDetails medicine1=new MedicineDetails("Paracitamol",40,	5,new DateTime(2024,03,07));
            MedicineDetails medicine2=new MedicineDetails("Calpol",	10	,5	,new DateTime(2025,05,08));
            medicine.Add(medicine1);
            medicine.Add(medicine2);
            for(int i=0;i<medicine.Count;i++)
            {
                Console.WriteLine($"{medicine[i].MedicineID}|{medicine[i].MedicineName}|{medicine[i].AvailableCount}|{medicine[i].Price}|{medicine[i].DateOfExpiry}");
            }
            Console.WriteLine();
            //OrderDetails
            OrderDetails order1=new OrderDetails("UID1001",	"MD101",	3,	15,new DateTime(13/11/2022),Status.purchased);
             OrderDetails order2=new OrderDetails("UID1001",	"MD102",	2	,10,new DateTime(13/11/2022),	Status.purchased);
             orderDetails.Add(order1);
             orderDetails.Add(order2);
             for(int i=0;i<orderDetails.Count;i++)
             {
                Console.WriteLine($"{orderDetails[i].OrderID}|{orderDetails[i].MedicineID}|{orderDetails[i].MedicineCount}|{orderDetails[i].TotalPrice}|{orderDetails[i].OrderDate}|{orderDetails[i].OrderStatus}");
             }

        }
        public static void MainMenu()
        {
            bool value=true;
            do
            {
               Console.WriteLine("Registration\n Login\n Exit");
               Console.WriteLine("Enter Choice");
               int mainChoice=int.Parse(Console.ReadLine());
               switch(mainChoice)
               {
                 case 1:
                 {
                    Console.WriteLine("Registration");
                    Registration();
                    break;
                 }
                 case 2:
                 {
                    Console.WriteLine("Login");
                    Login();
                    break;
                 }
                 case 3:
                 {
                    Console.WriteLine("Exit");
                    value=false;
                    break;
                 }
               }
            }while(value);
        }
        public static void Registration()
        {
            Console.WriteLine("User Name");
            string userName=Console.ReadLine();
            Console.WriteLine("Age");
            int age=int.Parse(Console.ReadLine());
            Console.WriteLine("city");
            string city=Console.ReadLine();
            Console.WriteLine("Phone");
            string phone=Console.ReadLine();
            Console.WriteLine("Balance");
            double balance=double.Parse(Console.ReadLine());
            UserDetails user1=new UserDetails(balance,userName,age,city,phone);
            user.Add(user1);
            Console.WriteLine("User ID "+user1.UserID);
        }
        public static void Login()
        {
            bool value=true;
            Console.WriteLine("Login id");
            string loginID=Console.ReadLine();
            for(int i=0;i<user.Count;i++)
            {
                if(loginID.Equals(user[i].UserID))
                {
                    USERID=user[i];
                    SubMenu();
                   value=false;
                   break;
                }
            }
            if(value)
            {
                Console.WriteLine("Invalid user ID");
            }
        }
        public static void SubMenu()
        {
            bool value=true;
            do
            {
               Console.WriteLine("SubMenu\n1. WalletRecharge\n2. purchase\n3. Wallete Balance\n4. Show Purchase History\n5. Wallet Recharge\n6. Show Balance\n6. Exit");
               Console.WriteLine("Enter Choice");
               int mainChoice=int.Parse(Console.ReadLine());
               switch(mainChoice)
               {
                 case 1:
                 {
                    Console.WriteLine("Recharge");
                    WalletRecharge();
                    break;
                 }
                 case 2:
                 {
                    Console.WriteLine("Purchase");
                    Purchase();
                    break;
                 }
                 case 3:
                 {
                    Console.WriteLine("Balance check");
                    WalletBalance();
                    break;
                 }
                 case 4:
                 {
                    Console.WriteLine("Show Puchase History");
                    ShowPurchaseHistory();
                    break;
                 }
                 case 5:
                 {
                    Console.WriteLine("Wallet Recharge");
                    WalletRecharge();
                    break;
                 }
                 case 6:
                 {
                    Console.WriteLine("Modified History");
                    ModifyOrder();
                    break;
                 }
                 case 7:
                 {
                    Console.WriteLine("Cancel Order");
                    CancelOrder();
                    break;
                 }
                 case 8:
                 {
                    Console.WriteLine("Exit");
                    value=false;
                    break;
                 }
               }
            }while(value);
        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Enter amount");
            double amount=double.Parse(Console.ReadLine());
            USERID.WalletRecharge(amount);
            Console.WriteLine("Balance "+USERID.WalletBalance);
        }
        public static void WalletBalance()
        {
            Console.WriteLine("Balance "+USERID.WalletBalance);
        }
        //Default values of medical details
        public static void DefaultMedical()
        {
            MedicineDetails medicine1=new MedicineDetails("Paracitamol",40,	5,new DateTime(2024,03,07));
            MedicineDetails medicine2=new MedicineDetails("Calpol",	10	,5	,new DateTime(2025,05,08));
            MedicineDetails medicine3=new MedicineDetails("Gelucil",3,40,new DateTime(2023/04/08));
            MedicineDetails medicine4=new MedicineDetails("Metrogel",	5	,50,new DateTime(30/12/2024));
            MedicineDetails medicine5=new MedicineDetails("Povidin Iodin",10,50,new DateTime(2024/10/30));
            medicine.Add(medicine1);
            medicine.Add(medicine2);
            medicine.Add(medicine3);
            medicine.Add(medicine4);
        }
        public static void Purchase()
        {
            //	Show the List of medicine details by traversing the medicine details list
            for(int i=0;i<medicine.Count;i++)
            {
                Console.WriteLine($"{medicine[i].MedicineID}|{medicine[i].MedicineName}|{medicine[i].AvailableCount}|{medicine[i].Price}|{medicine[i].DateOfExpiry}");
            }
            //user to select the medicine using MedicineID
            Console.WriteLine("Choose medicineId");
            string medicineID=Console.ReadLine();
            //Ask the number of counts of that medicine he wants to buy
            Console.WriteLine("Choose count of medicine");
            int countMedicine=int.Parse(Console.ReadLine());
            //bool for medicine expired
            bool value=true;
            for(int i=0;i<medicine.Count;i++)
            {
                if(medicineID.Equals(medicine[i].MedicineID))
                {
                    if(countMedicine<=medicine[i].AvailableCount)
                    {
                        //Check the medicine was not expired
                        if(DateTime.Now<=medicine[i].DateOfExpiry)
                        {
                            if(USERID.WalletBalance>=medicine[i].Price*countMedicine)
                            {
                                int price=medicine[i].Price*countMedicine;
                                USERID.DeductBalance((double) medicine[i].Price);
                                OrderDetails order1=new OrderDetails(USERID.UserID,medicine[i].MedicineID,medicine[i].AvailableCount,medicine[i].Price,DateTime.Now,Status.purchased);
                                orderDetails.Add(order1);
                                Console.WriteLine("Medicine was successfully purchased "
                                +order1.MedicineID);
                            }
                            value=false;
                        }

                    }
                }
            }
            if(value)
            {
                Console.WriteLine("Medicine Expired");
            }
        }
        public static void ShowPurchaseHistory()
        {
            for(int i=0;i<orderDetails.Count;i++)
            {
                Console.WriteLine($"OrderID {orderDetails[i].OrderID}|UserID {orderDetails[i].UserID}|{orderDetails[i].MedicineID}|Medicine Count {orderDetails[i].MedicineCount}|Total Price{orderDetails[i].TotalPrice}|Order Date {orderDetails[i].OrderDate}|Order Status {orderDetails[i].OrderStatus}");
            }
        }
        public static void RechargeWallet()
        {
            Console.WriteLine("Enter your amount");
            double amount=double.Parse(Console.ReadLine());
            USERID.WalletRecharge(amount);
        }
        public static void ShowBalance()
        {
            Console.WriteLine("Wallet Balance "+USERID.WalletBalance);
        }
        public static void ModifyOrder()
        {
            //Show the order details of current logged in user to pick a order detail by using OrderID and whose status is “Purchased”.
            for(int i=0;i<orderDetails.Count;i++)
            {
                if(USERID.UserID.Equals(orderDetails[i].UserID) && Status.purchased.Equals(orderDetails[i].OrderStatus))
                {
                    Console.WriteLine($"OrderId {orderDetails[i].OrderID}|UserID {orderDetails[i].UserID}|MedicineId {orderDetails[i].MedicineID}|MedicineCount {orderDetails[i].MedicineCount}|TotalPrice {orderDetails[i].TotalPrice}|OrderDate {orderDetails[i]}");
                    Console.WriteLine("Enter new quantity");
                    int quantity=int.Parse(Console.ReadLine());
                    orderDetails[i].TotalPrice=quantity*orderDetails[i].TotalPrice;
                    Console.WriteLine("Modified Successfully");

                }
            } 
            
        }
        public static void CancelOrder()
        {
            //Show the order details of the currently logged in user whose order status is “Purchased”.
            for(int i=0;i<orderDetails.Count;i++)
            {
                if(USERID.UserID.Equals(orderDetails[i].UserID))
                {
                    Console.WriteLine($"{orderDetails[i].OrderID}|{orderDetails[i].MedicineID}|{orderDetails[i].UserID}|{orderDetails[i].MedicineCount}|{orderDetails[i].OrderDate}|{orderDetails[i].OrderStatus}|{orderDetails[i].TotalPrice}");
                    Console.WriteLine("Enter the orderID");
                    string userID=Console.ReadLine();
                    if(userID.Equals(orderDetails[i].OrderID))
                    {
                        USERID.WalletRecharge(orderDetails[i].TotalPrice);
                    }
                }
            }
            
            

        }

    }
}