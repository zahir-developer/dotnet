using LINQ;
using LINQ.EmployeeHighestSalary;
using System.Linq;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var services = new ServiceCollection();

services.AddSingleton<ILinqService, LinqService>();

var serviceProvider = services.BuildServiceProvider();

var linqService = serviceProvider.GetService<ILinqService>();


app.MapGet("/", ()=>
{
    StringBuilder result = new();
    result.AppendLine("http://localhost:5095/EmployeeSalary");
    result.AppendLine("http://localhost:5095/Student");
    result.AppendLine("http://localhost:5095/EmployeeHighestSalary");
    result.AppendLine("http://localhost:5095/JoinUsingMultipleDataSource");

    return result.ToString();
});

#region Group by query syntax 

app.MapGet("/EmployeeSalary", () =>
{
    linqService.EmployeeSalary();
});

#endregion


#region GroupJoin Method Syntax 

app.MapGet("/Student", () =>
{
    linqService.Student();

});



#endregion


#region EmployeeHighestSalary

app.MapGet("/EmployeeHighestSalary", () =>
{
    linqService.EmployeeHighestSalary();
});

#endregion



#region LINQ Method Syntax to Perform Inner Join using Multiple Data Sources in C#:

app.MapGet("/JoinUsingMultipleDataSource", () =>
{
    return linqService.LinqJoinWithMultipleDataSource();
});

#endregion

app.Run();
