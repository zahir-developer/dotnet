using LINQ;
using System.Linq;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region Group by query syntax 

app.MapGet("/EmployeeSalary", () =>
{

    Employee employee = new Employee();
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
});

#endregion



app.Run();
