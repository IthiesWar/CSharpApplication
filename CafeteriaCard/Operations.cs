using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    
    public static class Operations
    {
        //main menu
        //static list
        static UserDetails USERLOGINID;
        static CustomList<UserDetails> personal1=new CustomList<UserDetails>();
        //Food details
       static CustomList<FoodDetails> food=new CustomList<FoodDetails>();
       //order list
       static CustomList<OrderDetails> order=new CustomList<OrderDetails>();
       //card item
       static CustomList<CartItem> card=new CustomList<CartItem>();
        public static void MainMenu()
        {
            //bool for stop the loop
            bool value=true;
            do
            {
            Console.WriteLine($"Main Menu\n1. Registration\n2. Login\n3. Exit");
            //getting choice
            Console.WriteLine("Enter your choice");
            int mainChoice=int.Parse(Console.ReadLine());
            switch(mainChoice)
            {
                case 1:
                {
                    Console.WriteLine("****Resgistration*****");
                    Registeration();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("****Login****");
                    Login();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Exit Successfully");
                    value=false;
                    break;
                }
            }
            }while(value); 
        }//Main menu ends here

        //Resgitation starts here
        public static  void Registeration()
        {
            Console.Write("Enter your name ");
            string name=Console.ReadLine();
            Console.Write("Enter your father name ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your Gender ");
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.Write("Enter your phone number ");
            long mobileNumber=long.Parse(Console.ReadLine());
            Console.Write("Enter your mail id ");
            string mailID=Console.ReadLine();
            Console.Write("Enter your work station number ");
            int workStationNumber=int.Parse(Console.ReadLine());
            Console.Write("Enter your Balance ");
            double balance=double.Parse(Console.ReadLine());
            //creating the object
            UserDetails personalobject=new UserDetails(1,balance,name,fatherName,gender,mobileNumber,mailID);
            //Inserting the element to the list
            personal1.Add(personalobject);
            Console.WriteLine("Regiteration ID "+personalobject.UserID);

        }
        //Login Starts here
        public static void Login()
        {
            bool value=true;

            Console.WriteLine("Enter your Login id ");
            string loginID=Console.ReadLine();
            for(int i=0;i<personal1.count;i++)
            {
                if(loginID.Equals(personal1[i].UserID))
                {
                    USERLOGINID=personal1[i];
                    Console.WriteLine("Login Successful ");
                    SubMenu();
                    value=false;
                    break;
                }
            }
            if(value)
            {
                Console.WriteLine("Invalid Login Id");
            }
        }//Login ends here
        //submenu
        public static void SubMenu()
        {
            
            //bool for stop the loop
            bool value=true;
            do
            {
                Console.WriteLine($"Main menu\n1. Show My Profile\n2. Food Order\n3. Modify Order\n4. Cancel Order\n5. Order History\n6. Wallet Recharge\n7. Show WalletBalance\n8. Exit");
                Console.WriteLine("Enter your choice ");
                int subMenu=int.Parse(Console.ReadLine());
                switch(subMenu)
                {
                    case 1:
                    {
                        Console.WriteLine("****Show My Profile****");
                        ShowDetails();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**** Food Order****");
                        Foodorder();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Modify Order****");
                        ModifyOrder();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("****Cancel Order****");
                        CancelOrder();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("****Order History****");
                        OrderHistory();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("****Wallet Recharge****");
                        WalletRecharge1();
                        break;
                    }
                    case 7:
                    {
                        Console.WriteLine("****Show WalletBalance****");
                         WalletBalance();
                        break;
                    }
                    case 8:
                    {
                        Console.WriteLine("****Exit*****");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }
        //Show My Profile
        public static void ShowDetails()
        {
            Console.WriteLine($"{USERLOGINID.UserID}|{USERLOGINID.Name}|{USERLOGINID.FatherName}|{USERLOGINID.Gender}|{USERLOGINID.Mobile}|{USERLOGINID.MailID}|{USERLOGINID.WorkStationNumber}|{USERLOGINID.Balance}");
        }
        public static void Foodorder()
        {
            //bool for out the loop
            bool value=true;
            //Food Details
            foreach(FoodDetails foods in food)
            {
                Console.WriteLine($"Food ID {foods.FoodID}|Food Name {foods.FoodName} | Price {foods.FoodPrice} | Quantity {foods.Quantity}");
                Console.WriteLine("Enter the food ID and Quantity");
                //Ask the user to choose the food and the quantity
                string choice="";
                int totalPrice=0;
                //for repeat the process until user said no
                Console.WriteLine("Enter your food ifd");
                int foodId=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the food quantity");
                int foodQuantity=int.Parse(Console.ReadLine());
                do{
                   
                //total price
                if(foodId.Equals(foods.FoodID))
                {
                     
                    value=false;
                    totalPrice=foodQuantity*foods.FoodPrice;
                    foods.Quantity--;
                }
                Console.WriteLine("Do you want to choose another product");
                choice=Console.ReadLine();
                }while(choice=="yes");

                if(USERLOGINID.Balance>totalPrice)
                {
                    USERLOGINID.DeductAmount();
                    //adding to the global list
                    OrderDetails order1=new OrderDetails(USERLOGINID.UserID,DateTime.Now,totalPrice,Status.Ordered);
                    order.Add(order1);
                    Console.WriteLine("Order successfully "+order1.OrderID);
                }
                else
                {
                    Console.WriteLine("Insufficiant bank balance");
                }

            
            }
            if(value)
            {
                Console.WriteLine("Invalid Food Id");
            }
        }//Food order ends here
        

        public static void ModifyOrder()
        {
            //1.	Show the Order details of current logged in user to pick an Order detail by using OrderID and whose status is “Ordered”.
            // Check whether the order details is present. If yes then,
            foreach(OrderDetails order1 in order)
            {
            Console.WriteLine($"Name {USERLOGINID.Name}|{USERLOGINID.FatherName}|{USERLOGINID.UserID}|{USERLOGINID.Balance}|{order1.OrderDate}|{order1.OrderID}|{order1.OrderStatus}");

            }
            //item card
             foreach(CartItem cards in card)
             {
                Console.WriteLine($"Item ID {cards.ItemID}| order id {cards.OrderID} | food id {cards.FoodID} | order price {cards.OrderPrice} | order quantity {cards.OrderQuantity}");
                Console.WriteLine("Enter the item id");
                string itemID=Console.ReadLine();
                if(itemID.Equals(cards.ItemID))
                {
                    Console.WriteLine("Enter the new quantity");
                    int quantity=int.Parse(Console.ReadLine());
                    int totalPrice=quantity*cards.OrderPrice;
                    USERLOGINID.DeductAmount();
                    Console.WriteLine("Modified order successfully");
                }
             }

        }//Modified order
        //Cancel order
        public static void CancelOrder()
        {
            //Show the Order details of the current user who’s Order status is “Ordered”.
            foreach(OrderDetails orders in order)
            {
                if(USERLOGINID.UserID.Equals(orders.UserID))
                {
                    Console.WriteLine($"User ID {orders.UserID} | Order id {orders.OrderID} | order status {orders.OrderStatus}");
                    //Ask the user to pick an OrderID to cancel
                    Console.WriteLine("Pick an order id to cancel ");
                    string orderID=Console.ReadLine();
                    if(orders.OrderID.Equals(orderID))
                    {
                        USERLOGINID.Balance+=orders.TotalPrice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid id");
                    }
                }
            }
        }//Camcel order ends here

        //OrderHistory
        public static void OrderHistory()
        {
            foreach(OrderDetails orders in order)
            {
                if(USERLOGINID.UserID.Equals(orders.UserID))
                {
                    Console.WriteLine($"User ID {orders.UserID}| Order Date {orders.OrderDate} |order status {orders.OrderStatus}");
                }
            }
        }//orders history ends here
    //wallet recharge
        public static void WalletRecharge1()
        {
            Console.WriteLine("Enter the amount");
            int amount=int.Parse(Console.ReadLine());
            USERLOGINID.WalletRecharge(amount);
            
        }//wallet recharge ends here

        //balance
        public static void WalletBalance()
        {
            Console.WriteLine("Your Balance "+USERLOGINID.Balance);
        }//balance ends here

        //Adding default values
        public static void DefaultValues()
        {
            //adding default values for food details
            FoodDetails food1=new FoodDetails("Coffee",	20,	100);
            FoodDetails food2=new FoodDetails("Tea",	15,	100);
            FoodDetails food3=new FoodDetails("Biscuit",	10	,100);
            //Add range
            food.AddRange(new CustomList<FoodDetails>(){food1,food2,food3});
            //traversing
            foreach(FoodDetails foods in food)
            {
                Console.WriteLine($"Food ID {foods.FoodID}|Food Name {foods.FoodName} | Price {foods.FoodPrice} | Quantity {foods.Quantity}");
                
            }

            //adding default values for card item
            CartItem card1=new CartItem("OID1001"	,"FID101",	20,	1);
             CartItem card2=new CartItem("OID1001",	"FID103",	10,	1);
             //add range
             card.AddRange(new CustomList<CartItem>(){card1,card2});
             //traversing 
             foreach(CartItem cards in card)
             {
                Console.WriteLine($"Item ID {cards.ItemID}| order id {cards.OrderID} | food id {cards.FoodID} | order price {cards.OrderPrice} | order quantity {cards.OrderQuantity}");
             }

        }
    }
}