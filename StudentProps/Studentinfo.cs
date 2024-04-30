using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProps
{
    public partial class Studentinfo
    {
        //properties -  StudentID,Name,Gender,DOB, Mobile, Physics, Chemistry, Maths Marks
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        
        public long MobileNumber { get; set; }
        
        public double Physics { get; set; }
        
        public double Chemistry { get; set; }
        
        public double Maths { get; set; }
        
        
        
        
        
    }
}