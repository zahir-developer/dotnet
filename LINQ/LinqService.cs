using System.Text;
using LINQ.JoinWithMultipleDataSource;

namespace LINQ;

public class LinqService : ILinqService
{
    public string LinqJoinWithMultipleDataSource()
    {
        return JoinWithMultipleDataSourceExample.Run();
    }

    public string EmployeeSalary()
    {
        LINQ.Employee employee = new LINQ.Employee();
        var empList = employee.GetEmpRecord();

        var empSalary = (from emp in empList
                         group emp by emp.Salary into g
                         orderby g.Key descending
                         select new
                         {
                             empRecord = g.ToList()
                         }).FirstOrDefault();


        StringBuilder str = new StringBuilder();
        empSalary?.empRecord.ForEach(i =>
        {
            str.Append("Employee: " + i.EmpName + ", Salary" + i.Salary);
        });

        return str.ToString();
    }

    public string Student()
    {

        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21, StandardID = 3}
            };

        IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };



        var groupJoin = standardList.GroupJoin(studentList,
                        std => std.StandardID,
                        s => s.StandardID,
                        (std, studentGroup) => new
                        {
                            Students = studentGroup,
                            StandFullName = std.StandardName
                        });

        StringBuilder str = new();

        foreach (var item in groupJoin)
        {
            str.Append(item.StandFullName);
            str.AppendLine();

            foreach (var stud in item.Students)
            {
                str.Append(stud.StudentName);
                str.AppendLine();
            }
        }

        return str.ToString();

    }

    public string EmployeeHighestSalary()
    {
        var departments = Department.GetAllDepartments();

        var employees = LINQ.EmployeeHighestSalary.Employee.GetAllEmployees();

        var empGroup = employees.GroupBy(s => new { s.Salary, s.ID }).Select(s => new { Salary = s.Key.Salary, ID = s.Key.ID }).OrderByDescending(o => o.Salary).Take(1);

        StringBuilder result = new();
        foreach (var emp in empGroup)
        {
            result.AppendLine("EmpID:" + emp.ID + ", Salary:" + emp.Salary + "\n");
        }

        return result.ToString();
    }
}