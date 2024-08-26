namespace LINQ.JoinWithMultipleDataSource;

public static class JoinWithMultipleDataSourceExample
{
    public static string Run()
    {
        var JoinMultipleDSUsingMS =
                        //Employee data Source (i.e. Data Source 1)
                        Employee.GetAllEmployees()

                        //Joining with Address data Source (i.e. Data Source 2)
                        .Join(
                                Address.GetAllAddresses(), //Inner Data Source 1
                                empLevel1 => empLevel1.AddressId, //Outer Key selector
                                addLevel1 => addLevel1.ID, //Inner Key selector

                                //Result set
                                (empLevel1, addLevel1) => new { empLevel1, addLevel1 }
                            )

                        // Joinging with Department Data Source (i.e. data Source 3)
                        .Join(
                                Department.GetAllDepartments(), //Inner Data Source 2

                                //You cannot access the outer key selector directly
                                //You can only access with the result set created in previous step
                                //i.e. using empLevel1 and addLevel1
                                empLevel2 => empLevel2.empLevel1.DepartmentId, //Outer Key selector
                                deptLevel1 => deptLevel1.ID, //Inner Key selector

                                //Result set
                                (empLevel2, deptLevel1) => new { empLevel2, deptLevel1 }
                        )

                        //Creating the actual result set
                        .Select(e => new
                        {
                            ID = e.empLevel2.empLevel1.ID,
                            EmployeeName = e.empLevel2.empLevel1.Name,
                            AddressLine = e.empLevel2.addLevel1.AddressLine,
                            DepartmentName = e.deptLevel1.Name
                        }).ToList();

        string result = string.Empty;
        foreach (var employee in JoinMultipleDSUsingMS)
        {
            result += ($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.AddressLine}");
            result +="\n";
        }
        //Console.ReadLine();

        return result;
    }
}

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int AddressId { get; set; }
    public int DepartmentId { get; set; }
    public static List<Employee> GetAllEmployees()
    {
        return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1, DepartmentId = 10    },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2, DepartmentId =20   },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3, DepartmentId = 30    },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4, DepartmentId = 0    },
                new Employee { ID = 5, Name = "Hina", AddressId = 5, DepartmentId = 0       },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6, DepartmentId = 0     },
                new Employee { ID = 7, Name = "Happy", AddressId = 7, DepartmentId = 0      },
                new Employee { ID = 8, Name = "Tarun", AddressId = 8, DepartmentId = 0      },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9, DepartmentId = 10   },
                new Employee { ID = 10, Name = "Raja", AddressId = 10, DepartmentId = 20    },
                new Employee { ID = 11, Name = "Ramesh", AddressId = 11, DepartmentId = 30  }
            };
    }
}

public class Address
{
    public int ID { get; set; }
    public string AddressLine { get; set; }
    public static List<Address> GetAllAddresses()
    {
        return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1" },
                new Address { ID = 2, AddressLine = "AddressLine2" },
                new Address { ID = 3, AddressLine = "AddressLine3" },
                new Address { ID = 4, AddressLine = "AddressLine4" },
                new Address { ID = 5, AddressLine = "AddressLine5" },
                new Address { ID = 9, AddressLine = "AddressLine9" },
                new Address { ID = 10, AddressLine = "AddressLine10"},
                new Address { ID = 11, AddressLine = "AddressLine11"},
            };
    }
}

public class Department
{
    public int ID { get; set; }
    public string Name { get; set; }
    public static List<Department> GetAllDepartments()
    {
        return new List<Department>()
            {
                new Department { ID = 10, Name = "IT"       },
                new Department { ID = 20, Name = "HR"       },
                new Department { ID = 30, Name = "Payroll"  },
            };
    }
}