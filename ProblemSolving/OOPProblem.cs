using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class A
    {
        public static int numberOfTokens(int expiryLimit, List<List<int>> commands)
        {
            Dictionary<int, int> tokens = new Dictionary<int, int>();
            int maxTime = 0;

            foreach (var command in commands)
            {
                int type = command[0];
                int tokenId = command[1];
                int time = command[2];

                maxTime = Math.Max(maxTime, time);

                if (type == 0)
                {
                    CreateToken(tokens, tokenId, time, expiryLimit);
                }
                else if (type == 1)
                {
                    ResetToken(tokens, tokenId, time, expiryLimit);
                }
            }

            return CountActiveTokens(tokens, maxTime);
        }

        private static void CreateToken(Dictionary<int, int> tokens, int tokenId, int time, int expiryLimit)
        {
            tokens.Add(tokenId, time + expiryLimit);
        }

        private static void ResetToken(Dictionary<int, int> tokens, int tokenId, int time, int expiryLimit)
        {
            if (tokens.ContainsKey(tokenId) && tokens[tokenId] >= time)
            {
                tokens[tokenId] = time + expiryLimit;
            }
        }

        private static int CountActiveTokens(Dictionary<int, int> tokens, int maxTime)
        {
            return tokens.Count(kv => kv.Value > maxTime);
        }
        public void Num (int a)
        {
            a = 6;
        }

        public void StringManu(string b)
        {
            b = "Prottoy";
        }

        public void aray( int[] c)
        {
            c[2] = 10;
        }

    
}

public class B : A
{
    public B()
    {
        Console.WriteLine("Hi you are in class B");
    }
}



public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }

    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee { EmployeeId = 1, EmployeeName = "John Doe" },
            new Employee { EmployeeId = 2, EmployeeName = "Jane Smith" }
            // Add more employees as needed
        };
    }
}

public class Salary
{
    public int SalaryId { get; set; }
    public string Salarytype { get; set; }
    public string SalarytDescription { get; set; }
    public double SalaryAmount { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }


    public static List<Salary> GetSalaries()
    {
        return new List<Salary>
        {
            new Salary { SalaryId = 1, Salarytype = "Monthly", SalarytDescription = "Basic Salary", SalaryAmount=2000, EmployeeId = 1 },
            new Salary { SalaryId = 2, Salarytype = "Monthly", SalarytDescription = "Basic Salary",SalaryAmount=3000, EmployeeId = 1 },
            new Salary { SalaryId = 3, Salarytype = "Monthly", SalarytDescription = "Basic Salary", SalaryAmount=2000,EmployeeId = 2 }
            // Add more salaries as needed
        };
    }
}

public class Operation
{
    List<Employee> employees = Employee.GetEmployees();
    List<Salary> salaries = Salary.GetSalaries();

    public void PrintEmploueeSalary(List<Employee> employees, List<Salary> salaries)
    {
        var query = from employee in employees
                    join salary in salaries
                    on employee.EmployeeId equals salary.EmployeeId into EmployeeSalaries
                    select new
                    {
                        EmployeeId = employee.EmployeeId,
                        EmployeeName = employee.EmployeeName,
                        TotalSalary = EmployeeSalaries.Sum(s => s != null ? s.SalaryAmount : 0)
                    };

        foreach (var result in query)
        {
            Console.WriteLine($"EmployeeId: {result.EmployeeId}, EmployeeName: {result.EmployeeName}, TotalSalary: {result.TotalSalary}");
        }

    }




}



public class Vehicle
{
    public virtual int getNumberOfWheels()
    {
        return 2;
    }

    //public virtual string EngineModel()
    //{
    //    return "test";
    //}
}

public class EngineVehicle : Vehicle
{
    public virtual string EngineModel()
    {
        return "test";
    }

}

public class MotorCycle : EngineVehicle
{
    public override int getNumberOfWheels()
    {
        return 4;
    }
    public override string EngineModel()
    {
        return "R15";
    }

}

public class BiCycle : Vehicle
{

}

    
}
