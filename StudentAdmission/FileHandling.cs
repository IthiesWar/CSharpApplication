using System;
using System.IO;

namespace StudentAdmission
{
    public static class FileHandling
  {
        public static void Create()
        {
            if(!Directory.Exists("StudentAdmission"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("StudentAdmission");
            }
            else
            {
                Console.WriteLine("Already exits");
            }
            //File for student Details
            if(!File.Exists("StudentDetails"))
            {
                Console.WriteLine("Creating File....");
                File.Create("StudentAdmission/StudentDetails.csv").Close();
            }
            //File for DepartmentDetails
            if(!File.Exists("DepartmentDetails"))
            {
                Console.WriteLine("Creating File....");
                File.Create("StudentAdmission/DepartmentDetails.csv").Close();
            }
            //File for AdmissionDetails
             if(!File.Exists("AdmissionDetails"))
            {
                Console.WriteLine("Creating File....");
                File.Create("StudentAdmission/AdmissionDetails.csv").Close();
            }

        }
        public static void WriteToCsv()
        {
            //Student Details
            string []students=new string[Operation.studentlist.Count];
            for(int i=0;i<Operation.studentlist.Count;i++)
            {
                students[i]=Operation.studentlist[i].StudentID+","+Operation.studentlist[i].StudentName+","+Operation.studentlist[i].FatherName+","+Operation.studentlist[i].DOB+","+Operation.studentlist[i].Gender+","+Operation.studentlist[i].Physics+","+Operation.studentlist[i].Chemistry+","+Operation.studentlist[i].Maths;
            }
            File.WriteAllLines("StudentAdmission/StudentDetails.csv",students);
            //Department Details
            string[]Department=new string[Operation.departmentlist.Count];
            for(int i=0;i<Operation.departmentlist.Count;i++)
            {
                Department[i]=Operation.departmentlist[i].DepartmentID+","+Operation.departmentlist[i].DepartmentName+","+Operation.departmentlist[i].NumberOfSeats;
            }
            File.WriteAllLines("StudentAdmission/DepartmentDetails.csv",Department);
        }
        //Read
        public static void ReadFromCsv()
        {
            string []students=File.ReadAllLines("StudentAdmission/StudentDetails.csv");
            foreach(string students1 in students)
            {
                StudentDetails student1=new StudentDetails(students1);
                Operation.studentlist.Add(student1);
            }
        }
    }
}