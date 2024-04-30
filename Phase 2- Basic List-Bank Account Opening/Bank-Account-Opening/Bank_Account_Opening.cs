using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_Account_Opening
{ public enum Gender
            {
                male,
                Female,

                Transgender
            }
    public class BankAccountOpening
    {
           
            public string CustomerID { get; set; }
            public string Customer Name { get; set; }

            public double  Balance { get; set; }
            public Gender gender { get; set; }
            
            
            public long Phone { get; set; }
            public string MailId { get; set; }
            public DateTime DOB { get; set; }

            public BankDetails(string customerID,string customerName,double balance,Gender gender,
            long phone,string mailId,DateTime dob)
            {
                CustomerID =customerID;
                CustomerName = customerName;
                Balance=balance;
                Gender=gender;
                Phone=phone;
                mailId=mailId;
                DOB=dob;
            } 

        
    }

}