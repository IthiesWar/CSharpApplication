using System;
using System.Reflection.Metadata;
namespace EmployeePayRoll;
class Program{
        static List<Emplyoee> employee=new List<Emplyoee>();
    public static void Main(string[] args)
    {
       
        while(true)
        {
            Console.WriteLine("Menu->");
            Console.WriteLine("Enter 1 for->Registeration");
            Console.WriteLine("Entre 2 for->Login");
            Console.WriteLine("Enter 3 for->Exit");
            Console.WriteLine("Enter your choice");
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
                Environment.Exit(0);
                break;
                default:
                Console.WriteLine("Give Correct choice");
                break;
            }
        }
    }
    static void Register()
    {  
        string option="";
         do{
        Console.WriteLine("Enter the EmployeeName:");
        string EmployeeName=Console.ReadLine();
        Console.WriteLine("Enter the Role:");
        string Role=Console.ReadLine();
        Console.WriteLine("Enter the location:");
        Location Location=(Location)Enum.Parse(typeof(Location),Console.ReadLine(),true);
        Console.WriteLine("Enter the team name:");
        string TeamName=Console.ReadLine();
        Console.WriteLine("Date of joining");
        DateTime DOJ=DateTime.ParseExact(Console.ReadLine(),"yyyy-MM-dd",null);
        Console.WriteLine("Enter the leave taken");
        int Leave=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your working days");
        int WorkingDays=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your Gender");
        Gender Gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
        Emplyoee obj=new Emplyoee(EmployeeName,Role,Location,TeamName,DOJ,Leave,WorkingDays,
        Gender);
        employee.Add(obj);
        Console.WriteLine("Restration Successful");
        Console.WriteLine("Employee ID "+obj.EmployeeId);
        Console.WriteLine("Employee Name "+obj.EmployeeName);
        Console.WriteLine("Employee Role "+obj.Role);
        Console.WriteLine("Employee Locatiom "+obj.Location);
        Console.WriteLine("Employee Team Name "+obj.TeamName);
        Console.WriteLine("Employee Date of joining "+obj.DOJ);
        Console.WriteLine("Employee leave taken "+obj.Leave);
        Console.WriteLine("Emplyoo working days "+obj.WorkingDays);
        Console.WriteLine("Emplyoo Gender "+obj.Gender);
        Console.WriteLine("Do you want to Register again");
        option=Console.ReadLine();
    }while(option=="yes");
    }
    static void Login()
    {
        Console.WriteLine("Enter your Employee Id");
        string EmployeeId1=Console.ReadLine();
        Emplyoee obj=null;
        foreach(var i in employee)
        {
            if(i.EmployeeId==EmployeeId1)
            {
                obj=i;
                break;
            }
        }
        if(obj !=null)
        {
            Submenu(obj);
        }
        else
        {
            Console.WriteLine("Wrong EMployeeID");
        }
    }
    static void Submenu(Emplyoee employee)
    {
        do
        {
            Console.WriteLine("SubMenu");
            Console.WriteLine("Enter 1  Calculate Salary");
            Console.WriteLine("Enter 2  Employee Details");
            Console.WriteLine("Enter 3  Exit");
            int choice1=int.Parse(Console.ReadLine());
            switch(choice1)
            {
                case 1:
                CalculateSalary(employee);
                break;
                case 2:
                EmployeeDetail(employee);
                break;
                case 3:
                Console.WriteLine("Thankyou");
                Environment.Exit(0);
                break;
                default:
                Console.WriteLine("Choice correct number");
                break;
            }
                

        }while(true);
    }
    static void CalculateSalary(Emplyoee employee)
    {
        double Salary=500*(employee.Leave-employee.WorkingDays);
        Console.WriteLine("Salary "+Salary);
    }
    static void EmployeeDetail(Emplyoee employee)
    {
        Console.WriteLine("Restration Successful");
        Console.WriteLine("Employee ID "+employee.EmployeeId);
        Console.WriteLine("Employee Name "+employee.EmployeeName);
        Console.WriteLine("Employee Role "+employee.Role);
        Console.WriteLine("Employee Locatiom "+employee.Location);
        Console.WriteLine("Employee Team Name "+employee.TeamName);
        Console.WriteLine("Employee Date of joining "+employee.DOJ);
        Console.WriteLine("Employee leave taken "+employee.Leave);
        Console.WriteLine("Emplyoo working days "+employee.WorkingDays);
        Console.WriteLine("Emplyoo Gender "+employee.Gender);
        }
       
    
}