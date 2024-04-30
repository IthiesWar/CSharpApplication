using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public interface IBalance
    {
        //Properties: WalletBalance
        public double WalletBalance { get; set; }
        public double WalletRecharge(double amount);
        
    }
}