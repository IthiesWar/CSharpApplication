using System;
using System.Collections.Generic;
namespace CollegeAdmission;
class Program{

    //List For StudentDetailsClass
    static List<StudentDetailsClass> stutendobj=new List<StudentDetailsClass>();
    //List For DepartmentDetails
    static List<DepartmentDetails> stutendobj2=new List<DepartmentDetails>();
    //List For AdmissionDetails
    static List<AdmissionDetails> stutendobj3=new List<AdmissionDetails>();
    public static void Main(string[] args)
    {
        //While For printing the Syncfusion College of Engineering and Technology on Top of the Console
        while(true)
        {
            Console.WriteLine("Syncfusion College of Engineering and Technology");
            break;
        }
        /*enu For Students to Choose 

        */
        do
        {
            Console.WriteLine("");
            Console.WriteLine("1.Student Registration");
            Console.WriteLine("2.Student Login");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Enter your Choice Below:");
            int Choice1=int.Parse(Console.ReadLine());
            switch(Choice1)
            {
                case 1:
                StutendRegisteration();
                break;
                case 2:
                StutendLogin();
                break;
                case 3:
                Environment.Exit(0);
                break;
            }
        }while(true);
        
    }
    static void StutendRegisteration()
    {
        Console.WriteLine("Enter your Name:");
        string StutendName=Console.ReadLine();
        Console.WriteLine("Enter your Father Name:");
        string FatherName=Console.ReadLine();
        Console.WriteLine("Enter your Date Of Birth:");
        DateTime DateOfBirth=DateTime.ParseExact(Console.ReadLine(),"yyyy-MM-dd",null);
        Console.WriteLine("Enter your Gender:");
        Gender Gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
        Console.WriteLine("Enter your Physics Mark:");
        double Physics=double.Parse(Console.ReadLine());
        Console.WriteLine("Enter your Chemistry Mark:");
        double Chemistry=double.Parse(Console.ReadLine());
        Console.WriteLine("Enter your Maths Mark:");
        double Maths=double.Parse(Console.ReadLine());

        StudentDetailsClass obj1=new StudentDetailsClass(StutendName,FatherName,DateOfBirth,Gender,Physics,Chemistry,Maths);
        stutendobj.Add(obj1);
        Console.WriteLine("Student Registerd Successfully "+obj1.StutendId);
    }

    static void StutendLogin()
    {
        Console.WriteLine("Enter your StutendId Below:");
        string GivenStudId=Console.ReadLine();
        StudentDetailsClass obj1=null;
        foreach(var i in stutendobj)
        {
            if(i.StutendId==GivenStudId)
            {
                obj1=i;
                break;
            }
        }
        if(obj1 != null)
        {
            Submenu(obj1);
        }
        else
        {
            Console.WriteLine("StudentId is Invalid");
        }
    }

    static void Submenu(StudentDetailsClass stutendobj)
    {
        do
        {
            Console.WriteLine("1.Check Eligibility");
            Console.WriteLine("2.Show Details");
            Console.WriteLine("3.Take Admission");
            Console.WriteLine("4.Cancel Admission");
            Console.WriteLine("5.Show Admission Details");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter your choice for");
            int choice2=int.Parse(Console.ReadLine());

            switch(choice2)
            {
                case 1:
                bool result=stutendobj.AverageCalculation(stutendobj.Physics,stutendobj.Chemistry,stutendobj.Maths);
                break;
                case 2:
                ShowStutendDetails(stutendobj);
                break;
                case 3:
                GetAdmisionDetails();
                ValidateDepartment();
                break;
                case 4:
                Cancelled();
                break;
                case 5:
                ShowAdmissionDetails();
                break;
                case 6:
                Environment.Exit(0);
                break;


            }

        }while(true);
    }
   


    static void ShowStutendDetails(StudentDetailsClass stutendobj)
    {
        Console.WriteLine("Studend Id "+stutendobj.StutendId);
        Console.WriteLine("Studend Name "+stutendobj.StutendName);
        Console.WriteLine("Father Name "+stutendobj.FatherName);
        Console.WriteLine("Date Of Birth "+stutendobj.DateOfBirth);
        Console.WriteLine("Gender "+stutendobj.Gender);
        Console.WriteLine("Physics "+stutendobj.Physics);
        Console.WriteLine("Chemistry "+stutendobj.Chemistry);
        Console.WriteLine("Maths "+stutendobj.Maths);
    }

    static void GetAdmisionDetails()
    {   
        string option="";
        bool value=false;
        do{
        Console.WriteLine("Enter the Department Name");
        string DepartmentName=Console.ReadLine();
        Console.WriteLine("Enter the NumberOfSeats");
        int NumberOfSeats=int.Parse(Console.ReadLine());
        DepartmentDetails obj2=new DepartmentDetails(DepartmentName,NumberOfSeats);
        stutendobj2.Add(obj2);
        Console.WriteLine("DepartMent Id "+obj2.DepartmentId);
        Console.WriteLine("Your Departmen Name "+obj2.DepartmentName);
        Console.WriteLine("Do you want add another Department");
        option=Console.ReadLine();
        if(option=="yes")
        {
            value=true;
        }
        else
        {
            break;
        }
        }while(value);
    }
    
    static void ValidateDepartment()
    {
        Console.WriteLine("Enter the Department Id");
        string GivenDeptId=Console.ReadLine();
        DepartmentDetails obj2=null;
        foreach(var i in stutendobj2)
        {
            if(i.DepartmentId==GivenDeptId)
            {
                obj2=i;
                break;
            }
        }
        if(obj2 != null)
        {
            Console.WriteLine("Eligible to Take Admission");
        }
        else
        {
            Console.WriteLine("Not Eligible to Take Admission");
        }
        
        if(obj2.NumberOfSeats>0)
        {
            Console.WriteLine("Eligible for Admisiion");
        }
        else
        {
            Console.WriteLine("Number Of Not Available");
        }
        
        Console.WriteLine("Enter the StutendId For Admission");
        string StudentdID_Admission=Console.ReadLine();
        Console.WriteLine("Enter the DepartmentId For Admission");
        string DepartmentID_Admission=Console.ReadLine();
        Console.WriteLine("Enter the DateTime For Admission");
        DateTime AdmissionDate=DateTime.ParseExact(Console.ReadLine(),"yyyy-MM-dd",null);
        Console.WriteLine("Enter the Admission Status For Admission");
        Admissionstatus Status=(Admissionstatus)Enum.Parse(typeof(Admissionstatus),Console.ReadLine(),true);
        bool value=true;
        foreach(var i in stutendobj3)
        {
            if(StudentdID_Admission != i.StudentdIdAdmission && DepartmentID_Admission != i.DepartmentIdAdmission)
            {
                obj2.NumberOfSeats--;
                break;
            }
            else
            {
                value=false;
            }
        }
        if(!value)
        {
            Console.WriteLine("Booked");
        }
        else
        {
            AdmissionDetails obj3=new AdmissionDetails(StudentdID_Admission,DepartmentID_Admission,AdmissionDate,Status);
            stutendobj3.Add(obj3);
            Console.WriteLine("Admission took Successfully.Your Id id "+obj3.AdmissionId);
        }

    }
    static void Cancelled()
    {   
        
        foreach(var i in stutendobj3)
        {
            if(i.Status.Equals("Booked"))
            {
                Console.WriteLine("Admission Id "+i.AdmissionId);
                Console.WriteLine("Admission Date "+i.AdmissionDate);
                Console.WriteLine("Admission Status "+i.Status);
                i.Status=Admissionstatus.Cancelled;
                
            }
        foreach(var j in stutendobj2)
        {
            if(j.DepartmentId==i.AdmissionId)
            {
                j.NumberOfSeats--;
            }
        }

        }

    }
    static void ShowAdmissionDetails()
    {
        foreach(var i in stutendobj3)
        {
        Console.WriteLine("Admission Id "+i.AdmissionId);
        Console.WriteLine("Department Id "+i.DepartmentIdAdmission);
        Console.WriteLine("Admission Date "+i.AdmissionDate);
        Console.WriteLine("Admission Status "+i.Status);
        break;
        }
    }

}

    