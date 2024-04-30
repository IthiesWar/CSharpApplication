using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance//Interface
    {
        
    public double Balance { get;  }//properties
    
    public double WalletRecharge(int amount);//methods
    public double DeductBalance(int price);//methods
    
    }
}