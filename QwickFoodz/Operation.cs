using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace QwickFoodz
{
    public static class Operation
    {
        //static variale
        static CustomerDetails UESRLOGINID;
        public static CustomList<CustomerDetails> customer=new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> food=new CustomList<FoodDetails>();
        public static CustomList<OrderDetails> order=new CustomList<OrderDetails>();
        public static CustomList<ItemDetails> item=new CustomList<ItemDetails>();

        //Main Menu
        public static void MainMenu()
        {
            //bool for Stop the loop
            bool value=true;
            do
            {
                Console.WriteLine("MainMenu\n1. Customer Registration\n2. Customer Login\n3. Exit");
                //Asking user for choice
                Console.WriteLine("Enter your Choice");
                int mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("****Customer Registration*****");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("****Customer Login****");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Exit****");
                        Console.WriteLine("MainMenu Exit Successfully");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }//Main Menu ends here
        //Registration
        public static void Registration()
        {
            Console.Write("Enter your name ");
            string name=Console.ReadLine();
            Console.Write("Enter your father name ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your gender Male/Female/Transgender ");
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.Write("Enter your mobile ");
            string mobile=Console.ReadLine();
            Console.Write("Enter your Date of birth ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your mailId ");
            string mailID=Console.ReadLine();
            Console.Write("Enter your location ");
            string location=Console.ReadLine();
            Console.WriteLine("Enter your Balance ");
            double balance=double.Parse(Console.ReadLine());
            CustomerDetails customer1=new CustomerDetails(balance,name,fatherName,gender,mobile,dob,mailID,location);
            customer.Add(customer1);
            Console.WriteLine("“Customer registration successful Your Customer ID: "+customer1.CustomerID);
        }//Registration ends here
        //Login
        public static void Login()
        {
            //bool for stop the loop
            bool value=true;
            //Asking Login id
            Console.Write("Enter your Login Id ");
            string loginID=Console.ReadLine();
            for(int i=0;i<customer.Count;i++)
            {
                if(customer[i].CustomerID.Equals(loginID))
                {
                    UESRLOGINID=customer[i];
                    SubMenu();
                    value=false;
                    break;
                }
            }
            if(value)
            {
                Console.WriteLine("Invalid user ID");
            }
        }//Login ends here
        //Sub Menu
        public static void SubMenu()
        {
            //bool for stop the loop
            bool value=true;
            do
            {
            Console.WriteLine("SubMenu\n1. Show Profile\n2. Order Food\n3. Cancel Order\n4. Modify Order\n5. Order History\n6. Recharge Wallet\n7. show wallet Balance\n8. Exit");
            Console.WriteLine("Enter your choice ");
            int subChoice=int.Parse(Console.ReadLine());
            switch(subChoice)
            {
                case 1:
                {
                    Console.WriteLine("****Show Profile****");
                    ShowProfile();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("****Order Food****");
                    OrderFood();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("****Cancel Order****");
                    CancelOrder();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("****ModifyOrder****");
                    ModifyOrder();
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
                    Console.WriteLine("****Recharge Wallet****");
                    RechargeWallet();
                    break;
                }
                case 7:
                {
                    Console.WriteLine("****Show Wallet Balance****");
                    ShowWalletBalance();
                    break;
                }
                case 8:
                {
                    Console.WriteLine("****Exit****");
                    Console.WriteLine("Sub Menu Exit Successfully");
                    value=false;
                    break;
                }
            }
            }while(value);
        }
        //Sub Menu ends here
        //ShowProfile
        public static void ShowProfile()
        {
            //Show the current logged in customer profile information in console
            Console.WriteLine($"CustomerID {UESRLOGINID.CustomerID}|Name {UESRLOGINID.Name}|FatherName {UESRLOGINID.FatherName}|Mobile {UESRLOGINID.Mobile}|DOB {UESRLOGINID.DOB}|Gender {UESRLOGINID.Gender}|MailID {UESRLOGINID.MailID}|Wallete Balance {UESRLOGINID.WalletBalance}");
        }
        //ShowProfile Ends here
        //Order Food
        public static void DefaultFoodItem()
        {
            FoodDetails food1=new FoodDetails("Chicken Briyani 1Kg",100	,12);
            FoodDetails food2=new FoodDetails("Mutton Briyani 1Kg",150,10);
            FoodDetails food3=new FoodDetails("Veg Full Meals",	80	,30);
            FoodDetails food4=new FoodDetails("Noodles",100	,40);
            FoodDetails food5=new FoodDetails("Dosa",40,40);
            FoodDetails food6=new FoodDetails("Idly (2 pieces)",20,50);
            FoodDetails food7=new FoodDetails("Pongal",40,20);
            FoodDetails food8=new FoodDetails("Vegetable Briyani",80,15);
            food.Add(food1);
            food.Add(food2);
            food.Add(food3);
            food.Add(food4);
            food.Add(food5);
            food.Add(food6);
            food.Add(food7);
            food.Add(food8);

        }
        //Order
        public static void OrderFood()
        {   
            //Create OrderDetails object with CustomerID, TotalPrice = 0, DateOfOrder as today and OrderStatus = Initiated.
            OrderDetails order1=new OrderDetails(UESRLOGINID.CustomerID,0,DateTime.Now,Status.Initiated);
            //Create localItemList for adding your wishlist
            CustomList<ItemDetails> localItemList=new CustomList<ItemDetails>();
            //ask user variable;
            bool value=true;
            do
            {
            //Show all the list of food items available in store for processing the order
            for(int i =0;i<food.Count;i++)
            {
                Console.WriteLine($"FoodId {food[i].FoodID}|FoodName {food[i].FoodName}|FoodQuantity {food[i].QuantityAvailable}|FoodPrice {food[i].PricePerQuantity}");
            }
            //Ask the FoodID
            Console.WriteLine("Choose Food Id ");
            string foodID=Console.ReadLine();
            Console.WriteLine("Quantity you want ");
            int quantity=int.Parse(Console.ReadLine());
            bool value1=true;//check food id is valid
            bool value2=true;//check quantity is available
            for(int i =0;i<food.Count;i++)
            {
                if(foodID.Equals(food[i].FoodID))
                {
                    value1=false;
                    if(quantity<=food[i].QuantityAvailable)
                    {
                        value2=false;
                        // available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order
                        ItemDetails item1=new ItemDetails(order[i].OrderID,food[i].FoodID,quantity,food[i].PricePerQuantity);
                        //deduct the available quantity and store the ItemDetails object in localItemList
                        food[i].QuantityAvailable-=quantity;
                        localItemList.Add(item1);
                       
                    }
                }
            }
            if(value1)
            {
                Console.WriteLine("Invalid FoodId");
            }
            if(value2)
            {
                Console.WriteLine("Unavailable Quantity");
            }
            Console.WriteLine("Do you want to order more");
            string choice=Console.ReadLine().ToLower();
            if("no".Equals(choice))
            {
            Console.WriteLine("Do you want to confirm purchase");
            string confirmChoice=Console.ReadLine().ToLower();
            if("yes".Equals(confirmChoice))
            {
                for(int i =0;i<food.Count;i++)
                {
                if(UESRLOGINID.WalletBalance>=food[i].PricePerQuantity)
                {
                    double price=food[i].PricePerQuantity*quantity;
                    UESRLOGINID.DeductBalance(price);
                    //Modify the order details
                    OrderDetails order2=new OrderDetails(order1.CustomerID,(int)price,DateTime.Now,Status.Ordered);
                    order.Add(order2);
                    //adding to the item list
                    Console.WriteLine("Your order iD "+order2.OrderID);
                    ItemDetails item2=new ItemDetails(order[i].OrderID,food[i].FoodID,quantity,(int)price);
                    item.Add(item2);
                    Console.WriteLine("Your Item Id is "+item2.ItemID);

                }
                else
                {
                    Console.WriteLine("Do you want do Recharge");
                    string recharge=Console.ReadLine().ToLower();
                    if("yes".Equals(recharge))
                    {
                        RechargeWallet();
                    }
                }
                }
            }
            else
            {
                //“No” return the localItemList of items count back to FoodDetails list
                 for(int i =0;i<food.Count;i++)
                 {
                    if(foodID.Equals(food[i]))
                food[i].QuantityAvailable+=quantity;
                    FoodDetails food1=new FoodDetails(food[i].FoodName,food[i].PricePerQuantity,food[i].QuantityAvailable);
                 }
            }
            }
            else if("yes".Equals(choice))
            {
                value=true;
            }

            }while(value);
        }//Order ends here
        //Cancel Order
        public static void CancelOrder()
        {
            //Show the list of orders placed by current logged in user whose status is “Ordered”
            for(int i=0;i<order.Count;i++)
            {
                if(UESRLOGINID.CustomerID.Equals(order[i].CustomerID))
                {
                    Console.WriteLine($"OrderId {order[i].OrderID}|CustomerId {order[i].CustomerID}|Total Price {order[i].TotalPrice}|Date Of Order {order[i].DateOfOrder}|OrderStatus {order[i].OrderStatus}");
                }
            }
            //Ask the user to pick an order to be cancelled by OrderID.
            Console.WriteLine("Choose the orderID ");
            string orderID=Console.ReadLine();
            for(int i=0;i<order.Count;i++)
            {
                if(orderID.Equals(order[i].OrderID))
                {
                    UESRLOGINID.WalletRecharge((double)order[i].TotalPrice);
                    order[i].OrderStatus=Status.Cancelled;
                }
            }
        }//Cancel Order Ends here
        public static void ModifyOrder()
        {
            //Show the orders placed by current logged in user whose order status is booked
            for(int i=0;i<order.Count;i++)
            {
                if(UESRLOGINID.CustomerID.Equals(order[i].CustomerID))
                {
                    Console.WriteLine($"OrderID {order[i].OrderID}|CustomerId {order[i].CustomerID}|Date of order {order[i].DateOfOrder}|Total Price {order[i].TotalPrice}|Order Status{order[i].OrderStatus}");
                }
            }
                //Ask OrderID to modify orders
                Console.WriteLine("Enter order Id");
                string orderID=Console.ReadLine();
                for(int i=0;i<order.Count;i++)
                {
                    if(UESRLOGINID.CustomerID.Equals(order[i].CustomerID))
                    {
                        if(order[i].OrderStatus.Equals(Status.Ordered))
                        {
                           //Then fetch the item details of corresponding order and show it
                           for(int j=0;j<item.Count;j++)
                           {
                            Console.WriteLine($"ItemId {item[j].ItemID}|FoodId {item[j].FoodID}|OrderId {item[j].OrderID}|PriceOfOrder {item[j].PriceOfOrder}|Purchase count{item[j].PurchaseCount}");
                            //Ask ItemID and check ItemID is valid
                            Console.WriteLine("Enter Item Id ");
                            string itemID=Console.ReadLine();
                            if(itemID.Equals(item[i].ItemID))
                            {
                                Console.WriteLine("Enter the quantity");
                                int quantity=int.Parse(Console.ReadLine());
                                double price=food[i].PricePerQuantity*quantity;
                                UESRLOGINID.DeductBalance(price);
                                OrderDetails order1=new OrderDetails(UESRLOGINID.CustomerID,(int)price,DateTime.Now,Status.Ordered);
                                Console.WriteLine("Order Id "+(order[i].OrderID)+" Modified Successfully");
                            }
                           }
                        }
                    }
                }

            
        }
        //OrderHistory
        public static void OrderHistory()
        {
            //Show the order history of the current logged-in user
            for(int i=0;i<order.Count;i++)
            {
                if(UESRLOGINID.CustomerID.Equals(order[i].CustomerID))
                {
                    Console.WriteLine($"orderID {order[i].OrderID}|CustomerID {order[i].CustomerID}|Total Price {order[i].TotalPrice}|Date Of Order {order[i].DateOfOrder}|Order Status {order[i].OrderStatus}");
                }
            }
        }//OrderHistory ends here

        //Wallet Recharge
        public static void RechargeWallet()
        {
            //Ask the user to enter the amount to be recharged. 
            Console.WriteLine("Enter your Amount");
            double amount=double.Parse(Console.ReadLine());
            //Deposit the recharge amount to current user’s wallet
            UESRLOGINID.WalletRecharge(amount);
            Console.WriteLine("Your Current Balance "+UESRLOGINID.WalletBalance);
            
        }//Wallet Recharge ends here

        //Show Wallet Balance
        public static void ShowWalletBalance()
        {
            Console.WriteLine("Your Balance "+UESRLOGINID.WalletBalance);
        }//Show Wallet Balance ends here

        //Adding Default Values
        public static void DefaultValues()
        {
            //Customer Details
            CustomerDetails customer1=new CustomerDetails(10000	,"Ravi","Ettapparajan",Gender.Male,"	974774646",new DateTime(1999/11/11),	"ravi@gmail.com",	"Chennai");
            CustomerDetails customer2=new CustomerDetails(15000,	"Baskaran"	,"Sethurajan"	,Gender.Male	,"847575775	",new DateTime(1999/11/11),	"baskaran@gmail.com","	Chennai");
            customer.Add(customer1);
            customer.Add(customer2);
            //Food Details
           /* FoodDetails food1=new FoodDetails("Chicken Briyani 1Kg",100	,12);
            FoodDetails food2=new FoodDetails("Mutton Briyani 1Kg",150,10);
            FoodDetails food3=new FoodDetails("Veg Full Meals",	80	,30);
            FoodDetails food4=new FoodDetails("Noodles",100	,40);
            FoodDetails food5=new FoodDetails("Dosa",40,40);
            FoodDetails food6=new FoodDetails("Idly (2 pieces)",20,50);
            FoodDetails food7=new FoodDetails("Pongal",40,20);
            FoodDetails food8=new FoodDetails("Vegetable Briyani",80,15);
            food.Add(food1);
            food.Add(food2);
            food.Add(food3);
            food.Add(food4);
            food.Add(food5);
            food.Add(food6);
            food.Add(food7);
            food.Add(food8);*/
            //OrderDetails
            OrderDetails order1=new OrderDetails("CID1001",	580	,new DateTime(2022/11/26),Status.Ordered);
            OrderDetails order2=new OrderDetails("CID1002",	870,new DateTime(2022/11/26),Status.Ordered);
            OrderDetails order3=new OrderDetails("CID1001",820,new DateTime(2022/11/26),Status.Cancelled);
            order.Add(order1);
            order.Add(order2);
            order.Add(order3);
            //Item Details
            ItemDetails item1=new ItemDetails("OID3001","FID2001",2,200);
            ItemDetails item2=new ItemDetails("OID3001","FID2002",	2	,300);
            ItemDetails item3=new ItemDetails("OID3001","FID2003",	1	,80);
            ItemDetails item4=new ItemDetails("OID3002","FID2001",	1	,100);
            ItemDetails item5=new ItemDetails("OID3002","FID2002",	4	,600);
            ItemDetails item6=new ItemDetails("OID3002","FID2010",	1	,120);
            ItemDetails item7=new ItemDetails("OID3002","FID2009",	1	,50);
            ItemDetails item8=new ItemDetails("OID3003","FID2002",	2	,300);
            item.Add(item1);
            item.Add(item2);
            item.Add(item3);
            item.Add(item4);
            item.Add(item5);
            item.Add(item6);
            item.Add(item7);
            item.Add(item8);

           /* //Customer Details Traversing
            for(int i=0;i<customer.Count;i++)
            {
                Console.WriteLine($"{customer[i].Name}|{customer[i].FatherName}|{customer[i].Gender}|{customer[i].Mobile}|{customer[i].DOB}|{customer[i].MailID}|{customer[i].WalletBalance}");
            }
            Console.WriteLine();
            //Orders Traversing
            for(int i=0;i<order.Count;i++)
            {
                Console.WriteLine($"{order[i].OrderID}|{order[i].CustomerID}{order[i].TotalPrice}|{order[i].DateOfOrder}|{order[i].OrderStatus}");
            }
            Console.WriteLine();
            //Item Details
            for(int i=0;i<item.Count;i++)
            {
                Console.WriteLine($"{item[i].ItemID}|{item[i].OrderID}|{item[i].FoodID}|{item[i].PurchaseCount}|{item[i].PriceOfOrder}");
            }*/
        }//Adding Default Values
    }
}