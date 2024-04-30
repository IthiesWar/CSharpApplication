using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class FileHandling
    {
        //File Creation
        public static void Create()
        {
            if(!Directory.Exists("QwickFoodz"))
            {
                Console.WriteLine("File Creating....");
                Directory.CreateDirectory("QwickFoodz");
            }
            if(!File.Exists("CustomerDetails"))
            {
                Console.WriteLine("File Creating....");
                File.Create("QwickFoodz/CustomerDetails.csv").Close();
            }
            if(!File.Exists("FoodDetails"))
            {
                Console.WriteLine("File Creating....");
                File.Create("QwickFoodz/FoodDetails.csv").Close();
            }
            if(!File.Exists("OrderDetails"))
            {
                Console.WriteLine("File Creating....");
                File.Create("QwickFoodz/OrderDetails.csv").Close();
            }
            if(!File.Exists("ItemDetails"))
            {
                Console.WriteLine("File Creating....");
                File.Create("QwickFoodz/ItemDetails.csv").Close();
            }
        }
        public static void WriteCsv()
        {
            //customer
            string[]customer=new string[Operation.customer.Count];
            for(int i=0;i<Operation.customer.Count;i++)
            {
                customer[i]=Operation.customer[i].CustomerID+","+Operation.customer[i].WalletBalance+","+Operation.customer[i].Name+","+Operation.customer[i].FatherName+","+Operation.customer[i].Gender+","+Operation.customer[i].Mobile+","+Operation.customer[i].DOB+","+Operation.customer[i].MailID+","+Operation.customer[i].Location;
            }
            File.WriteAllLines("QwickFoodz/CustomerDetails.csv",customer);
            //Food Details
            string []foods=new string[Operation.food.Count];
            for(int i=0;i<Operation.food.Count;i++)
            {
                foods[i]=Operation.food[i].FoodID+","+Operation.food[i].FoodName+","+Operation.food[i].PricePerQuantity+","+Operation.food[i].QuantityAvailable;
            }
            File.WriteAllLines("QwickFoodz/FoodDetails.csv",foods);
            //Orders
            string[] orders=new string[Operation.order.Count];
            for(int i=0;i<Operation.order.Count;i++)
            {
                orders[i]=Operation.order[i].OrderID+","+Operation.order[i].CustomerID+","+Operation.order[i].TotalPrice+","+Operation.order[i].DateOfOrder+","+Operation.order[i].OrderStatus;
            }
            File.WriteAllLines("QwickFoodz/OrderDetails.csv",orders);
            //Items
            string[] items=new string[Operation.item.Count];
            for(int i=0;i<Operation.item.Count;i++)
            {
                items[i]=Operation.item[i].ItemID+","+Operation.item[i].OrderID+","+Operation.item[i].FoodID+","+Operation.item[i].PurchaseCount+","+Operation.item[i].PriceOfOrder;
            }
            File.WriteAllLines("QwickFoodz/ItemDetails.csv",items);
        }
        public static void ReadCsv()
        {
            //CustomersDetails
            string[]customer=File.ReadAllLines("QwickFoodz/CustomerDetails.csv");
            foreach(string customers in customer)
            {
                CustomerDetails customer1=new CustomerDetails(customers);
                Operation.customer.Add(customer1);
            }
            //FoodDetails
            string[]foods=File.ReadAllLines("QwickFoodz/FoodDetails.csv");
            foreach(string foods1 in foods)
            {
                FoodDetails food1=new FoodDetails (foods1);
                Operation.food.Add(food1);
            }
            //OrderDetails
            string[]orders=File.ReadAllLines("QwickFoodz/OrderDetails.csv");
            foreach(string orders1 in orders)
            {
                OrderDetails order2=new OrderDetails(orders1);
                Operation.order.Add(order2);
            }
            //ItemDetails
           
        }
    }
}