using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class Operations
    {
        //Global variable
        static Beneficiary USERBENIFICIARYID;
        //list for Beneficiary
        static List<Beneficiary> beneficiarylist=new List<Beneficiary>();
        //list for vaccine
        static List<Vaccine> vaccinelist=new List<Vaccine>();
        //list for Vaccination
        static List<Vaccination> vaccinationlist=new List<Vaccination>();
        //Mainmenu
        public static void MainMenu()
        {
            //bool for stop the loop
            bool value=true;
            do{

            Console.WriteLine("Mainmenu\n1. Registration\n2. Login\n3. Exit");
            Console.WriteLine("Enter your choice");
            int mainChoice=int.Parse(Console.ReadLine());
            switch(mainChoice)
            {
                case 1:
                {
                    Console.WriteLine("****Registration*****");
                    Registration();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("****Login****");
                    Login();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("****Exit*****");
                    Console.WriteLine("Exit Successfully");
                    value=false;
                    break;
                }
            }
            }while(value);
        }//MainMenu ends here

        //Registration
        public static void Registration()
        {
            Console.Write("Enter your Name ");
            string name=Console.ReadLine();
            Console.Write("Enter your Age ");
            int age=int.Parse(Console.ReadLine());
            Console.Write("Enter your gender ");
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.WriteLine("Enter your Mobile numbers ");
            long mobileNumber=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your city ");
            string city=Console.ReadLine();

            //creating the object
            Beneficiary beneficiaryobject=new Beneficiary(name,age,gender,mobileNumber,city);
            beneficiarylist.Add(beneficiaryobject);
            Console.WriteLine("Benificiary registration successful "+beneficiaryobject.RegisterNumber);
        }
        //DefaultValues starts
        //Login
        public static void Login()
        {
            //bool for stop the loop
            bool value=true;
            Console.WriteLine("Enter your benificiary register number ");
            string registerNumber=Console.ReadLine();
            foreach(Beneficiary beneficiary in beneficiarylist)
            {
                if(registerNumber.Equals(beneficiary.RegisterNumber))
                {
                    USERBENIFICIARYID=beneficiary;
                    Console.WriteLine("Login Successful");
                    SubMenu();
                    value=false;
                    break;
                }
            }
            if (value)
            {
                Console.WriteLine("Invalid Login ID");
            }
        }//Login ends here
        //sub menu
        public static void SubMenu()
        {
            //bool for stop the loop
            bool value=true;
            do
            {
                Console.WriteLine("SubMenu\n1. Show My Details\n2. Take Vaccination\n3. My Vaccination History\n4. Next Due Date\n5. Exit");
                Console.WriteLine("Enter your choice ");
                int subMenuChoice=int.Parse(Console.ReadLine());
                switch(subMenuChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("****Show My Details****");
                        ShowDetails();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("****Take Vaccination****");
                        TakeVaccination();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****My Vaccination History****");
                        VaccinationHistory();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("****Next Due Date****");
                        NextDueDate();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("****Exit****");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }//Submenu ends here
        //Show Details
        public static void ShowDetails()
        {
            foreach(Beneficiary beneficiary in beneficiarylist)
            {
                Console.WriteLine($"{beneficiary.RegisterNumber}|{beneficiary.Name}|{beneficiary.Age}|{beneficiary.Gender}|{beneficiary.MobileNumber}|{beneficiary.City}");
            }
        }//show details ends here

        //Take Vaccination
        public static void TakeVaccination()
        {
            bool value=true;
            //Show the list of vaccine available and to select a vaccine
             foreach(Vaccine vaccine in vaccinelist)
            {
                Console.WriteLine($"{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}");
            
            //Ask the user to select a vaccine by using vaccine ID and find the ID is valid. 
            Console.WriteLine("Enter the vaccine ID");
            string vaccineID=Console.ReadLine();
            if(vaccineID.Equals(vaccine.VaccineID))
            {
                value=false;
                //o	Then, get the vaccination history of current logged in beneficiary
                Console.WriteLine($"{USERBENIFICIARYID.Name}|{USERBENIFICIARYID.RegisterNumber}|{USERBENIFICIARYID.Age}|{USERBENIFICIARYID.City}|{USERBENIFICIARYID.Gender}");
                //	If he didn’t take any vaccine means check his age is above 14
                if(USERBENIFICIARYID.Age>14)
                {
                    //•	Update the details in his vaccination history list
                    //	Deduct the count of vaccine available
                    vaccine.NoOfDoseAvailable--;
                    Vaccination taken=new Vaccination(USERBENIFICIARYID.RegisterNumber,vaccine.VaccineID,1,DateTime.Now);
                    vaccinationlist.Add(taken);
                    Console.WriteLine("Vacciantion successful");
                    //	If he took three vaccines means show “All the three Vaccination are completed, you cannot be vaccinated now”.
                    foreach(Vaccination vaccination in vaccinationlist)
                    {
                        if(vaccination.DoseNumber>3)
                        {
                            Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                        }
                        else
                        {
                            Console.WriteLine("You have selected different vaccine”. You can vaccine with “Covaccine / Covishield");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Not Eligible for take vaccine");
                }
            }
            }
            if(value)
            {
                Console.WriteLine("Wrong Vaccine ID");
            }

        }//Take vaccination ends here
        //VaccinationHistory
        public static void VaccinationHistory()
        {
            foreach(Vaccination vaccination in vaccinationlist)
            {
                Console.WriteLine($"{vaccination.VaccinationID}|{USERBENIFICIARYID.RegisterNumber}|{vaccination.VaccineID}|{vaccination.DoseNumber}|{vaccination.VaccinatedDate}");
                break;
            }
        }//VaccinationHistory Ends 
        //NextDueDate
        public static void NextDueDate()
        {
            //	Show the next due date for the current beneficiary by finding his details from his vaccination history
            foreach(Vaccination vaccination in vaccinationlist)
            {
                if(vaccination.RegisterNumber.Equals(USERBENIFICIARYID.RegisterNumber))
                {
                    DateTime  Date=vaccination.VaccinatedDate.AddDays(30);
                    Console.WriteLine("Next Due Date "+Date);
                    break;
                }
                else
                {
                    Console.WriteLine("you can take vaccine now");
    
                }
                if(vaccination.DoseNumber>=1)
                {
                    Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive");
                    break;
                }
              
            }
        }//NextDueDate
        public static void DefaultValues()
        {
            //Adding default values to the Beneficiary
            Beneficiary beneficiary1=new Beneficiary("Ravichandran",	21	,Gender.male,	8484484,"Chennai");
            Beneficiary beneficiary2=new Beneficiary("Baskaran",	22,Gender.male	,	8484747,	"Chennai");

            
            beneficiarylist.AddRange(new List<Beneficiary>(){beneficiary1,beneficiary2});

            //Adding default values to the vaccine
            Vaccine vaccine1=new Vaccine("Covishield",	50);
            Vaccine vaccine2=new Vaccine("Covaccine",	50);

            
            vaccinelist.AddRange(new List<Vaccine>(){vaccine1,vaccine2});

            //adding default values to the vaccination id
            Vaccination vaccination1=new Vaccination("BID1001",	"CID2001",	1	,new DateTime(11/11/2021));
            Vaccination vaccination2=new Vaccination("BID1001",	"CID2001",	2,new DateTime(	11/03/2022));
            Vaccination vaccination3=new Vaccination("BID1002",	"CID2002",	1	,new DateTime(04/04/2022));

            //creating the object
            vaccinationlist.AddRange(new List<Vaccination>(){vaccination1,vaccination2,vaccination3});

            //traversing the benificiary
            foreach(Beneficiary beneficiary in beneficiarylist)
            {
                Console.WriteLine($"{beneficiary.RegisterNumber}|{beneficiary.Name}|{beneficiary.Age}|{beneficiary.Gender}|{beneficiary.MobileNumber}|{beneficiary.City}");
            }
            Console.WriteLine();
            //traversing the vaccine
            foreach(Vaccine vaccine in vaccinelist)
            {
                Console.WriteLine($"{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}");
            }
            Console.WriteLine();
            //traversing the vaccination
            foreach(Vaccination vaccination in vaccinationlist)
            {
                Console.WriteLine($"{vaccination.VaccinationID}|{vaccination.RegisterNumber}|{vaccination.VaccineID}|{vaccination.DoseNumber}|{vaccination.VaccinatedDate}");
            }
        }//Default values ends here
    }
}