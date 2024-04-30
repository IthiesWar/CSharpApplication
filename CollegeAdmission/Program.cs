using System;
namespace CollegeAdmission;//File Scoped Namespace
public class Program{
    public static void Main(string[] args)
    {
        //DataCalling 
        Operations.AddDefaultData();
        //Calling Mainmenu
        Operations.MainMenu();
        Operations.StudentRegistraion();
        Operations.StudentLogin();
        Operations.DeaprtmentwiseSeatAvailability();
        Operations.SubMenu();
    }
}
