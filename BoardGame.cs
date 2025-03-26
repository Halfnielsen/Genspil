using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class BoardGame
    {
        // De private felter er overflødige, hvis du bruger properties, men det er fint
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public string Language { get; set; }
        public List<Product> Products { get; set; }

        // Constructor der modtager en liste af produkter
        public BoardGame(string name, string edition, string genre, int minPlayerCount, int maxPlayerCount, string language, List<Product> products)
        {
            Name = name;
            Edition = edition;
            Genre = genre;
            MinPlayerCount = minPlayerCount;
            MaxPlayerCount = maxPlayerCount;
            Language = language;
            Products = products ?? new List<Product>();
        }

        // Constructor som starter med en tom produktliste
        public BoardGame(string name, string edition, string genre, int minPlayerCount, int maxPlayerCount, string language)
            : this(name, edition, genre, minPlayerCount, maxPlayerCount, language, new List<Product>())
        {
        }

        // Metode til at tilføje et produkt til boardgame
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                Products.Add(product);
            }
        }

        public override string ToString()
        {
            string productsStr = string.Join(Environment.NewLine, Products.Select(p => p.ToString()));
            return $"BoardGame{{ Spilnavn='{Name}', Udgave='{Edition}', Genre='{Genre}', " +
                   $"Antal spillere={MinPlayerCount}-{MaxPlayerCount}, Sprog='{Language}', \nProdukter:{Environment.NewLine}{productsStr}\n}}";
        }

        // Metode til at opdatere boardgame detaljer
        public void UpdateDetails(string newName, string newEdition, string newGenre, int newMinPlayerCount, int newMaxPlayerCount, string newLanguage)
        {
            Name = newName;
            Edition = newEdition;
            Genre = newGenre;
            MinPlayerCount = newMinPlayerCount;
            MaxPlayerCount = newMaxPlayerCount;
            Language = newLanguage;
            Console.WriteLine($"\n{newName} er blevet opdateret!");
        }
    }
}

