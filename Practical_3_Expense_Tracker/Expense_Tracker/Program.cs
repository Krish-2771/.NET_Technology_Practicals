using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Expense_Tracker
{
    class Expense
    {
        public int ExpenseId;
        public string Category;
        public Double Amount;
        public string paymentMethod;
        public DateTime ExpenseDate;

        public void AddExpenes()
        {
            Console.Write("Enter Expense ID: ");
            ExpenseId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Expense Category: ");
            Category = Console.ReadLine();

            Console.Write("Enter Expense Amount: ");
            Amount = Convert.ToDouble(Console.ReadLine());

            if (Amount <= 0)
            {
                throw new Exception("Amount should be greater than zero.");
            }

            Console.Write("Enter Payment Method (cash/upi/card): ");
            paymentMethod = Console.ReadLine();

            ExpenseDate = DateTime.Now;
        }

        public void DisplayExpense()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Expense ID: " + ExpenseId);
            Console.WriteLine("Expense Category: " + Category);
            Console.WriteLine("Expense Amount: " + Amount);
            Console.WriteLine("Payment Method: " + paymentMethod);
            Console.WriteLine("Expense Date: " + ExpenseDate);
            Console.WriteLine("==================================");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Expense> expenses = new List<Expense>();

            void menu()
            {
                Console.WriteLine("=============================");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expense");
                Console.WriteLine("3. View Total Expense");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=============================");
            }

            while (true)
            {
                try
                {
                    menu();
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Expense E1 = new Expense();
                        E1.AddExpenes();
                        expenses.Add(E1);
                    }
                    else if (choice == 2)
                    {
                        if (expenses.Count == 0)
                        {
                            Console.WriteLine("No expenses found.");
                            continue;
                        }

                        foreach (Expense expense in expenses)
                        {
                            expense.DisplayExpense();
                        }
                    }
                    else if (choice == 3)
                    {
                        double temp = 0;

                        foreach (Expense expense in expenses)
                        {
                            temp += expense.Amount;
                        }

                        Console.Write("Total Expense : " + temp);
                        Console.WriteLine();
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception occur : {e.Message}");
                }
            }
        }
    }
}