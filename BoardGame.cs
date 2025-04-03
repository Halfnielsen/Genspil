using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class BoardGame
    {
        //Properties
        public string Name { get; private set; }
        public string Edition { get; private set; }
        public string Genre { get; private set; }
        public int MinPlayerCount { get; private set; }
        public int MaxPlayerCount { get; private set; }
        public string Language { get; private set; }
        public List<Product> Products { get; private set; }
        public List<Request> Requests { get; private set; }

        // Constructor der modtager en liste af produkter
        public BoardGame(string name, string edition, string genre, int minPlayerCount, int maxPlayerCount, string language, List<Product> products, List<Request> requests)
        {
            Name = name;
            Edition = edition;
            Genre = genre;
            MinPlayerCount = minPlayerCount;
            MaxPlayerCount = maxPlayerCount;
            Language = language;
            Products = products ?? new List<Product>();
            Requests = requests ?? new List<Request>();
        }

        // Constructor som starter med en tom produktliste
        public BoardGame(string name, string edition, string genre, int minPlayerCount, int maxPlayerCount, string language)
            : this(name, edition, genre, minPlayerCount, maxPlayerCount, language, new List<Product>(), new List<Request>())
        {
        }

        // Metode til at tilføje et produkt til boardgame
        public void AddNewProduct(Product product)
        {
            if (product != null)
            {
                Products.Add(product);
            }
        }

        public override string ToString()
        {
            string productsStr = string.Join(Environment.NewLine, Products.Select(p => p.ToString()));
            return $"Spilnavn: {Name}, Udgave: {Edition}, Genre: {Genre}, Antal spillere: {MinPlayerCount}-{MaxPlayerCount}, Sprog: {Language}\n" +
                   $"Produkter:\n{productsStr}";
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

        public void AddNewRequest(Request request)
        {
            if (request != null)
            {
                Requests.Add(request);
                Console.WriteLine("Forespørgsel tilføjet!");
            }
        }

        //Mangler customer og employee
        public void ShowGameRequests()
        {
            if (Requests.Count == 0)
            {
                Console.WriteLine("Ingen requests fundet.");
            }
            else
            {
                Console.WriteLine("Requests for dette BoardGame:");
                foreach (var request in Requests)
                {
                    Console.WriteLine(request.ToString());
                }
            }
        }

        public bool RemoveRequest(int requestIndex)
        {
            if (requestIndex < 0 || requestIndex >= Requests.Count)
            {
                // Returner false, hvis det angivne indeks er ugyldigt.
                return false;
            }

            // Fjern requesten på den angivne position.
            Requests.RemoveAt(requestIndex);
            return true;
        }

        public bool CheckAvailability()
        {
            return Products.Any(p => p.getStatus().ToLower() == "på lager");
        }

        public List<Product> GetAvailableProducts()
        {
            return Products.Where(p => p.getStatus().ToLower() == "på lager").ToList();
        }

        //Til at gemme til fil
        public string ToFileString()
        {
            return $"BoardGame|{Name}|{Edition}|{Genre}|{MinPlayerCount}|{MaxPlayerCount}|{Language}";
        }
        //Til at indlæse fra fil
        public static BoardGame FromString(string data)
        {
            string[] parts = data.Split('|');
            if (parts.Length < 7) throw new FormatException("Ugyldigt BoardGame-format.");

            string name = parts[1];
            string edition = parts[2];
            string genre = parts[3];
            int minPlayerCount = int.Parse(parts[4]);
            int maxPlayerCount = int.Parse(parts[5]);
            string language = parts[6];

            return new BoardGame(name, edition, genre, minPlayerCount, maxPlayerCount, language, new List<Product>(), new List<Request>());
        }
    }
}

