using System;

namespace LINQ;

public class Employee  
    {  
        public string EmpName { get; set; }  
        public int Salary { get; set; }  
        public int EmpId { get; set; }  
  
        public List<Employee> GetEmpRecord()  
        {  
            List<Employee> emplist = new List<Employee>();  
            emplist.Add(new Employee { EmpId = 1, EmpName = " Gopal", Salary = 10000 });  
            emplist.Add(new Employee { EmpId = 2, EmpName = "Naresh", Salary = 3456 });  
            emplist.Add(new Employee { EmpId = 3, EmpName = "Hari", Salary = 14256 });  
            emplist.Add(new Employee { EmpId = 4, EmpName = "Pradeep", Salary = 14256 });  
            emplist.Add(new Employee { EmpId = 5, EmpName = "Madhu", Salary = 14256 });  
            emplist.Add(new Employee { EmpId = 6, EmpName = "Sures", Salary = 18000 });  
            emplist.Add(new Employee { EmpId = 7, EmpName = "Kumar M", Salary = 10000 });  
            emplist.Add(new Employee { EmpId = 8, EmpName = "kali", Salary = 6000 });  
            emplist.Add(new Employee { EmpId = 9, EmpName = "Manas", Salary = 2000 });  
            emplist.Add(new Employee { EmpId = 10, EmpName = "Mithun", Salary = 5000 });  
            emplist.Add(new Employee { EmpId = 11, EmpName = "Aryan", Salary = 7000 });  
            emplist.Add(new Employee { EmpId = 12, EmpName = "Akilesh", Salary = 7000 });  
            return emplist;  
        }  
    } 