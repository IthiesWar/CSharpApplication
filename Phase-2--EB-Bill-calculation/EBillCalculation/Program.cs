using System;
using System.Collections.Generic;
namespace EBillCalculation;
class Program{
    static List<EbBill> ebbill=new List<EbBill>();
    public static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("Enter 1 Registration");
            Console.WriteLine("Enter 2 Login");
            Console.WriteLine("Enter 3 Exit");
            Console.WriteLine("Enter your Choice");
            int choice=int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                Register();
                break;
                case 2:
                Login();
                break;
                case 3:
                Console.WriteLine("Thankyou");
                Environment.Exit(0);
                break;
                default:
                Console.WriteLine("Enter the Correct choice");
                break;
            }
        }
    }
    static void Register()
    {
        Console.WriteLine("Enter UserName");
        string UserName=Console.ReadLine();
        Console.WriteLine("Enter phone Number");
        long Phone=long.Parse(Console.ReadLine());
        Console.WriteLine("Enter your MailId");
        string MailId=Console.ReadLine();
        Console.WriteLine("Enter the units");
        double Units=double.Parse(Console.ReadLine());
        Console.WriteLine("Registration Successful");
        EbBill obj=new EbBill(UserName,Phone,MailId,Units);
        ebbill.Add(obj);
        Console.WriteLine("Meter Id "+obj.MeterId);
    }
    static void Login()
    {
        Console.WriteLine("Enter your EbNumber");
        string EbNumber1=Console.ReadLine();
        EbBill obj=null;
        foreach(var i in ebbill)
        {
            if(i.MeterId==EbNumber1)
            {
                obj=i;
                break;
            }
        }
        if(obj != null)
        {
            Submenu(obj);
        }
        else
        {
            Console.WriteLine("Wrong MeterId");
        }
    }
    static void Submenu(EbBill ebbill)
    {
       do
       {
        Console.WriteLine("SubMenu");
        Console.WriteLine("Enter 1 Calculate");
        Console.WriteLine("Enter 2 Display Details");
        Console.WriteLine("Enter 3 for Exit");
        int choice1=int.Parse(Console.ReadLine());
        switch(choice1)
        {
            case 1:
            CalculateAmount(ebbill);
            break;
            case 2:
            UserDetails(ebbill);
            break;
            case 3:
            Console.WriteLine("Thankyou");
            Environment.Exit(0);
            break;
            default:
            Console.WriteLine("Enter the correct choice");
            break;

        }
       }while(true);
    }
    static void CalculateAmount(EbBill ebbill)
    {
        double Amount=ebbill.Units*5;
        Console.WriteLine("User Id "+ebbill.MeterId);
        Console.WriteLine("User Name "+ebbill.UserName);
        Console.WriteLine("Unit "+ebbill.Units);
        Console.WriteLine("Amount "+Amount);
    }
    static void UserDetails(EbBill ebbill)
    {
        Console.WriteLine("Meter Id "+ebbill.MeterId);
        Console.WriteLine("User Name "+ebbill.UserName);
        Console.WriteLine("Phone Number "+ebbill.Phone);
        Console.WriteLine("Mail Id "+ebbill.MailId);
    }
}