using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public interface IBalance//Inteface
    {
        public double Balance  { get; set; }//Property
        
        //WalletRecharge, DeductAmount
        public void WalletRecharge(int amount);
        public void DeductAmount();
    }
}