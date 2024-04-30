using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class ProductDetails
    {
        //Properties: ProductID {Auto Increment – PID2000}, ProductName, QuantityAvailable, PricePerQuantity
        private static int s_productID=2000;
        public string ProductID { get;  }
        public string ProductName { get; set; }
        public int  QuantityAvailable { get; set; }
        public int PricePerQuantity { get; set; }
        public ProductDetails(string productName,int quantityAvailable,int pricePerQuantity)
        {
            ProductID="PID"+s_productID++;
            ProductName=productName;
            QuantityAvailable=quantityAvailable;
            PricePerQuantity=pricePerQuantity;
        }
        
        
        
        
        
        
        
        
    }
}