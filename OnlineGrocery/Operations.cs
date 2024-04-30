using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public static class Operations
    {
       public  static Customerregistration USERID1;
    public static CustomList<Customerregistration> customer=new CustomList<Customerregistration>();
    public static CustomList<ProductDetails> product=new CustomList<ProductDetails>();
    public static CustomList<BookingDetails> booking =new CustomList<BookingDetails>();
    

        public static void Default()
        {
            //customer Registration
            Customerregistration person1=new Customerregistration(10000,"Ravi","Ettapparajan",	Gender.male,	974774646,new DateTime(	11/11/1999),"ravi@gmail.com");
            Customerregistration person2=new Customerregistration(10000,"Ravg","Ettapparajan",	Gender.male,	974774646,new DateTime(	11/11/1999),"ravi@gmail.com");
            Customerregistration person3=new Customerregistration(10000,"Rav","Ettapparajan",	Gender.male,	974774646,new DateTime(	11/11/1999),"ravi@gmail.com");
            customer.Add(person1);
            customer.Add(person2);
            customer.Add(person3);
            
            //Values of ProductDetails 
            ProductDetails produtct1=new ProductDetails("Sugar",	20	,40);
            ProductDetails produtct2=new ProductDetails("Rice",	100	,50);
            ProductDetails produtct3=new ProductDetails("Milk",	10	,40);
            ProductDetails produtct4=new ProductDetails("Coffee",	10	,10);
            product.Add(produtct1);
            product.Add(produtct2);
            product.Add(produtct3);
            product.Add(produtct4);
            
            


            

        }
        public static void MainMenu()
        {
            bool value=true;
            do
            {
                Console.WriteLine("********Syncfusion college of engineering");
                Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Department wise Seat Availability\n4. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your Choice");
                int mainMenu=int.Parse(Console.ReadLine());
                switch(mainMenu)
                {
                    case 1:
                    {
                        Console.WriteLine("****Registration*****");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("***Login****");
                        LoginId();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Successfully Exit");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }
        public static void Registration()
        {
            Console.WriteLine("Name");
            string name=Console.ReadLine();
            Console.WriteLine("Father Name");
            string fatherName=Console.ReadLine();
            Console.WriteLine("Enter your Gender");
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.WriteLine("Mobile ");
            long mobile=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your date of birth");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Mail id");
            string mailID=Console.ReadLine();
            Console.WriteLine("Wallet Balance");
            double walletBalance=double.Parse(Console.ReadLine());
            Customerregistration customer1=new Customerregistration(walletBalance,name,fatherName,gender,mobile,dob,mailID);
            customer.Add(customer1);
            Console.WriteLine("Registration id "+customer1.CustomerID);
        }
        public static void LoginId()
        {
            Console.WriteLine("Enter your Login Id");
            string loginID=Console.ReadLine();
            for(int i=0;i<customer.Count;i++)
            {
                if(loginID.Equals(customer[i].CustomerID))
                {
                    USERID1=customer[i];
                    SubMenu();
                    Console.WriteLine("Login Suucessfully");
                    break;
                }
            }
        }
        //SubMenu
        public static void SubMenu()
        {
            //bool for stop the loop
            bool value=true;
            do
            {
                Console.WriteLine("SubMenu\n1. Show Customer Details\n2. Show Product Details\n3. Wallet Recharge\n4. Take Order\n5. Modify Order Quantity\n6. Cancel Order\n7. Show Balance\n8. h)	Exit");
                Console.WriteLine("Enter your choice");
                int Subchoice=int.Parse(Console.ReadLine());
                switch(Subchoice)
                {
                    case 1:
                    {
                        ShowCustomerDetails();
                        break;
                    }
                    case 2:
                    {
                        ShowProductDetails();
                        break;
                    }
                    case 3:
                    {
                       WalletRecharges();
                        break;
                    }
                    case 4:
                    {
                        TakeOrder();
                        break;
                    }
                    case 7:
                    {
                        WalletBalance();
                        break;
                    }
                
                }
            }while(value);
        }
        //show customer details method
        public static void ShowCustomerDetails()
        {
           
           for(int i=0;i<customer.Count;i++)
            {
               Console.WriteLine($"Name {customer[i].Name}|{customer[i].FatherName}|{customer[i].DOB}|{customer[i].Gender}|{customer[i].MailID}|{customer[i].Mobile}|{customer[i].WalletBalance}");
            }

        }
        //show product details
        public static void ShowProductDetails()
        {
            for(int i=0;i<product.Count;i++)
            {
                Console.WriteLine($"product Id{product[i].ProductID}|product Name{product[i].ProductName}|product Price{product[i].PricePerQuantity}|product Quantity{product[i].QuantityAvailable}");
            }
        }
        public static void WalletRecharges()
        {
            Console.WriteLine("Enter the Amount");
            double amount=double.Parse(Console.ReadLine());
            USERID1.WalletRecharge(amount);
            Console.WriteLine("Balance "+USERID1.WalletBalance);
        }
        public static void WalletBalance()
        {
            Console.WriteLine("Balance "+USERID1.WalletBalance);
        }
        //Take Order
        public static void TakeOrder()
        {
            string choice="";
            do
            {
                //Ask customer that whether he want to purchase / not. If “Yes”
                Console.WriteLine("You want purchase");
                string purchaseChoice=Console.ReadLine().ToLower();
                if(purchaseChoice.Equals("yes"))
                {
                    //booking details object with Customer id, Total price =0, Booking status = Initiated
                    BookingDetails book1=new BookingDetails(USERID1.CustomerID,0,DateTime.Now,Status.Initiated);
                    //Create a local order list named tempOrderList
                    CustomList<BookingDetails> tempOrderList=new CustomList<BookingDetails>();
                    //Show product details of available stock
                    for(int i=0;i<product.Count;i++)
                    {
                        Console.WriteLine($"Product ID {product[i].ProductID}|Product Name {product[i].ProductName}|PricePerQuantity {product[i].PricePerQuantity}|Quantity Available {product[i].QuantityAvailable}");
                    }

                }

            }while("yes".Equals(choice));
        }


        
    }
}