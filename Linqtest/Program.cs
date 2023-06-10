using System;
using System.Collections.Generic;
using System.Linq;

// https://www.youtube.com/watch?v=TyfCGVyhZtY
namespace test
{
    class Program
    {
        public enum Gender
    {
        Male,
        Female
    }
 
    public enum Department
    {
        Sales,
        Marketing,
        Accounts,
        InformationTechnology
    }
     public record  Employee(int Id, string Name, Gender Gender, Department Department, float Salary)
    {
        public static IEnumerable<Employee> getMyEmployees(){
            return GetEmployees();
        }

        public static IEnumerable<Employee> GetEmployees()
        {
            return null;
        }
    }
        

        static void Main(string[] args)
        {
             var myList = new List<Employee>
            {
                new(1, "Angela", Gender.Female, Department.InformationTechnology, 125),
                new(2, "Alice", Gender.Female, Department.InformationTechnology, 150),
                new(3, "Amanda", Gender.Female, Department.InformationTechnology, 175),
                new(4, "Alex", Gender.Male, Department.InformationTechnology, 100),
                new(5, "Andre", Gender.Male, Department.InformationTechnology, 125),
                new(6, "Aaron", Gender.Male, Department.InformationTechnology, 125),
                new(7, "Brittany", Gender.Female, Department.Marketing, 150),
                new(8, "Betty", Gender.Female, Department.Marketing, 175),
                new(9, "Barbara", Gender.Female, Department.Marketing, 125),
                new(10, "Bill", Gender.Male, Department.Marketing, 200),
                new(11, "Bob", Gender.Male, Department.Marketing, 125),
                new(12, "Buddy", Gender.Male, Department.Marketing, 125)
            };

            // get the average salary by gender and department 
            var query = myList.Select(e => new {
                e.Salary,
                e.Gender,
                e.Department
            })
            .GroupBy(e =>  new {
                e.Gender, 
                e.Department,
            })
            .Select(x => new {
                x.Key, // rember this key thing
                AverageSalary = x.Select(y => y.Salary).Average()
            });


            // equivalent query
            var averageSalaries =
            from employee in myList
            group employee by (employee.Department, employee.Gender) into employeeGroup
            select new
            {
                ID = employeeGroup.Key,
                AverageSalary = employeeGroup.Average(x => x.Salary),
            };

            
            // Console.WriteLine($"lala");
            foreach (var i in query)
            {
                Console.WriteLine($"{i.Key} {i.AverageSalary}");
            }

            
        }
    }

    namespace EmployeeDirectory
{
    
}
}
