using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class UserDetails :PersonalDetails,IBalance
    { 
        
        private static int s_userID=1001;
        public string UserID { get; set; }
        public int WorkStationNumber { get; set; }
        
        
        public double Balance  { get;set; }

        public UserDetails(int workStationNumber,double balance,string name,string fatherName,Gender gender,long mobile,string mailID):base(name, fatherName, gender,mobile,mailID)
        {
            UserID="SF"+s_userID++;
            WorkStationNumber=workStationNumber;
            Balance=balance;
        }
        
        public void WalletRecharge(int amount)
        {
            Balance+=amount;
            Console.WriteLine(Balance);
        }
        public void DeductAmount()
        {
            int totalPrice=int.Parse(Console.ReadLine());
            Balance-=totalPrice;
        }
        
    }
}