using System;

namespace Genspil
{
    public class Customer
    {
        // Properties
        
        public string Name { get; private set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        // Constructor
        public Customer(string name, string email, int phone)
        {
            
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"Navn: {Name}, Email: {Email}, Tlf: {Phone}";
        }
    }
}
