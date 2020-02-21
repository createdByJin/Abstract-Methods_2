using System;
using Course.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=1; i<=n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());
                
                while (ch != 'i' && ch != 'c')
                {
                    Console.WriteLine("Invalid value");
                    Console.Write("Individual or company (i/c)? ");
                    ch = char.Parse(Console.ReadLine());
                }
                
                if (ch == 'i')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());

                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            double totalTax = 0.0;
            foreach (TaxPayer taxPayer in list)
            {
                Console.WriteLine(taxPayer.Name + ": $ " + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
                totalTax += taxPayer.Tax();
            }

            Console.WriteLine();
            Console.Write("TOTAL TAXES: $ " + totalTax.ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}
