using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class OrderDetails
    {
        //Properties: OrderID {Auto Increment – OID4000}, BookingID, ProductID, PurchaseCount, PriceOfOrder
        private static int s_orderID=4000;
        public string OrderID { get;  }
        public string BookingID { get; set; }
        public string ProductID { get; set; }
        
        public int PurchaseCount { get; set; }
        public int PriceOfOrder { get; set; }
        
        public OrderDetails(string bookingID,string productID,int purchaseCount,int priceOfOrder)
        {
            OrderID="OID"+s_orderID++;
            BookingID=bookingID;
            ProductID=productID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }
        
        
        
        
        
        
    }
}