using System.Text;

public class EmployeeHighestSalaryExample
{
    public string Run()
    {
        //Reference: https://dotnettutorials.net/lesson/linq-join-with-multiple-data-sources/
    var employees = LINQ.EmployeeHighestSalary.Employee.GetAllEmployees();

    var addresses = LINQ.EmployeeHighestSalary.Address.GetAllAddresses();

    var departments = LINQ.EmployeeHighestSalary.Department.GetAllDepartments();

    var empGroup = employees.Join(addresses,
                    emp => emp.AddressID,
                    add => add.ID,
                    (emp, add) => new
                    {
                        emp,
                        add
                    }).Join(departments,
                    empLevel2 => empLevel2.emp.DepartmentId,
                    dept => dept.ID,
                    (empLevel2, dept) => new
                    {
                        empLevel2,
                        dept
                    }).Select(s => new
                    {
                        s.empLevel2.emp.ID,
                        s.empLevel2.emp.Name,
                        DepartmentId = s.dept.ID,
                        DeptName = s.dept.Name,
                        s.empLevel2.add.AddressLine
                    });

    StringBuilder result = new();
    foreach (var emp in empGroup)
    {
        result.AppendLine($"ID = {emp.ID}, Name = {emp.Name}, Department = {emp.DeptName}, Addres = {emp.AddressLine}" + "\n");
    }

    return result.ToString();
    }
}