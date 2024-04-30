using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{

    public static class Operations
    {
        //Local/Global
        static StudentDetails CurrentLoggedInStudent;
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("**************Welcome to Syncfusion college of Engineering*********");
            //Need to show the menu option


            bool mainChoice = true;
            //Need to create mainmenu structutre
            do
            {
                Console.WriteLine("MainMenu\n1.Registration\n2. Login\n3. Departments Seat Availability\n4.  Exit");
                //Need to get an input from user and validate
                Console.Write("Select an option");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        Console.WriteLine("******Registration******");
                        StudentRegistraion();
                        break;
                    case 2:
                        Console.WriteLine("******Login*****");
                        StudentLogin();
                        break;
                    case 3:
                        Console.WriteLine("*****Departmentwise Seat Availability******");
                        DeaprtmentwiseSeatAvailability();
                        break;
                    case 4:
                        Console.WriteLine("*****Application Exit Successfully*********");
                        mainChoice = false;
                        break;
                }
            } while (mainChoice);//Mainmenu ends

        }

        //Student Registration
        public static void StudentRegistraion()
        {
            //Need to get required details:
            Console.Write("Enter your name:");
            string StudentName = Console.ReadLine();
            Console.Write("Enter your father name");
            string FatherName = Console.ReadLine();
            Console.Write("Enter your DOB as specified yyyy,MM,ss");
            DateTime DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "yyyy,MM,dd", null);
            Console.Write("Enter your Gender(Male/Female/Gender)");
            Gender Gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);
            Console.Write("Enter your Pysics mark");
            double Physics = double.Parse(Console.ReadLine());
            Console.Write("Enter your Chemistry Mark");
            double Chemistry = double.Parse(Console.ReadLine());
            Console.Write("Enter your Maths Mark");
            double Maths = double.Parse(Console.ReadLine());

            StudentDetails studentobject = new StudentDetails(StudentName, FatherName, DateOfBirth, Gender, Physics, Chemistry, Maths);
            studentList.Add(studentobject);
            Console.WriteLine("Regitration Successful" + studentobject.StudentID);
        }//Student Registration Ends

        //Student Login
        public static void StudentLogin()
        {
            //Need to get ID Input
            Console.Write("Enter your student ID");
            string loginId = Console.ReadLine().ToUpper();
            //Validate by its presence in the list
            bool value = true;
            foreach (StudentDetails i in studentList)
            {
                if (loginId.Equals(i.StudentID))
                {
                    //assigning current user to global variable
                    CurrentLoggedInStudent = i;
                    Console.WriteLine("Login Successful");
                    SubMenu();
                    value = false;
                    break;
                }
            }
            if (value)
            {
                Console.WriteLine("Invalid ID or ID is not present");
            }

        }//Student Login Ends

        //If not-Invalid Valid.
        //Submenu
        public static void SubMenu()
        {
            bool subChoice = true;
            do
            {
                Console.WriteLine("******SubMenu*****");
                Console.WriteLine("Select an option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. show Admission Details\n6. Exit");
                Console.WriteLine("Enter your choice");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine("************Check Eligibility********");
                            CheckAvilability();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("****************show Details***********");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("************Take Admission**********");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("***************Cancel Admission*********");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("***************show Admission Details********");
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("*********Taking back to Main menu******");
                            subChoice = false;
                            break;
                        }
                }
                //Need to show sub menu option
                //Getting user option
                //Iterate till the option exit

            } while (subChoice);
        }//Submenu Ends

        //CheckAvilability
        public static void CheckAvilability()
        {
            //Need to Get a cut off input
            Console.WriteLine("Enter the cutoff");
            double cutoff=double.Parse(Console.ReadLine());
            //Check elegible or not
            if(CurrentLoggedInStudent.CheckEligibility(cutoff))
            {
                Console.WriteLine("Eligible");
            }
            else
            {
                Console.WriteLine("Not Eligible");
            }
        }//show Endshere
        //Show Details
        public static void ShowDetails()
        {
            Console.WriteLine($"|{CurrentLoggedInStudent.StudentID}|{CurrentLoggedInStudent.StudentName}|{CurrentLoggedInStudent.FatherName}|{CurrentLoggedInStudent.DateOfBirth}|{CurrentLoggedInStudent.Gender}|{CurrentLoggedInStudent.Physics}|{CurrentLoggedInStudent.Chemistry}|{CurrentLoggedInStudent.Maths}");
        }
        //ShowDetails Endshere

        //TakeAdmission Details
        public static void TakeAdmission()
        {
            //Need to show department details
            DeaprtmentwiseSeatAvailability();
            //Ask department ID from user
            Console.WriteLine("Enter the department ID");
            string departmentID=Console.ReadLine();
            //check the ID is present or not
            bool value=true;
            foreach(DepartmentDetails i in departmentList)
            {
                if(departmentID.Equals(i.DepartmentID))
                {
                    value=false;
                    //check the student is eligible
                    Console.WriteLine("Enter your cutoff");
                    if(CurrentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check number of seats
                        if(i.NumberOfSeats>0)
                        {
                            int count=0;
                            //check admission already taken
                            foreach(AdmissionDetails j in admissionList)
                            {
                                if(CurrentLoggedInStudent.StudentID.Equals(j.StudentID) && j.Status.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            
                            if(count==0)
                            {
                                //create an admission object
                                AdmissionDetails admissionTaken=new AdmissionDetails(CurrentLoggedInStudent.StudentID,j.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                i.NumberOfSeats--;
                                admissionList.Add(admissionTaken);

                            }
                            
                            else
                            {
                                Console.WriteLine("you have already taken an admission");
                            }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Seats are not eligible");
                        }
                    }
                    else
                    {
                        Console.WriteLine("you are not eligible");
                    }
                }
                break;
            }
            if(value)
            {
                Console.WriteLine("ID is Present");
            }
            //ckeck the student is eligible or not
            //check the seat availability
            //check the student already taken any admission
            //create admission object
            //Reduce seat count
            //Add to the admission list
            //Disply admission successful message.
        }//TakeAdmission Endshere

        //CancelAdmission Details
        public static void CancelAdmission()
        {
            foreach(AdmissionDetails i in admissionList)
            {
                if(CurrentLoggedInStudent.StudentID.Equals(i.AdmissionId)&& i.Status.Equals(AdmissionStatus.Admitted))
                {
                    i.Status=AdmissionStatus.Cancelled;
                    foreach(DepartmentDetails j in departmentList)
                    {
                        if(i.DepartmentID.Equals(j.DepartmentID))
                        {
                            j.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
        }//CancelAdmission Endshere
        //ShowAdmissionDetails
        public static void ShowAdmissionDetails()
        {
            //Need to show Current AdmissionDetails
           foreach (AdmissionDetails i in admissionList)
            {
               if(CurrentLoggedInStudent.StudentID.Equals(i.StudentID))
               {
                Console.WriteLine($"|{i.AdmissionId}|{i.StudentID}|{i.DepartmentID}|{i.AdmissionDate}|{i.Status}");
               }
            }
            Console.WriteLine();
        }//showAdmission Endshere

        //Seats Availability
        public static void DeaprtmentwiseSeatAvailability()
        {
            Console.WriteLine("|Department ID | Deaprtment Name |Number of Seats");
            foreach (DepartmentDetails i in departmentList)
            {
                Console.WriteLine($"|{i.DepartmentID}|{i.DepartmentName}{i.NumberOfSeats}");
            }
            Console.WriteLine();
        }//Seat Availabilty Ends

        //Adding Default Data
        public static void AddDefaultData()
        {
            Console.WriteLine("Enter your StudentName ");
            string StudentName = Console.ReadLine();
            Console.WriteLine("Enter your FatherName ");
            string FatherName = Console.ReadLine();
            Console.WriteLine("Enter your DateOfBirth ");
            DateTime DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "yyyy,MM,dd", null);
            Console.WriteLine("Enter your Gender ");
            Gender Gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);
            Console.WriteLine("Enter your Physics ");
            double Physics = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Chemistry ");
            double Chemistry = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Chemistry ");
            double Maths = double.Parse(Console.ReadLine());

            //Object Creation for StudentDetails
            StudentDetails studentobject = new StudentDetails(StudentName, FatherName, DateOfBirth, Gender, Physics, Chemistry, Maths);
            //Adding to List for StudentList
            studentList.Add(studentobject);

            //Department Details
            Console.WriteLine("Department Name ");
            string DepartmentName = Console.ReadLine();
            Console.WriteLine("Number of Seats");
            int NumberOfSeats = int.Parse(Console.ReadLine());
            //Object Creation for DepartmentDetails
            DepartmentDetails deptobject = new DepartmentDetails(DepartmentName, NumberOfSeats);
            //Adding to List for DepartmentList
            departmentList.Add(deptobject);

            //Admission Details
            Console.WriteLine("Student ID");
            string StudentID = Console.ReadLine();
            Console.WriteLine("Department ID");
            string DepartmentID = Console.ReadLine();
            Console.WriteLine("Admission Date");
            DateTime AdmissionDate = DateTime.ParseExact(Console.ReadLine(), "yyyy,MM,dd", null);
            AdmissionStatus Status = (AdmissionStatus)Enum.Parse(typeof(AdmissionStatus), Console.ReadLine(), true);
            //Object Creation for AdmissionDetails
            AdmissionDetails admissionobject = new AdmissionDetails(StudentID, DepartmentID, AdmissionDate, Status);
            //Adding to List for AdmissionDetails
            admissionList.Add(admissionobject);
            //Printing the data
            foreach (StudentDetails i in studentList)
            {
                Console.WriteLine($"|{i.StudentID}|{i.StudentName}|{i.FatherName}|{i.DateOfBirth}|{i.Gender}|{i.Physics}|{i.Chemistry}|{i.Maths}");
            }
            Console.WriteLine();

            //Printing the data for DepartmentDetails
            foreach (DepartmentDetails i in departmentList)
            {
                Console.WriteLine($"|{i.DepartmentID}|{i.DepartmentName}{i.NumberOfSeats}");
            }

            //Printing the data for AdmissionDetails
            foreach (AdmissionDetails i in admissionList)
            {
                Console.WriteLine($"|{i.AdmissionId}|{i.StudentID}|{i.DepartmentID}|{i.AdmissionDate}|{i.Status}");
            }
        }

    }
}