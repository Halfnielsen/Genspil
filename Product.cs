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





        public Product(string status, double price, string stand)

        {
            this.id = nextId++;
            this.status = status;
            this.price = price;
            this.stand = stand;
            this.soldProducts = new List<Product>();
        }
        // Ny constructor til indlæsning fra fil (hvor id, stand, m.v. er givet)
        public Product(int id, string status, double price, string stand)
        {
            this.id = id;
            this.status = status;
            this.price = price;
            this.stand = stand;
            this.soldProducts = new List<Product>();

            // Sørger for at nextId er større end det indlæste id
            if (id >= nextId)
            {
                nextId = id + 1;
            }
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
            if (status.ToLower() == "på lager" && stand.ToLower() == "god" || stand.ToLower() == "okay")
            {
                status = "solgt";
                Console.WriteLine($"Produktet med ID {id} er blevet solgt!");
                soldProducts.Add(this);

            }
            else
            {
                Console.WriteLine($"Produktet kan ikke sælges da nuværende status er {status} som er i {stand} stand");
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
            return $"ID: {id}, Status: {status}, Pris: {price} kr, Stand: {stand}";

        }
        public string ToFileString()
        {
            return $"Product|{getId()}|{getStatus()}|{getPrice()}|{getStand()}";
        }

        //Til at indlæse fra fil
        public static Product FromString(string data)
        {
            string[] parts = data.Split('|');
            if (parts.Length < 5) throw new FormatException("Ugyldigt Product-format.");

            if (int.TryParse(parts[1], out int id) &&
                double.TryParse(parts[3], out double price))
            {
                string status = parts[2];
                string stand = parts[4];
                return new Product(id, status, price, stand);
            }
            else
            {
                throw new FormatException("Fejl ved parsing af produktdata: " + data);
            }
        }
    }
}