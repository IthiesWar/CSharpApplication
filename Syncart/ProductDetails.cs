using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public class ProductDetails
    {
     /*   •	ProductID (Auto Increment – PID101)
•	ProductName
•	Price
•	Stock 
•	ShippingDuration*/
    private static int s_productID=101;
    public string ProductID { get;  }
    public string ProductName { get; set; }
    public double Stock { get; set; }
    public double Quantity { get; set; }
    
    
    public double ShipingDuration { get; set; }
    
    
    
    public ProductDetails(string productName,double stock,double quantity,double shipingDuration)
    {
        ProductID="PID"+s_productID;
        ProductName=productName;
        Stock=stock;
        Quantity=quantity;
        ShipingDuration=shipingDuration;
    }
    
    
    
    

    }
}