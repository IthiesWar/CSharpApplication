using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public class Customerregistration:PersonalDetails,IBalance 
    {
        //Properties: CustomerID {Auto Increment – CID1000}, WalletBalance

        private static int s_customerId=100;
        public string CustomerID { get;  }
        public double WalletBalance { get; set; }
        
        public Customerregistration(double walletBalance,string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID):base( name,fatherName, gender, mobile, dob, mailID)
        {
            CustomerID="C"+s_customerId++;
            WalletBalance=walletBalance;
        }
        public Customerregistration(string customerID,double walletBalance,string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID):base( name,fatherName, gender, mobile, dob, mailID)
        {
            CustomerID=customerID;
            WalletBalance=walletBalance;
        }
         public double WalletRecharge(double amount)
        {
           return WalletBalance+=amount;
           
        }
        
       public Customerregistration(string customer1):base("harshad","khan",Gender.male,44,new DateTime(2000,09,09),"gg")
        {
            string [] values=customer1.Split(",");
            CustomerID=values[0];
            WalletBalance=double.Parse(values[1]);
            Name=values[2];
            FatherName=values[3];
            Gender=Enum.Parse<Gender>(values[4]);
            Mobile=long.Parse(values[5]);
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID=values[7];

        }
       
       
        
    }
}