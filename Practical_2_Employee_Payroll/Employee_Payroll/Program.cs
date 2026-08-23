using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P2_Employee_Payroll
{
    class Employee
    {
        public int emp_id;
        public string emp_name;
        public double emp_salary;
        public Employee()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(" Employee Payroll System");
            Console.WriteLine("--------------------------");
        }
        public void AccptDetails()
        {
            Console.Write("Enter Employee ID : ");
            emp_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name : ");
            emp_name = Console.ReadLine();
            Console.Write("Enter Basic Salary :");
            emp_salary = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayDetails()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Employee ID : "+ emp_id);
            Console.WriteLine("Employee Name : "+ emp_name);
            Console.WriteLine("Employee Basic Salary : "+ emp_salary);
        }

        public virtual void CalculateSalary()
        {
            Console.WriteLine("--------Salary Calculation-------- ");
        }

    }

    class FullTimeEmployee : Employee
    {
        public override void CalculateSalary()
        {
            double HRA = emp_salary * .20;
            double DA = emp_salary * .10;
            double NetSalary = emp_salary + HRA + DA;
            Console.WriteLine("Net Salary : "+ NetSalary);
        }
    }
    class PartTimeEmployee : Employee
    {
        public override void CalculateSalary()
        {
            double NetSalary = emp_salary;
            Console.WriteLine("Net Salary : "+ NetSalary);
        }
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee Type :");
            Console.WriteLine("1. Full Time Employee");
            Console.WriteLine("2. Part Time Employee");
            Console.Write("Enter your choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Employee employee = null;
            if (choice == 1)
            {
                employee = new FullTimeEmployee();
            }
            else if (choice == 2)
            {
                employee = new PartTimeEmployee();
            }
            else
                Console.WriteLine("Invalid Input.");

            employee.AccptDetails();
            employee.DisplayDetails();
            employee.CalculateSalary();

        }
    }
}
