using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P1_Student_Admission
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student();

            s1.scholarship();
            s1.printdata();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }

    class student
    {
        public int admission_no;
        public string name;
        public string course;
        public int sem;

        private double fees;
        private double scholarship_fees;
        private double scholarship_avail;

        public bool isScholarship;

        private const double scholarshipRate = 0.10;

        // Constructor
        public student()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("   STUDENT ADMISSION SYSTEM");
            Console.WriteLine("----------------------------");

            Console.Write("Enter Student Admission Number : ");
            admission_no = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Name : ");
            name = Console.ReadLine();

            Console.Write("Enter Student Course : ");
            course = Console.ReadLine();

            Console.Write("Enter Student Semester : ");
            sem = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Admission Fees : ");
            fees = Convert.ToDouble(Console.ReadLine());
        }

        // Scholarship calculation
        public void scholarship()
        {
            if (fees <= 50000)
            {
                isScholarship = true;

                scholarship_avail = fees * scholarshipRate;
                scholarship_fees = fees - scholarship_avail;
            }
            else
            {
                isScholarship = false;

                scholarship_avail = 0;
                scholarship_fees = fees;
            }
        }

        // Display student details
        public void printdata()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("          STUDENT ADMISSION DETAILS");
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Admission Number  : " + admission_no);
            Console.WriteLine("Student Name      : " + name);
            Console.WriteLine("Course            : " + course);
            Console.WriteLine("Semester          : " + sem);
            Console.WriteLine("Admission Fees    : Rs. " + fees.ToString("F2"));

            if (isScholarship)
            {
                Console.WriteLine("Scholarship       : 10%");
                Console.WriteLine("Scholarship Amount: Rs. " + scholarship_avail.ToString("F2"));
            }
            else
            {
                Console.WriteLine("Scholarship       : Not Available");
                Console.WriteLine("Scholarship Amount: Rs. 0.00");
            }

            Console.WriteLine("Final Fees        : Rs. " + scholarship_fees.ToString("F2"));

            Console.WriteLine("----------------------------------------------");
        }
    }
}