using System;
using System.Collections.Generic;
using System.Globalization;
using AbstractClassCSharp.Entities;

namespace AbstractClassCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayerList = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int numberOfTaxPlayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfTaxPlayers; i += 1)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                String name = Console.ReadLine();
                Console.Write("Anual income: ");
                double income = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (type == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayerList.Add(new Individual(name, income, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    taxPayerList.Add(new Company(name, income, numberOfEmployees));
                }
            }

            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            foreach (TaxPayer txp in taxPayerList)
            {
                double tax = txp.Tax();
                Console.WriteLine(txp.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
                sum += tax;
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
