using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public enum Status
    {
        purchased,Cancelled
    }
    public class OrderDetails
    {
        /*
        Properties:
a.	OrderID (Auto increment - OID2001)
b.	UserID
c.	MedicineID
d.	MedicineCount
e.	TotalPrice
f.	OrderDate
g.	OrderStatus {Enum – Purchased, Cancelled}
*/
      private static int s_orderID=2001;
       public string OrderID { get;  }
       public string  UserID{ get; set; }
       public string MedicineID { get; set; }
       public int MedicineCount { get; set; }
       
       
       public int TotalPrice { get; set; }
       
       public DateTime OrderDate { get; set; }
       
       public Status OrderStatus{ get; set; }
       
       public OrderDetails(string userID,string medicineID,int medicineCount,int totalPrice,DateTime orderDate,Status orderStatus)
       {
           OrderID="OID"+s_orderID++;
           UserID=userID;
           MedicineID=medicineID;
           MedicineCount=medicineCount;
           TotalPrice=totalPrice;
           OrderDate=orderDate;
           OrderStatus=orderStatus;
       }
       
       
       
       
       
    }
}