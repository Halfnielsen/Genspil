using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Product
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }

        public Product(int id, string status, double price)
        {
            Id = id;
            Status = status;
            Price = price;
        }

        public override string ToString()
        {
            return $"Product{{ id={Id}, status='{Status}', price={Price} }}";
        }

    }
}
