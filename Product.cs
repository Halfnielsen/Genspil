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
        private static int nextId = 1;
        private int id;
        private string status;
        private double price;
        private string stand;
        private List<Product> soldProducts;




        
        public Product(string status, double price)

        {
            this.id = nextId++;
            this.status = status;
            this.price = price;
            this.stand = stand;
            this.soldProducts = new List<Product>();
        }

        public int getId() { return id; }
       

        public string getStatus() { return status; }
        public void setStatus(string status) { this.status = status; }

        public double getPrice() { return price; }
        public void setPrice(double price) { this.price = price; }

        public string getStand() { return stand; }
        public void setStand(string stand) { this.stand = stand; }

        public void Sell()

        {
            if (status.ToLower() == "på lager")
            {
                status = "solgt";
                Console.WriteLine($"Produktet med ID {id} er blevet solgt!");
                soldProducts.Add(this);

            }
            else
            {
                Console.WriteLine($"Produktet kan ikke sælges da nuværende status er {status}");
            }

        }


        public void EditProduct(double price, string status)
        {
            this.price = price;
            if (status.ToLower() == "på lager" || status.ToLower() == "reperation" || status.ToLower() == "utilgængelig")
            {
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

