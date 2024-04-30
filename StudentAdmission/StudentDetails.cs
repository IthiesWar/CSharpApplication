using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender
    {
        male,
        female,
        transgender
    }
    public class StudentDetails
    {
       
        private static int s_studentID=3000;
        public string StudentID { get;  }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
        
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int chemistry,int maths)
        {
            StudentID="SF"+s_studentID++;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }
        public StudentDetails(string students1)
        {
            string []values=students1.Split(",");
            StudentID=values[0];
            StudentName=values[1];
            FatherName=values[2];
            DOB=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender=Enum.Parse<Gender>(values[4]);
            Physics=int.Parse(values[5]);
            Chemistry=int.Parse(values[6]);
            Maths=int.Parse(values[7]);
        }


        public double Average()
        {
            int totalMarks=Physics+Chemistry+Maths;
            double average=(double)totalMarks/3;
            return average;
        }

        public  bool CheckEligibility(double cutOff)
        {
            if(Average()>cutOff)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}