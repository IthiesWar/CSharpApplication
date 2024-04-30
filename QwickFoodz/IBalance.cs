using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public interface IBalance
    {
        //Properties: WalletBalance
        
        public double WalletBalance { get;  }

        //Method: WalletRecharge, DeductBalance
        public double WalletRecharge(double amount);
        public double DeductBalance(double price);
        
    }
}