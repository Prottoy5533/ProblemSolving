using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public abstract class BaseSalaryCalculator
    {
        protected EmployeeReport EmployeeReport { get; private set; }
        
        public BaseSalaryCalculator(EmployeeReport employeeReport)
        {
            EmployeeReport = employeeReport;
        }

        public abstract double CalculateSalary();
    }

    public class SeniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDevSalaryCalculator(EmployeeReport employeeReport) :base(employeeReport)
        {
            
        }
        public override double CalculateSalary()
        {
            var x = EmployeeReport.WorkingHour *1.5;

            return x;
        }
    }
}
