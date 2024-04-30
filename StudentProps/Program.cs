using System;
namespace StudentProps;
class Program{
    public static void Main(string[] args)
    {
        Studentinfo student=new Studentinfo("S1","varm",new DateTime(2002,09,01),1988772212,20,100,90);
        student.Display();
        student.Calculate();
    }
}