using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public interface IWallet
    {
        public double WalletBalance { get;  }
        public double WalletRecharge(double amount);
        public double DeductBalance(double price);

        
        
    }
}