using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails:PersonalDetails,IWallet
    {
        //Properties:
        /*
1.	UserID (Auto Increment – UID1001)
2.	WalletBalance*/
        private static int s_userID=1001;
        public string UserID { get; set; }
        
        
        private double _balance;
        public double WalletBalance { get{return _balance;}  }

        public UserDetails(double balance,string name,int age,string city,string phone):base( name, age, city, phone)
        {
            UserID="UID"+s_userID++;
            _balance=balance;
        }
        public double WalletRecharge(double amount)
        {
            return _balance+=amount;
        }
        public double DeductBalance(double price)
        {
            return _balance-=price;
        }
    }
}