using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender
    {
        male,
        female,
        Transgender
    }
    public class StudentDetails
    {
        /// <summary>
        /// 
        /// </summary>
    
    private static int s_studentID=3000;//Field private static
    public string StudentID { get;  }//Read Only Property
    public string StudentName { get; set; }
    public string FatherName { get; set; }
    public DateTime DateOfBirth { get; set; }//DateTime 
    public Gender Gender { get; set; }//Enum Traversing
    /// <summary>
    /// 
    /// </summary>
    /// <value>Only 0 to 100  value only sholud given</value>
    public double Physics { get; set; }
    public double Chemistry { get; set; }
    public double Maths { get; set; }
    
    //Constructor
    public StudentDetails(string studentName,string fatherName,DateTime dateOfBirth,Gender gender,double physics,double chemistry,double maths)
    {
    
    StudentID="SF"+s_studentID++;
    StudentName=studentName;
    FatherName=fatherName;
    DateOfBirth=dateOfBirth;
    Gender=gender;
    Physics=physics;
    Chemistry=chemistry;
    Maths=maths;
    }
    //Methods
    public double Average()
    {
        double total=Physics+Chemistry+Maths;
        double average=total/3;
        return average;
    }
    public bool CheckEligibility(double cutOff)
    {
        if(Average()>cutOff)
        {
            return true;
        }
        return false;
    }
}
}