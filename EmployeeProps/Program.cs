using System;
using EmployeeProps;
namespace EmployeePeops;
class Program{
    public static void Main(string[] args)
    {
        EmployeeDetails employee=new EmployeeDetails("E1","varu",new DateTime(1000,09,08),330099123);
        employee.Display();
    }
}