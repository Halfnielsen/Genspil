using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genspil;

namespace Genspil
{
    public static class Menu
    {
        private static List<BoardGame> dummyBoardGames = new List<BoardGame>
          {
          new BoardGame("Ticket to Ride", "1st Ed.", "Family", 2, 10, "Engelsk"),
          new BoardGame("Carcassonne", "3rd Ed.", "Strategy", 2, 5, "Tysk"),
          new BoardGame("Catan", "5th Ed.", "Strategy", 3, 15, "Dansk")
          };
        private static List<BoardGame> boardGames;

        private static int selectedIndex = 0;
        private static readonly string[] menuOptions = { "Søg", "Vis alle brætspil", "Tilføj nyt brætspil", "Rediger brætspil",
    "Administrer produkt", "Opret forespørgsler", "Vis forespørgsler for et spil",
    "Vis alle forespørgsler", "Afslut program" };

        public static void MainMenu()
        {

            boardGames = new List<BoardGame>
            {
                new BoardGame("Catan", "Standard", "Strategy", 3, 4, "English"),
                new BoardGame("Ticket to Ride", "Deluxe", "Family", 2, 5, "English")
            };

            // Tilføj nogle produkter til hvert boardgame
            boardGames[0].AddNewProduct(new Product("God", 75));
            boardGames[0].AddNewProduct(new Product("Okay", 40));
            boardGames[1].AddNewProduct(new Product("God", 75));
            boardGames[1].AddNewProduct(new Product("God", 75));

            
          


            Console.CursorVisible = false;
            bool running = true;
            int previousIndex = -1;

            while (running)
            {
                if (selectedIndex != previousIndex)
                {
                    DrawMenu();
                    previousIndex = selectedIndex;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % menuOptions.Length;
                        break;
                    case ConsoleKey.Enter:
                        running = HandleMenuSelection(selectedIndex);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        running = HandleMenuSelection(0);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        running = HandleMenuSelection(1);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        running = HandleMenuSelection(2);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        running = HandleMenuSelection(3);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        running = HandleMenuSelection(4);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        running = HandleMenuSelection(5);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        running = HandleMenuSelection(6);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        running = HandleMenuSelection(7);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.Escape:
                        running = HandleMenuSelection(8);
                        break;
                }
            }
        }

        private static bool HandleMenuSelection(int index)
        {
            Console.CursorVisible = true;
            Console.Clear();

            switch (index)
            {
                case 0:
                    Search();
                    break;
                case 1:
                    ShowBoardGameList();
                    break;
                case 2:
                    AddBoardGame();
                    break;
                case 3:
                    EditBoardGame();
                    break;
                case 4:
                    EditProduct();
                    break;
                case 5:
                    AddRequest();
                    break;
                case 6:
                    ShowRequestsPerGame();
                    break;
                case 7:
                    ShowAllRequests();
                    break;
                case 8:
                    Console.WriteLine("\nAfslutter programmet...");
                    Thread.Sleep(1000);
                    return false;
            }
            Console.CursorVisible = false;
            Console.Clear();
            // Fortsætter menuen efter metode
            return true; 
        }
        private static void DrawMenu()
        {


            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;            
            Console.WriteLine("=== Genspil ===".PadLeft(25));
            Console.ResetColor();

            
            Console.WriteLine("\n[Brug Pil-Taster og Enter til at vælge]\n");
            
            for (int i = 0; i < menuOptions.Length; i++)
            {

                
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("["); 

                if (i == menuOptions.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("0");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(i + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write("] "); 

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(menuOptions[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(menuOptions[i]);
                }

                Console.WriteLine();
            }
        }
                
        private static void Search()
        {

            Console.WriteLine("Søger efter spil");

            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        private static void ShowBoardGameList()
        {

            Console.WriteLine("Vis alle Brætspil");

            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        private static void AddBoardGame()
        {
            Console.WriteLine("\nOpret nyt brætspil:");

            Console.Write("Navn: ");
            string name = Console.ReadLine();

            Console.Write("Udgave: ");
            string edition = Console.ReadLine();

            Console.Write("Genre: ");
            string genre = Console.ReadLine();

            int minPlayers = GetValidInt("Minimum antal spillere: ", 1);
            int maxPlayers = GetValidInt("Maksimum antal spillere: ", minPlayers);

            Console.Write("Sprog: ");
            string language = Console.ReadLine();

            BoardGame newGame = new BoardGame(name, edition, genre, minPlayers, maxPlayers, language);
            boardGames.Add(newGame);

            Console.WriteLine($"\n'{newGame.Name}' er oprettet og tilføjet til listen.");
            Console.ReadLine();
            Console.Clear();
        }


        public static void EditBoardGame()
        {
            BoardGame selectedGame = SelectBoardGame("opdatere");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");

            Console.Write("Nyt navn: ");
            string newName = Console.ReadLine();
            Console.Write("Ny udgave: ");
            string newEdition = Console.ReadLine();
            Console.Write("Ny genre: ");
            string newGenre = Console.ReadLine();
            int newMinPlayerCount = GetValidInt("Ny minimum antal spillere: ", 1);
            int newMaxPlayerCount = GetValidInt($"Ny maksimum antal spillere (skal være mindst {newMinPlayerCount}): ", newMinPlayerCount);
            Console.Write("Nyt sprog: ");
            string newLanguage = Console.ReadLine();

            selectedGame.UpdateDetails(newName, newEdition, newGenre, newMinPlayerCount, newMaxPlayerCount, newLanguage);

            Console.WriteLine("\nOpdateret BoardGame:");
            Console.WriteLine(selectedGame);
            Console.ReadLine();
            Console.Clear();
            MainMenu();
        }
        private static void ShowAllRequests()
        {
            Console.WriteLine("Alle forespørgsler på tværs af spil:\n");

            int total = 0;
            foreach (var game in dummyBoardGames)
            {
                foreach (var req in game.Requests)
                {
                    Console.WriteLine($"[Spil: {game.Name}] {req}");
                    total++;
                }
            }

            if (total == 0)
            {
                Console.WriteLine("Ingen forespørgsler fundet.");
            }

            Console.ReadKey();
        }
        private static void EditProduct()
        {
            Console.WriteLine("Rediger et produkt:\n");

            // Vælg boardgame
            BoardGame selectedGame = SelectBoardGame("redigere et produkt fra");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}");

            // Vis produkter
            List<Product> products = selectedGame.Products;
            if (products.Count == 0)
            {
                Console.WriteLine("Der er ingen produkter tilknyttet dette spil.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nProdukter:");
            foreach (Product p in products)
            {
                Console.WriteLine(p); // ToString() viser ID, status og pris
            }

            // Vælg produkt-ID
            int productId = GetValidInt("\nIndtast ID på produktet du vil redigere: ");
            Product productToEdit = products.FirstOrDefault(p => p.getId() == productId);

            if (productToEdit == null)
            {
                Console.WriteLine("Produkt med det ID blev ikke fundet.");
                Console.ReadKey();
                return;
            }

            // Brugeren indtaster ny pris og status
            double newPrice;
            while (true)
            {
                Console.Write("Indtast ny pris: ");
                if (double.TryParse(Console.ReadLine(), out newPrice)) break;
                Console.WriteLine("Ugyldig pris. Prøv igen.");
            }

            Console.Write("Indtast ny status (på lager / reperation / utilgængelig): ");
            string newStatus = Console.ReadLine() ?? "";

            // Rediger produkt
            productToEdit.editProduct(newPrice, newStatus);

            Console.WriteLine("\nProdukt opdateret.");
            Console.ReadLine();            
        }


        private static void AddRequest()
        {
            Console.WriteLine("Opret ny forespørgsel:\n");

            Console.WriteLine("Vil du vælge et eksisterende spil eller oprette et nyt?");
            Console.WriteLine("[1] Vælg eksisterende spil");
            Console.WriteLine("[2] Opret nyt spil");

            int choice = GetValidInt("Dit valg: ", 1, 2);

            if (choice == 2)
            {
                AddBoardGame(); // Bruger din eksisterende metode til at tilføje et nyt spil
            }
            Console.Clear();
            // Nu vælger vi spillet (nyt eller eksisterende) med din eksisterende metode
            BoardGame selectedGame = SelectBoardGame("oprette en forespørgsel på");
            Console.Clear();
            Console.WriteLine($"Du har valgt: {selectedGame.Name}");

            // Kundeinfo
            Console.Write("\nIndtast kundens navn: ");
            string customerName = Console.ReadLine();

            Console.Write("Indtast kundens email: ");
            string email = Console.ReadLine();

            int phone;
            while (true)
            {
                Console.Write("Indtast kundens telefonnummer: ");
                if (int.TryParse(Console.ReadLine(), out phone)) break;
                Console.WriteLine("Ugyldigt nummer, prøv igen.");
            }

            Customer customer = new Customer(customerName, email, phone);

            // Dummy medarbejder
            Employee dummyEmployee = new Employee("Test Medarbejder", "medarbejder@firma.dk", 12345678);

            // Opret forespørgsel
            int requestID = selectedGame.Requests.Count + 1;
            Request newRequest = new Request(requestID, DateTime.Now)
            {
                Customer = customer,
                Employee = dummyEmployee,
                BoardGame = selectedGame
            };

            selectedGame.AddNewRequest(newRequest);

            Console.WriteLine($"\nForespørgsel oprettet til '{selectedGame.Name}':");
            Console.WriteLine(newRequest);
            Console.ReadLine();
        }




        // skal den hedde showrequestspergame eller showrequests?
        private static void ShowRequestsPerGame()
        {
            BoardGame selectedGame = SelectBoardGame("se forespørgsler for");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");
            selectedGame.ShowGameRequests();
            Console.ReadKey();
        }        
        
       
        //anettes
        //Metode til valg af boardgame
        internal static BoardGame SelectBoardGame(string action)
        {
            Console.WriteLine($"Vælg et boardgame, som du vil {action}:");
            for (int i = 0; i < boardGames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {boardGames[i].Name}");
            }
            int selectedIndex = GetValidInt("Indtast nummeret for det ønskede boardgame: ", 1, boardGames.Count);
            return boardGames[selectedIndex - 1];
        }

        // Henter og validerer brugerens valg af boardgame
        public static int GetValidInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                {
                    break;
                }
                Console.WriteLine($"Ugyldigt input. Indtast et heltal mellem {min} og {max}.");
            }
            return value;
        }

        public static void AddProduct()
        {
            BoardGame selectedGame = SelectBoardGame("tilføje et nyt produkt til");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");

            UserInputAddNewProduct(selectedGame);

            Console.WriteLine("\nOpdateret BoardGame:");
            Console.WriteLine(selectedGame);
            Console.ReadLine();
        }

        internal static void UserInputAddNewProduct(BoardGame game)
        {
            Console.Write("Indtast produkt status (på lager / reperation): ");
            string status = Console.ReadLine() ?? "";

            double price;
            while (true)
            {
                Console.Write("Indtast produkt pris (f.eks. 49.99): ");
                if (double.TryParse(Console.ReadLine(), out price))
                    break;
                Console.WriteLine("Ugyldigt input. Indtast en gyldig pris.");
            }

            Product newProduct = new Product(status, price); // ID genereres automatisk
            game.AddNewProduct(newProduct);
            Console.WriteLine("\nNyt produkt er tilføjet!");
        }


        public static void AvailableProductsForSelectedGame()
        {
            BoardGame selectedGame = SelectBoardGame("se tilgængelige produkter for");

            if (selectedGame.CheckAvailability())
            {
                List<Product> availableProducts = selectedGame.GetAvailableProducts();

                Console.WriteLine($"Følgende produkter er på lager for spillet '{selectedGame.Name}':");
                foreach (Product product in availableProducts)
                {
                    Console.WriteLine($"- {product}");
                }
            }
            else
            {
                Console.WriteLine($"Ingen produkter på lager for spillet '{selectedGame.Name}'.");
            }

        }
   
    public class Employee
    {
        public string Name { get; set; }
        public Employee(string name, string email, int phone) => Name = name;
    }

}
