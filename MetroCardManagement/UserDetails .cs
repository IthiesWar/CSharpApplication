using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails:PersonalDetails,IBalance//Inherit
    {
       
        private static int s_cardNumber=1001;//Field
        public string CardNumber { get;  }//get only property
        private double _balance;
        public double Balance { get{return _balance;}  }//properties

    public  UserDetails(double balance,string userName,long phoneNumber):base( userName, phoneNumber)//parametraized Constructor
    {
        CardNumber="CMRL"+s_cardNumber++;
        _balance=balance;
    }
    //Becuase of CardNumber assigning for each user seperatly
    public  UserDetails(string cardNumber,int balance,string userName,long phoneNumber):base( userName, phoneNumber)//parametraized Constructor
    {
        CardNumber=cardNumber;
        _balance=balance;
    }
    public  UserDetails(string user1):base("ravi",984888345)//FileHandling Readobject creation
    {
        string[]values=user1.Split(",");
        CardNumber=values[0];
        _balance=int.Parse(values[1]);
        UserName=values[2];
        PhoneNumber=long.Parse(values[3]);
    }
    
    public double WalletRecharge(int amount)//methods
    {
        return _balance+=amount;
    }
    public double DeductBalance(int price)//methods
    {
        return _balance-=price;
    }
    

    }
}