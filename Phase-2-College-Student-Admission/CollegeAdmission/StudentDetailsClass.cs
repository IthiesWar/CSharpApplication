using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// DataType Gender used to  select a instance of <see cref="StudentDetailsClass"/> Gender Information
/// </summary>
namespace CollegeAdmission
{
    public enum Gender
    {
        male,
        female,
        Transgender
    }
    /// <summary>
    /// class StudentDetailsClass used to  select a instance for student <see cref="StudentDetailsClass"/> Gender Information
    /// Refer documentation on <see href="WWW.Syncfusion.com"/>
    /// </summary>
    public class StudentDetailsClass
    {
        static private int IdGenerator1=3000;
        /// <summary>
        /// StudentdID Property used to hold a Studentds'ID of instance of<see cref="StudentDetailsClass"/> 
        /// </summary>
        public string StutendId { get; }
        public string StutendName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        /// <summary>
        /// Physics Property used to hold a Marks of of instance of<see cref="StudentDetailsClass"/> 
        /// </summary>
        /// <value>Physics used to store o to 100 </value>
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double Maths { get; set; }
        public int Average { get; set; }
        
        

        /// <summary>
        /// Constructor StudentDetailsClass used to initialize parameter values to its Properties
        /// </summary>
        /// <param name="stutendName">stutendName Parameter used to assign its value to associate Property</param>
        /// <param name="stutendName"> Pa</param>
        /// <param name="fatherName"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="gender"></param>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="maths"></param>
        public StudentDetailsClass(string stutendName,string fatherName,DateTime dateOfBirth,Gender gender,double physics,double chemistry,double maths,int average)
        {
            StutendId="SF"+IdGenerator1++;
            StutendName=stutendName;
            FatherName=fatherName;
            DateOfBirth=dateOfBirth;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
            
        }
    public double AverageCalculation()
    {
        int total=(int)Physics+(int)Chemistry+(int)Maths;
        double average=total/3;
        return average;
    }
    public bool EligibilityCheck(int cutoff)
    {
        if(Average>cutoff)
        {
            return true;
        }
        return false;
    }


    }
    
    


    
}