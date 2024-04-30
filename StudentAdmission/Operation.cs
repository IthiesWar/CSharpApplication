using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public static class Operation
    {
        static StudentDetails StudentLoggedInId;
       public static List<StudentDetails> studentlist=new List<StudentDetails>();
       public static List<DepartmentDetails> departmentlist=new List<DepartmentDetails>();
       public static List<AdmissionDetails> admissionlist=new List<AdmissionDetails>();

       
        public static void MainMenu()
        {
            bool value=true;
            do
            {
                Console.WriteLine("********Syncfusion college of engineering");
                Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Department wise Seat Availability\n4. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your Choice");
                int mainMenu=int.Parse(Console.ReadLine());
                switch(mainMenu)
                {
                    case 1:
                    {
                        Console.WriteLine("****Registration*****");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("***Login****");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Department wise seat availability");
                        DepartmentWiseSeatAvailability();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Successfully Exit");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }
        public static void Registration()
        {
            Console.Write("Enter your Name: ");
            string studentName=Console.ReadLine();
            Console.Write("Enter your father name: ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your Date of Birth: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"yyyy,MM,dd",null);
            Console.Write("Enter your Gender: ");
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.Write("Enter your physics mark: ");
            int physics=int.Parse(Console.ReadLine());
            Console.Write("Enter your chemistry mark: ");
            int chemistry=int.Parse(Console.ReadLine());
            Console.Write("Enter your maths mark: ");
            int maths=int.Parse(Console.ReadLine());

            StudentDetails studentobject=new  StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);

            studentlist.Add(studentobject);
            Console.WriteLine();
            Console.WriteLine("Student Registered successfully and Student Id "+studentobject.StudentID);

        }
        public static void Login()
        {
            Console.WriteLine("Enter your Login Id");
            string loginID=Console.ReadLine();
            bool value=true;
            foreach(StudentDetails student in studentlist)
            {
                
                if(loginID.Equals(student.StudentID))
                {
                    StudentLoggedInId=student;
                    Console.WriteLine("Logged Successfully");
                    SubMenu();
                    value=false;
                    break;
                }
            }
            if(value)
            {
                Console.WriteLine("You Entered wrong Login Id");
            }
        }
        public static void DepartmentWiseSeatAvailability()
        {
           foreach(DepartmentDetails departmentob in departmentlist)
            {
                Console.WriteLine($"|{departmentob.DepartmentID,-12}|{departmentob.DepartmentName,-12}|{departmentob.NumberOfSeats,-12}");
            }
        }
        public static void DefaultValues()
        {
            StudentDetails student1=new StudentDetails("Ravichandran","Ettarajan",new DateTime(2000,09,08),Gender.male,96,97,98);
            StudentDetails student2=new StudentDetails("Baskaren","senthurajan",new DateTime(2001,09,08),Gender.male,89,90,98);
            studentlist.AddRange(new List<StudentDetails>(){student1,student2});

            DepartmentDetails department1=new DepartmentDetails("EEE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",30);
            DepartmentDetails department4=new DepartmentDetails("EEE",30);
            departmentlist.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});

            AdmissionDetails admission1=new AdmissionDetails("SF3001",	"DID101",	new DateTime(11/05/2022),AdmissionStatus.admitted);
            AdmissionDetails admission2=new AdmissionDetails("SF3002",	"DID102",	new DateTime(12/05/2022),AdmissionStatus.admitted);
            admissionlist.AddRange(new List<AdmissionDetails>(){admission1,admission2});

            Console.WriteLine();
            //traversing the details using foreach loop
            foreach(StudentDetails studentob in studentlist)
            {
                Console.WriteLine($"|{studentob.StudentID,-12}|{studentob.StudentName,12}|{studentob.FatherName,-12}|{studentob.DOB,-12}|{studentob.Gender,-12}|{studentob.Physics,-12}|{studentob.Chemistry,-12}|{studentob.Maths}");
            }
            Console.WriteLine();
            //Department Details
            foreach(DepartmentDetails departmentob in departmentlist)
            {
                Console.WriteLine($"|{departmentob.DepartmentID,-12}|{departmentob.DepartmentName,-12}|{departmentob.NumberOfSeats,-12}");
            }
            Console.WriteLine();
            //Admission Details
            foreach(AdmissionDetails admissionob in admissionlist)
            {
                Console.WriteLine($"|{admissionob.AdmissionID}|{admissionob.StudentID}|{admissionob.DepartmentID}|{admissionob.AdmissionDate}|{admissionob.AdmissionStatus}");
            }

        }
        public static void SubMenu()
        {
            bool value=true;
            do
            {
                Console.WriteLine("SubMenu\n1. CheckEligibility\n2. ShowDetails\n3. TakeAdmission\n4. ShowAdmission\n5. exit");
                Console.WriteLine("Enter your subChoice");
                int subChoice=int.Parse(Console.ReadLine());
                switch(subChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("CheckEligibility");
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Show Details");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Take Admission");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Show Details");
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Successfully Exit");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }
        public static void CheckEligibility()
        {
            Console.WriteLine("Enter your cutoff");
            double cutOff=double.Parse(Console.ReadLine());
            if(StudentLoggedInId.CheckEligibility(cutOff))
            {
                Console.WriteLine("Eligible");
            }
            else
            {
                Console.WriteLine("Not Eligible");
            }
        }
        public static void ShowDetails()
        {
            Console.Write($"");
        }
        public static void TakeAdmission()
        {
            //show the list seartavailable
            foreach(DepartmentDetails departmentob in departmentlist)
            {
                Console.WriteLine($"|{departmentob.DepartmentID,-12}|{departmentob.DepartmentName,-12}|{departmentob.NumberOfSeats,-12}");
            }
            //Ask Student to pict one Department id
            Console.WriteLine("Choose the Department id");
            string DepartmentId=Console.ReadLine();
            //Validate the DepartmentID is present in the list. If it is present, then check whether he is eligible to take admission.
            bool value=true;
            foreach(DepartmentDetails department in departmentlist)
            {
                if(DepartmentId.Equals(department.DepartmentID))
                {   value=false;
                    if(StudentLoggedInId.CheckEligibility(75.0))
                    {
                        
                    //•	If he is eligible, check whether seat available or not, if seats available then Check whether the student has already taken any admission by traversing admission details list.
                    if(department.NumberOfSeats>0)
                    {
                        int count=0;
                        foreach(AdmissionDetails admission in admissionlist)
                        {
                            if(StudentLoggedInId.StudentID.Equals(admission.StudentID))
                            {
                                count++;
                            }
                            if(count==0)
                            {
                                AdmissionDetails Taken=new AdmissionDetails(StudentLoggedInId.StudentID,department.DepartmentID,admission.AdmissionDate,AdmissionStatus.admitted);
                                department.NumberOfSeats--;
                                admissionlist.Add(Taken);
                                Console.WriteLine("Admission ID"+admission.AdmissionID);
                                break;
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Number of seats not eligible");
                    }
                }
                else
                {
                    Console.WriteLine("Not Eligible");
                }
                }
                
            }
            if(value)
                {
                    Console.WriteLine("Department id is not available");
                }

            
            //If he didn’t took any admission previously. 
            //•	Then, Reduce the seat count in department list and create admission details object by using StudentID, DepartmentID, AdmissionDate as Now, AdmissionStatus and Booked
            //add it to list.
            //•	Finally show “Admission took successfully. Your admission ID – SF3001”
        }

    }

}