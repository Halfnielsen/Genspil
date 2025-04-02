using System;
using System.Collections.Generic;

namespace Genspil
{
    public class Employee
    {
        // Auto-properties
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        // Constructor
        public Employee(string name, string email, int phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString() => $"{Name} ({Email}, {Phone})";

        // Static liste af ansatte
        private static List<Employee> employees = new List<Employee>
        {
            new Employee("Jonas", "jonas@genspil.dk", 30552688),
            new Employee("Jamal", "jamal@genspil.dk", 35332126),
            new Employee("Emilie", "emilie@genspil.dk", 35424854)
        };

        public static List<Employee> GetEmployees() => employees;

        public static Employee SelectEmployee()
        {
            Console.WriteLine("\nVælg medarbejderen som opretter forespørgslen:");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {employees[i].Name}");
            }

            int selectedIndex;
            while (true)
            {
                Console.Write("Indtast nummeret på medarbejderen: ");
                if (int.TryParse(Console.ReadLine(), out selectedIndex) &&
                    selectedIndex >= 1 && selectedIndex <= employees.Count)
                {
                    break;
                }
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }

            return employees[selectedIndex - 1];
        }
    }
}
