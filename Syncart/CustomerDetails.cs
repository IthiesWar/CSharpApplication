using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public class CustomerDetails
    {/*
        •	CustomerID (Auto Increment -CID1000)
•	Name
•	City
•	MobileNumber
•	WalletBalance
•	EmailID*/

        private static int s_customerID=1000;
        public string CustomerID { get;  }
        public string CustomerName { get; set; }
       
        
        
        public string City { get; set; }
         public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailID { get; set; }
        
        
        public CustomerDetails(string customerName,string city,long mobileNumber,double walletBalance,string emailID)
        {
            CustomerID="CID"+s_customerID;
            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            EmailID=emailID;
        }
        
        public double Exachnge(double RechargeAmt)
        {
            WalletBalance+=RechargeAmt;
            return WalletBalance;
        }
        public double deduction(double amount)
        {
            WalletBalance-=amount;
            return WalletBalance;
        }
        
        
    }
}