using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
        //Field: _balance
        private double _balance;
        //Properties: CustomerID, WalletBalance
        private static int s_customerID=1001;//Field
        public string CustomerID { get;  }
        public double WalletBalance{get{return _balance;}}

        public CustomerDetails(double balance,string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID,string location):base(name,fatherName,gender,mobile,dob,mailID,location)
        {
            CustomerID="CID"+s_customerID++;
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
        public CustomerDetails(string customers):base("Ravi","Ettapparajan",Gender.Male,"974774646",new DateTime(1999/11/11),"ravi@gmail.com","Chennai")
        {
            string [] value=customers.Split(",");
            CustomerID=value[0];
            _balance=double.Parse(value[1]);
            Name=value[2];
            FatherName=value[3];
            Gender=Enum.Parse<Gender>(value[4]);
            Mobile=value[5];
            DOB=DateTime.ParseExact(value[6],"dd/MM/yyyy",null);
            MailID=value[7];
            Location=value[8];
        }


    }
}