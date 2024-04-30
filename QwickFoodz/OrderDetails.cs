using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum Status
    {
        Cancelled,
        Initiated,
        Ordered
    }
    public class OrderDetails
    {
        //Properties: OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.
        private static int s_orderID=3001;
        public string OrderID { get;  }
        
        public string CustomerID { get; set; }
        public int TotalPrice { get; set; }
        
        public DateTime DateOfOrder { get; set; }
        
        public Status OrderStatus { get; set; }
        
        public OrderDetails(string customerID,int totalPrice,DateTime dateOfOrder,Status orderStatus)
        {
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
        }
        public OrderDetails(string orders1)
        {
            string []value=orders1.Split(",");
            OrderID=value[0];
            CustomerID=value[1];
            TotalPrice=int.Parse(value[2]);
            DateOfOrder=DateTime.ParseExact(value[3],"dd/MM/yyyy",null);
            OrderStatus=Enum.Parse<Status>(value[4]);
        }
        
        
        
    }
}