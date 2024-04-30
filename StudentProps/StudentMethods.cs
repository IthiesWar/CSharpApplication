using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProps
{
    public partial class Studentinfo
    {
        public void Display()
        {
            Console.WriteLine($"Student Id {StudentID}");
            Console.WriteLine($"Name {Name}");
            Console.WriteLine($"Gender {Gender}");
            Console.WriteLine($"Date Of Birth {DOB}");
            Console.WriteLine($"Mobile Number {MobileNumber}");
            Console.WriteLine($"Physics {Physics}");
            Console.WriteLine($"Chemistry {Chemistry}");
            Console.WriteLine($"Maths {Maths}");
        }
        public void Calculate()
        {
            double total=Physics+Chemistry+Maths;
            double percentage=total/3;
            Console.WriteLine($"Percentage {percentage}");
        }
    }
}