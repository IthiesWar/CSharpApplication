using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public static class Operations
    {
        //Global variable for store login details
        static EmployeeDetails LOGINUSERID;
        //crearting list for employee details
        static List<EmployeeDetails> emplist=new List<EmployeeDetails>();
        //creating list for Attendance deatils
        static List<AttendanceDetails> attendance=new List<AttendanceDetails>();
        //MainMenu Starts here
        public static void MainMenu()
        {
            //initilizing bool for stop the loop
            bool value=true;
            do
            {
                Console.WriteLine("Syncfusion Software Private Limited ");
                Console.WriteLine("MainMenu\n1. Registeration\n2. Login\n3. Exit");
                //getting choice from the user
                Console.WriteLine("Entre your choice");
                int mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("******Registration******");
                        Registration();
                        break;

                    }
                    case 2:
                    {
                        Console.WriteLine("****Login*****");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Exit*****");
                        value=false;
                        Console.WriteLine("*****Exit Successfully****");
                        break;
                    }
                }

            }while(value);
        }//MainMenu ends here
        //Registration Starts here
        public static void Registration()
        {
            //Getting user details
            Console.WriteLine("Enter yoyr name");
            string name=Console.ReadLine();
            Console.WriteLine("Enter your date of birth dd-mm-yyyy");
            DateTime dateOfBirth=DateTime.ParseExact(Console.ReadLine(),"dd-MM-yyyy",null);
            Console.WriteLine("Enter your phone number");
            long mobileNumber=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your gender");
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.WriteLine("Enter your branch ");
            Branch branch=(Branch)Enum.Parse(typeof(Branch),Console.ReadLine(),true);
            Console.WriteLine("Enter your team");
            Team team=(Team)Enum.Parse(typeof(Team),Console.ReadLine(),true);
            //Creating object 
            EmployeeDetails empobject=new EmployeeDetails(name,dateOfBirth,mobileNumber,gender,branch,team);
            //adding to the list
            emplist.Add(empobject);
            //printing employee id
            Console.WriteLine("Employee added successsfully your id: "+empobject.EmployeeID);
        }   //Registration ends here
        //Login starts here
        public static void Login()
        {
            //TO stop the loop
            bool value=true;
            //getting user login id
            Console.WriteLine("Enter your login id");
            string loginID=Console.ReadLine();
            foreach(EmployeeDetails employee in emplist)
            {
                if(loginID.Equals(employee.EmployeeID))
                {
                    LOGINUSERID=employee;
                    Console.WriteLine("Login successfully");
                    SubMenu();
                    value=false;
                    break;

                }
            }
            if(value)
            {
                Console.WriteLine("Invalid user id");
            }
        }
        //SubMenu starts here
        public static void SubMenu()
        {
            //for stoping the loop
            bool value=true;
            do
            {
            Console.WriteLine("SubMenu\n1. Add Attendance\n2. Display Details\n3. Calculate Salary\n4. Exit");
            Console.WriteLine("Enter your choice");
            int subMenuChoice=int.Parse(Console.ReadLine());
            switch(subMenuChoice)
            {
                case 1:
                {
                    Console.WriteLine("****Add Attendance*****");
                    AddAttendance();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Display Details");
                    ShowDetails();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("****Calculate salary");
                    CalculateSalary();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("****Exit****");
                    Console.WriteLine("Exit Successfully");
                    value=false;
                    break;
                }
            }
            }while(value);
        }//Submenu ends here
        //Add Attendance starts here
        public static void AddAttendance()
        {
            //Need to ask the user whether he want to check-in or check out
            Console.WriteLine("Do you want to check in press 1");
            Console.WriteLine();
            Console.WriteLine("Do you want to check out press 2");
            
            DateTime dates;
            DateTime dates1;

            //Ask the user to check in date and time
            Console.WriteLine("Enter your check in date time yyyy-MM-dd HH:mm");
            dates = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);

            //Ask the user to check out time and date
            Console.WriteLine("Enter your check out in date time yyyy-MM-dd HH:mm");
            dates1 = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);
            TimeSpan total=dates1 - dates;
            double hours=total.TotalHours;


            //creating object for attendance details
            AttendanceDetails attendanceobj=new AttendanceDetails(LOGINUSERID.EmployeeID,DateTime.Now,dates,dates1,hours);
            attendance.Add(attendanceobj);
            Console.WriteLine("Check-in and Checkout Successful and today you have worked 8 Hours "+(int)hours);

        }//Add attendance ends here

        //show details starts here
        public static void ShowDetails()
        {
            foreach(AttendanceDetails attend in attendance)
            {
                
            
                    Console.WriteLine($"{LOGINUSERID.EmployeeID}|{LOGINUSERID.EmployeeName}|{LOGINUSERID.DOB}|{LOGINUSERID.MobileNumber}|{LOGINUSERID.Gender}|{LOGINUSERID.Branch}|{LOGINUSERID.Team}|{attend.CheckInTime}|{attend.CheckOutTime}|{attend.HoursWorked}");
                

             } }
        //show details ends here

        //Calcluate salary starts here
        public static void CalculateSalary()
        {
            foreach(AttendanceDetails attend1 in attendance)
            {

                    double salary=attend1.HoursWorked*500;
                    Console.WriteLine("Your total salary "+salary);
            } 
        }//Calculate salary ends here
    }

    }
