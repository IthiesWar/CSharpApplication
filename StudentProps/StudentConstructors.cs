using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProps
{
    public partial class Studentinfo
    {
        ////properties -  StudentID,Name,Gender,DOB, Mobile, Physics, Chemistry, Maths Marks
        public Studentinfo(string studentID,string name,DateTime dob,long mobileNumber,double physics,double chemistry,double maths)
        {
            StudentID=studentID;
            Name=name;
            DOB=dob;
            MobileNumber=mobileNumber;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }
    }
}