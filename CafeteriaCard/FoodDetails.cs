using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class FoodDetails
    {
        
        private static int s_foodID=101;
        public string FoodID { get;  }
        
        public string FoodName { get; set; }
        
        public int FoodPrice { get; set; }
        
        public int Quantity { get; set; }
        
        public FoodDetails(string foodName,int foodPrice,int quantity)
        {
            FoodID="FID"+s_foodID++;
            FoodName=foodName;
            FoodPrice=foodPrice;
            Quantity=quantity;
        }
        
        
        
    }
}