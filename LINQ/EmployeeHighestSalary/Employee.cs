namespace LINQ.EmployeeHighestSalary;

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
    public int AddressID { get; set; }
    public static List<Employee> GetAllEmployees()
    {
        return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", DepartmentId = 10, AddressID = 1, Salary=15000},
                new Employee { ID = 2, Name = "Priyanka", DepartmentId =20, AddressID = 2, Salary=25000},
                new Employee { ID = 3, Name = "Anurag", DepartmentId = 30, AddressID = 3, Salary=31000},
                new Employee { ID = 4, Name = "Pranaya", DepartmentId = 30, AddressID = 4, Salary=65000},
                new Employee { ID = 5, Name = "Hina", DepartmentId = 20, AddressID = 5, Salary=5000},
                new Employee { ID = 6, Name = "Sambit", DepartmentId = 10, AddressID = 6, Salary=20000},
                new Employee { ID = 7, Name = "Happy", DepartmentId = 10, AddressID = 7, Salary=3500},
                new Employee { ID = 8, Name = "Tarun", DepartmentId = 0, AddressID = 8, Salary=40000},
                new Employee { ID = 9, Name = "Santosh", DepartmentId = 10, AddressID = 9, Salary=17000},
                new Employee { ID = 10, Name = "Raja", DepartmentId = 20, AddressID = 10, Salary=75000},
                new Employee { ID = 11, Name = "Ramesh", DepartmentId = 30, AddressID = 11, Salary=3000}
            };
    }
}