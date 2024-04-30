using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public enum Status
    {
        Initiated, Ordered, Cancelled
    }
    public class OrderDetails
    {
        /*Properties:
•	OrderID (Auto – OID1001)
•	UserID
•	OrderDate
•	TotalPrice
•	OrderStatus – (Default, Initiated, Ordered, Cancelled)
*/
    private static int s_orderID=1001;
    public string OrderID { get;  }

    public string UserID { get; set; }
    
    
    public DateTime OrderDate { get; set; }
    public int TotalPrice { get; set; }
    public Status OrderStatus { get; set; }
    
    
    public OrderDetails(string userID,DateTime orderDate,int totalPrice,Status orderStatus)
    {
        OrderID="OID"+s_orderID++;
        UserID=userID;
        OrderDate=orderDate;
        TotalPrice=totalPrice;
        OrderStatus=orderStatus;
    }
    
    
    
    
    
    }
}