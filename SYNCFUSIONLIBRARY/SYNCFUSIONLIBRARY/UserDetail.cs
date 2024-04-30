using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYNCFUSIONLIBRARY
{
    /// <summary>
    /// This is changed the Gender as a Enum type.user only choose only male,female,transgenger
    /// </summary>
    public enum Gender
    {
        Male,
        Female,
        Transgender
    }
    /// <summary>
    /// 
    /// This is department enum type.user only choose below departments only
    /// </summary>
    public enum Department
    {
        ECE,
        EEE,
        CSE
    }
    public class UserDetail
    {
        /*a.	UserID (Auto Increment – SF3000)
b.	UserName
c.	Gender
d.	Department – (Enum – ECE, EEE, CSE)
e.	MobileNumber
f.	MailID*/
    private static int s_userID=3000;
    public string UserID { get;  }
    public string UserName { get; set; }
    public Gender Gender { get; set; }
    public Department Department { get; set; }
    public long MobileNumber { get; set; }
    public string MailID { get; set; }
    public int WalletBalance { get; set; }
    
    
    
    //Parametaried Constructor
    public UserDetail(string userName,Gender gender,Department department,long mobileNumber,string mailID,int walletBalance)
    {
        UserID="SF"+s_userID++;
        UserName=userName;
        Gender=gender;
        Department=department;
        MobileNumber=mobileNumber;
        MailID=mailID;
        WalletBalance=walletBalance;
    }
    public UserDetail(string users2)
    {
        string []values=users2.Split(",");
        UserID=values[0];
        UserName=values[1];
        Gender=Enum.Parse<Gender>(values[2]);
        Department=Enum.Parse<Department>(values[3]);
        MobileNumber=long.Parse(values[4]);
        MailID=values[5];
        WalletBalance=int.Parse(values[6]);
    }
    
    //Wallet Exchange Method
    public int Exchange(int recharAmount)
    {
        return WalletBalance+=recharAmount;
    }
    //Deduction
    public int Decution(int amount)
    {
        return WalletBalance-=amount;
    }
    
    }
}