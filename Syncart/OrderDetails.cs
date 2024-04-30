using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public enum Status 
    {
        Default,
        Ordered,
        Cancelled
    }
    public class OrderDetails
    {
    private static int s_orderID=1001;
    public string OrderID { get;}
    public string CustomerID { get; set; }
    public string ProductID { get; set; }
    public double TotalPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public double Quantity { get; set; }

    public Status OrderStatus{get;set;}

    public OrderDetails(string customerID,string productID,double totalPrice,DateTime purchaseDate,double quantity,Status orderStatus )
    {
        OrderID="OID"+s_orderID;
        CustomerID=customerID;
        ProductID=productID;
        TotalPrice=totalPrice;
        PurchaseDate=purchaseDate;
        Quantity=quantity;
        OrderStatus=orderStatus;
    }
    
    
    
    
    
    
    
    
    
    
    
    

    }
}