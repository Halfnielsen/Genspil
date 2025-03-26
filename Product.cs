using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.CompilerServices;

using System.Text;
using System.Threading.Tasks;

namespace Genspil
{


    public class Product
    {
        private int id;
        private string status;
        private double price;

        
        public Product(int id, string status, double price)
        {
            this.id = id;
            this.status = status;
            this.price = price;
        }
        public int getId() { return id;}
        public void setId(int id) { this.id = id;}
        
        public string getStatus() { return status;}
        public void setStatus(string status) { this.status = status;}
       
        public double getPrice() { return price;}
        public void setPrice(double price) { this.price = price;}

        public void sell()
        {
            if (status.ToLower() == "på lager")
            {
                status = "solgt";
                Console.WriteLine($"Produktet med ID {id} er blevet solgt!");
            }
            else
            {
                Console.WriteLine($"Produktet kan ikke sælges da nuværende status er {status}");  
            }

        }
        public void editProduct(double price, string status)
        {
            this.price = price;
            if (status.ToLower() == "på lager" || status.ToLower() == "reperation" || status.ToLower() == "utilgængelig") {
                this.status = status.ToLower();
                Console.WriteLine($"Produktet med ID{id} er opdateret til pris: {price} og status: {status}");
            }
        }
        public override string ToString()
        {
            return $"ID: {id}, Status: {status}, Pris: {price} kr";
        }

    }
}

