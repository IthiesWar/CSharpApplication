using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public static class Operation
    {
        //Global values
        static CustomerDetails USERLOGINID;

        //list for customer details
        static List<CustomerDetails> customerlist=new List<CustomerDetails>();
        //list for product details
        static List<ProductDetails> productlist=new List<ProductDetails>();
        //list for order details
        static List<OrderDetails> orderlist=new List<OrderDetails>();

    //main menu starts here
    public static void MainMenu()
    {
        //bool for stop the loop
        bool value=true;
        do
        {
            Console.WriteLine("Mainmenu\n1. Registration\n2. Login\n3. Exit");
            Console.WriteLine("Enter your choice");
            int mainChoice=int.Parse(Console.ReadLine());
            switch(mainChoice)
            {
                case 1:
                {
                    Console.WriteLine("****Registration*****");
                    Registartion();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("****Login*****");
                    Login();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("***Exit****");
                    Console.WriteLine("Exit Successfully");
                    value=false;
                    break;
                }
            }
        }while(value);
    }//main menu ends here

    //Registration
    public static void Registartion()
    {
        Console.Write("Enter your name ");
        string name=Console.ReadLine();
        Console.Write("Enter your city ");
        string city=Console.ReadLine();
        Console.Write("Entre your mobile number ");
        long mobileNumber=long.Parse(Console.ReadLine());
        Console.Write("Enter your walleteBalnce ");
        double walletBalance=double.Parse(Console.ReadLine());
        Console.Write("Enter your email id ");
        string emailID=Console.ReadLine();

        //creating object
        CustomerDetails customer=new CustomerDetails(name,city,mobileNumber,walletBalance,emailID);
        //adding to the list
        customerlist.Add(customer);
        Console.WriteLine("Customer id is created "+customer.CustomerID);
    }//Registration ends here

    //Login
    public static void Login()
    {
        Console.Write("Enter your login id ");
        string loginId=Console.ReadLine();
        foreach(CustomerDetails customer in customerlist)
        {
            if(loginId.Equals(customer.CustomerID))
            {
                USERLOGINID=customer;
                Console.WriteLine("Login Successfully");
                SubMenu();
                break;
            }
        }
    }//Login ends here
    //sub menu starts here
    public static void SubMenu()
    {
        //bool for stop loop
        bool value=true;
        do
        {
            Console.WriteLine("Sub Menu\n1. Purchase\n2. order history\n3. cancel order\n4. walletbalance\n5. walletRecharge\n6. Exit");
            Console.WriteLine("Enter your choice");
            int subMenuChoice=int.Parse(Console.ReadLine());
            switch(subMenuChoice)
            {
                case 1:
                {
                    Console.WriteLine("****Purchase*****");
                    Purchase();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("*****order history*****");
                    OrderHistory();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("****Cancel order****");
                    CancelOrder();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("*****Wallet balance*****");
                    WalletBalance();
                    break;
                }
                case 5:
                {
                    Console.WriteLine("****WalletRecharge*****");
                    WalletRechare();
                    break;
                }
                case 6:
                {
                    Console.WriteLine("****Exit****");
                    Console.WriteLine("Exit Successfully");
                    value=false;
                    break;
                }
            }

        }while(value);
    }//submenu ends here
    //purchase 
    public static void Purchase()
    {
        //bool for stop if pro id is invalid
        bool value=true;
       //	Once the Customer logged in show the list of Products.  
       foreach(ProductDetails product in productlist)
            {
                Console.WriteLine($"{product.ProductID}|{product.ProductName}|{product.Stock}|{product.Quantity}|{product.ShipingDuration}");
            }
            //Ask the customer to select a Product using Product ID.
            Console.WriteLine("Enter the product id");
            string productID=Console.ReadLine();
            foreach(ProductDetails product in productlist){
            //Validate productID if it is invalid show “Invalid ProductID”.
            if(productID.Equals(product.ProductID))
            {
                value=false;
               // If it is valid, Then ask for the count he wish to purchase.\
               Console.WriteLine("Enter your count of stock");
               int count=int.Parse(Console.ReadLine());
               //cheking the count of user is less than the stock count
               if(count<=product.Stock)
               {
                double amount=(count*product.Quantity)+50;
                //checking the total balance is greater tah total amount
                if(amount<=USERLOGINID.WalletBalance)
                {
                    USERLOGINID.deduction(amount);
                    product.Quantity--;
                    //adding to the list
                    OrderDetails order=new OrderDetails(USERLOGINID.CustomerID,product.ProductID,amount,DateTime.Now,product.Quantity,Status.Ordered);
                    orderlist.Add(order);
                    Console.WriteLine("Order placed successfully "+order.OrderID);
                    break;
                }
                else
                {
                    Console.WriteLine("Insuffient wallet balance please recharge");
                }
               }
               else
               {
                Console.WriteLine("Stock is not available");
               }
            }
            }
            //invalid product id
            if(value)
            {
                Console.WriteLine("Invalid Product id");
            }
    }//purchase ends here
    //Cancel order
    public static void CancelOrder()
    {
        bool value=true;
        foreach(OrderDetails order in orderlist)
            {
                Console.WriteLine($"{order.OrderID}|{USERLOGINID.CustomerID}|{order.ProductID}|{order.TotalPrice}|{order.PurchaseDate}|{order.Quantity}|{order.OrderStatus}");
            
            Console.WriteLine("Enter the orderID");
            string orderID=Console.ReadLine();
            if(orderID.Equals(order.OrderID))
            {
                order.Quantity++;
                USERLOGINID.Exachnge(order.TotalPrice);
                value=false;
            }

            }
            if(value)
            {
                Console.WriteLine("Invalid order id");
            }

    }
    //order history
    public static void OrderHistory()
    {
       foreach(OrderDetails order in orderlist)
            {
                Console.WriteLine($"{order.OrderID}|{USERLOGINID.CustomerID}|{order.ProductID}|{order.TotalPrice}|{order.PurchaseDate}|{order.Quantity}|{order.OrderStatus}");
            }
    }//order histrory ends here
    //wallet balance 
    public static void WalletBalance()
    {
        Console.WriteLine("Wallet Balance "+USERLOGINID.WalletBalance);
    }//wallet balance ends here
    //wallet recharge
    public static void WalletRechare()
    {
        Console.WriteLine("Enter the amount");
        double RechargeAmt=double.Parse(Console.ReadLine());
        USERLOGINID.Exachnge(RechargeAmt);
    }//wallet recharge ends here

        public static void DefaultValues()
        {
            CustomerDetails customer1=new CustomerDetails("Ravi","Chennai",9885858588,	50000,"	ravi@mail.com");
            CustomerDetails customer2=new CustomerDetails("Baskaran",	"Chennai",	9888475757,	60000,"	baskaran@mail.com");

            //Adding to the list
            customerlist.AddRange(new List<CustomerDetails>(){customer1,customer2});

            //product list
            ProductDetails product1=new ProductDetails("Mobile(Samsung)",	10,	10000	,3);
            ProductDetails product2=new ProductDetails("Tablet (Lenovo)",	5	,15000	,2);
            ProductDetails product3=new ProductDetails("iPhone", 	5	,50000	,6);

            //adding to the lits
            productlist.AddRange(new List<ProductDetails>(){product1,product2,product3});

            //order list

            OrderDetails order1=new OrderDetails("CID1001",	"PID101",	20000	,DateTime.Now	,2	,Status.Ordered);
            OrderDetails order2=new OrderDetails("CID1002",	"PID103",	40000,	DateTime.Now	,2	,Status.Ordered);
            orderlist.AddRange(new List<OrderDetails>(){order1,order2}
            );

            //traversing the customer details
            foreach(CustomerDetails customer in customerlist)
            {
                Console.WriteLine($"{customer.CustomerID}|{customer.CustomerName}|{customer.MobileNumber}|{customer.WalletBalance}|{customer.EmailID}");
            }
            Console.WriteLine();
            //traversing the product details
            foreach(ProductDetails product in productlist)
            {
                Console.WriteLine($"{product.ProductID}|{product.ProductName}|{product.Stock}|{product.Quantity}|{product.ShipingDuration}");
            }
            Console.WriteLine();
            //traversing the order details
            foreach(OrderDetails order in orderlist)
            {
                Console.WriteLine($"{order.OrderID}|{order.CustomerID}|{order.ProductID}|{order.TotalPrice}|{order.PurchaseDate}|{order.Quantity}|{order.OrderStatus}");
            }

        }
    }//default values ends here
}