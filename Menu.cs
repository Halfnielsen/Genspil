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
        private static DataHandler dataHandler = new DataHandler();
        private static int selectedIndex = 0;

        private static readonly string[] menuOptions = { "Søg", "Vis alle brætspil", "Administrer brætspil", 
         "Administrer produkt", "Administrer forespørgsler", "Afslut program" };

        public static void MainMenu(Storage storage)
        {
            Console.CursorVisible = false;
            bool running = true;
            int previousIndex = -1;
            Console.Clear();

            while (running)
            {
                // Tegner kun når brugeren ændrer valg
                if (selectedIndex != previousIndex)
                {
                    DrawMenu();
                    previousIndex = selectedIndex;
                }

                // Læs input og håndter navigation
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
                        // Kald den valgte menu-funktion
                        running = HandleMenuSelection(selectedIndex, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;

                    // Direkte genvejstaster (1–0) til hovedmenuvalg
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        running = HandleMenuSelection(0, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        running = HandleMenuSelection(1, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        running = HandleMenuSelection(2, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;                    
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        running = HandleMenuSelection(3, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        running = HandleMenuSelection(4, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    /*case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        running = HandleMenuSelection(5, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        running = HandleMenuSelection(6, storage);
                        selectedIndex = 0;
                        previousIndex = -1;
                        break;*/                    
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.Escape:
                        running = HandleMenuSelection(5, storage);
                        break;
                }
            }
        }

        private static int GetMenuChoice(string title, List<string> options)
        {
            int selectedIndex = 0;
            int previousIndex = -1;
            Console.CursorVisible = false;

            ConsoleKey key;
            do
            {
                if (selectedIndex != previousIndex)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{title}]\n");
                    Console.ResetColor();

                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[");

                        if (i == 0) Console.ForegroundColor = ConsoleColor.Red;
                        else Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(i);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("] ");

                        if (i == selectedIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(options[i]);
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(options[i]);
                        }
                    }

                    // Ryd overskydende linjer i konsollen              
                    int linesToClear = Console.WindowHeight - options.Count - 3;
                    for (int i = 0; i < linesToClear; i++)
                        Console.WriteLine();

                    previousIndex = selectedIndex;
                }

                // Navigér i menuen
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Count;
                        break;

                    case ConsoleKey.Enter:
                        break;

                    // Numeriske genvejstaster til valg
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        selectedIndex = 0;
                        key = ConsoleKey.Enter;
                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (options.Count > 1) { selectedIndex = 1; key = ConsoleKey.Enter; }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (options.Count > 2) { selectedIndex = 2; key = ConsoleKey.Enter; }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (options.Count > 3) { selectedIndex = 3; key = ConsoleKey.Enter; }
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (options.Count > 4) { selectedIndex = 4; key = ConsoleKey.Enter; }
                        break;
                }

            } while (key != ConsoleKey.Enter);

            Console.Clear();
            Console.CursorVisible = true;
            return selectedIndex;
        }



        private static bool HandleMenuSelection(int index, Storage storage)
        {
            Console.CursorVisible = true;
            Console.Clear();

            switch (index)
            {
                case 0:
                    Search(storage);
                    break;
                case 1:
                    ShowBoardGameList(storage);
                    break;
                case 2:
                    ManageBoardGames(storage); 
                    break;
                case 3:
                    ManageProducts(storage);
                    break;
                case 4:
                    ManageRequests(storage);
                    break;              
                case 5:
                    Console.WriteLine("\nAfslutter programmet...");
                    Thread.Sleep(1000);
                    return false;
            }
            Console.CursorVisible = false;
            Console.Clear();
            
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
                //Farve af menuvalg
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

                // Markér det valgte menupunkt med baggrundsfarve
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

        private static void Search(Storage storage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Søg efter brætspil]\n");
            Console.ResetColor();
            Console.Write("Indtast søgeord (navn, genre eller sprog): ");
            string query = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("\nSøgeordet var tomt. Tryk på en tast for at vende tilbage.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Filtrer spil der matcher søgeordet
            List<BoardGame> games = storage.GetBoardGames();
            var matches = games
                .Where(game =>
                    game.Name.ToLower().Contains(query) ||
                    game.Genre.ToLower().Contains(query) ||
                    game.Language.ToLower().Contains(query))
                .ToList();

            Console.Clear();

            // Vis søgeresultater
            if (matches.Count == 0)
            {
                Console.WriteLine($"Ingen spil matchede søgningen '{query}'.");
            }
            else
            {
                Console.WriteLine($"Fundet {matches.Count} spil der matcher '{query}':\n\n");
                foreach (var game in matches)
                {
                    Console.WriteLine(game);
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
            Console.Clear();
        }
        private static void ShowBoardGameList(Storage storage)
        {
            int sortChoice = GetMenuChoice("Vis alle brætspil - Vælg sortering", new List<string>
            {
            "Tilbage til menu",
            "Ingen sortering",
            "Sortér efter navn",
            "Sortér efter genre"
            });

            if (sortChoice == 0)
                return;

            // Bestem den sorterede liste og sorteringskriteriet baseret på brugerens valg
            List<BoardGame> games;
            string sortCriteria;

            switch (sortChoice)
            {
                case 1:
                    games = storage.GetBoardGames();
                    sortCriteria = "Ingen sortering";
                    break;
                case 2:
                    games = storage.GetBoardGamesSortedByName();
                    sortCriteria = "Navn";
                    break;
                case 3:
                    games = storage.GetBoardGamesSortedByGenre();
                    sortCriteria = "Genre";
                    break;
                default:
                    games = storage.GetBoardGames();
                    sortCriteria = "Ingen sortering";
                    break;
            }

            PrintBoardGames(games, sortCriteria);
        }

        private static void PrintBoardGames(List<BoardGame> games, string sortCriteria)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[Liste over alle brætspil med produkter - Sorteret: {sortCriteria}]\n");
            Console.ResetColor();


            if (games.Count == 0)
            {
                Console.WriteLine("Ingen brætspil tilgængelige.");
            }
            else
            {
                int count = 1;
                foreach (BoardGame boardGame in games)
                {
                    // Udskriv spiloplysninger
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"[{count}] ");
                    Console.ResetColor();
                    Console.WriteLine($"{boardGame.Name} ({boardGame.Edition}) - {boardGame.Genre}, {boardGame.MinPlayerCount}-{boardGame.MaxPlayerCount} spillere, Sprog: {boardGame.Language}");

                    // Udskriv kun "på lager" produkter
                    List<Product> availableProducts = boardGame.GetAvailableProducts();
                    if (availableProducts.Count == 0)
                    {
                        Console.WriteLine("   └─ Ingen produkter på lager.");
                    }
                    else
                    {
                        foreach (Product product in availableProducts)
                        {
                            Console.WriteLine($"   └─ {product}");
                        }
                    }

                    Console.WriteLine();
                    count++;
                }
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ManageBoardGames(Storage storage)
        {
            int choice = GetMenuChoice("Administrer brætspil", new List<string> {
             "Tilbage til menu",
             "Tilføj nyt brætspil",
             "Rediger eksisterende brætspil",
             "Slet eksisterende brætspil"
             });

            if (choice == 0)
                return;

            if (choice == 1)
                AddBoardGame(storage);
            else if (choice == 2)
                EditBoardGame(storage);
            else if (choice == 3)
                DeleteBoardGame(storage);
            else
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
        }

        private static void AddBoardGame(Storage storage)
        {
           
            Console.Clear();
            Console.WriteLine("Opret nyt brætspil\n");

            // Indtast brætspiloplysninger
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
            
            //Tilføj brætspil til lager
            storage.AddBoardGame(newGame);

            Console.WriteLine($"\n'{newGame.Name}' er oprettet og tilføjet til listen.");

            Console.ReadLine();
            Console.Clear();

            
            int addProductChoice = GetMenuChoice("Vil du tilføje et produkt til spillet?", new List<string> {
            "Nej",
            "Tilføj produkt"
             });

            if (addProductChoice == 1)
            {
                UserInputAddNewProduct(newGame);
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");

            // Gem ændringer
            dataHandler.SaveBoardGamesToFile(storage.GetBoardGames());
            Console.ReadKey();
            Console.Clear();
        }


        public static void EditBoardGame(Storage storage)
        {
            

            Console.Clear();
            BoardGame selectedGame = SelectBoardGame(storage, "opdatere");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");

            //Ændringer
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

            //Gem ændringer
            dataHandler.SaveBoardGamesToFile(storage.GetBoardGames());
            Console.ReadLine();
            Console.Clear();
            
        }

        public static void DeleteBoardGame(Storage storage)
        {
            // Brug SelectBoardGame til at lade brugeren vælge, hvilket brætspil der skal slettes.
            BoardGame selectedGame = SelectBoardGame(storage, "slette");

            // Kald remove-metoden i Storage-klassen for at slette brætspillet.
            bool removed = storage.RemoveBoardGame(selectedGame);

            if (removed)
            {
                Console.WriteLine($"Brætspillet {selectedGame.Name} ({selectedGame.Edition}, {selectedGame.Language}) blev slettet.");
            }
            else
            {
                Console.WriteLine("Fejl ved sletning af brætspillet.");
            }

            Console.WriteLine("Tryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
        }
        private static void ManageProducts(Storage storage)
        {
            int choice = GetMenuChoice("Administrer produkt", new List<string> {
             "Tilbage til menu",
             "Tilføj nyt produkt",
             "Vælg et spil og rediger et produkt",
             "Sælg et produkt"
            });

            if (choice == 0)
                return;

            if (choice == 1)
            {
                AddProduct(storage);
                return;
            }

            if (choice == 2)
            {
                EditProduct(storage);
                return;
            }

            if (choice == 2)
            {
                SellProduct(storage);
                return;
            }
        }

        public static void AddProduct(Storage storage)
        {
            BoardGame selectedGame = SelectBoardGame(storage, "tilføje et nyt produkt til");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");
            UserInputAddNewProduct(selectedGame);

            //Gem ændringer
            dataHandler.SaveBoardGamesToFile(storage.GetBoardGames());
            Console.WriteLine("\nOpdateret BoardGame:");
            Console.WriteLine(selectedGame);
            Console.ReadLine();
        }

        internal static void UserInputAddNewProduct(BoardGame game)
        {
            // Læs status
            Console.Write("Indtast produkt status (på lager / reperation): ");
            string status = Console.ReadLine() ?? "";

            // Læs pris
            double price;
            while (true)
            {
                Console.Write("Indtast produkt pris (f.eks. 49.99): ");
                if (double.TryParse(Console.ReadLine(), out price))
                    break;
                Console.WriteLine("Ugyldigt input. Indtast en gyldig pris.");
            }

            // Læs stand 
            Console.Write("Indtast stand status (god / okay / slidt): ");
            string stand = Console.ReadLine() ?? "";

            // Opret og tilføj produkt
            Product newProduct = new Product(status, price, stand);
            game.AddNewProduct(newProduct);
            Console.WriteLine("\nNyt produkt er tilføjet!");
        }

        private static void EditProduct(Storage storage)
        {
            Console.Clear();
            Console.WriteLine("Rediger et produkt:\n");

            // Vælg boardgame
            BoardGame selectedGame = SelectBoardGame(storage, "redigere et produkt fra");
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
                Console.WriteLine(p);
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

            // Ny pris
            double newPrice;
            while (true)
            {
                Console.Write("Indtast ny pris: ");
                if (double.TryParse(Console.ReadLine(), out newPrice)) break;
                Console.WriteLine("Ugyldig pris. Prøv igen.");
            }

            // Ny status
            Console.Write("Indtast ny status (på lager / reperation): ");
            string newStatus = Console.ReadLine() ?? "";

            // Ny stand
            Console.Write("Indtast ny stand (f.eks. god / okay / slidt): ");
            string newStand = Console.ReadLine() ?? "";

            // Opdater produktet
            productToEdit.EditProduct(newPrice, newStatus, newStand);

            // Gem ændringer
            dataHandler.SaveBoardGamesToFile(storage.GetBoardGames());

            Console.WriteLine("\nProdukt opdateret.");
            Console.ReadLine();
        }

        /*public static void AvailableProductsForSelectedGame(Storage storage)
        {
            BoardGame selectedGame = SelectBoardGame(storage, "se tilgængelige produkter for");

            // Tjek lager
            if (selectedGame.CheckAvailability())
            {
                // Hent produkter med status = "på lager"
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
        }*/

        private static void SellProduct(Storage storage)
        {
            Console.Clear();
            BoardGame selectedGame = SelectBoardGame(storage, "sælge et produkt fra");

            // Hvis brætspillet ikke har nogen produkter
            if (selectedGame.Products.Count == 0)
            {
                Console.WriteLine("Der er ingen produkter tilknyttet dette spil.");
                Console.ReadKey();
                return;
            }

            // Vis produkter
            Console.WriteLine("\nProdukter på lager:");
            foreach (var product in selectedGame.Products)
            {
                Console.WriteLine(product);
            }

            // Vælg produkt via ID
            int productId = GetValidInt("\nIndtast ID på produktet du vil sælge: ");
            Product productToSell = selectedGame.Products.FirstOrDefault(p => p.getId() == productId);

            // Tjek om produkt eksisterer
            if (productToSell == null)
            {
                Console.WriteLine("Produkt med det ID blev ikke fundet.");
            }
            else
            {
                productToSell.Sell();
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
        }

        private static void ManageRequests(Storage storage)
        {
            // Opret en undermenu for forespørgsler
            int choice = GetMenuChoice("Administrer forespørgsler", new List<string> {
                "Tilbage til menu",
                "Opret forespørgsel",
                "Vis forespørgsler for et spil",
                "Vis alle forespørgsler",
                "Slet forespørgsel"
            });

            if (choice == 0)
                return;

            switch (choice)
            {
                case 1:
                    AddRequest(storage);
                    break;
                case 2:
                    ShowRequestsPerGame(storage);
                    break;
                case 3:
                    ShowAllRequests(storage);
                    break;
                case 4:
                    DeleteRequest(storage);
                    break;
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void AddRequest(Storage storage)
        {
            int choice = GetMenuChoice("Opret ny forespørgsel", new List<string> {
             "Tilbage til menu",
             "Vælg eksisterende spil",
             "Opret nyt spil"
            });

            switch (choice)
            {
                case 0:
                    ReturnToMenu();
                    return;

                case 2:
                    AddBoardGame(storage);
                    break;            
            }

            Console.Clear();
            BoardGame selectedGame = SelectBoardGame(storage, "oprette en forespørgsel på");
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

            // Medarbejdervalg
            Console.Clear();
            Employee selectedEmployee = Employee.SelectEmployee();
            Console.Clear();

            // Opret forespørgsel
            Request newRequest = new Request(DateTime.Now)
            {
                Customer = customer,
                Employee = selectedEmployee,
                BoardGame = selectedGame
            };

            selectedGame.AddNewRequest(newRequest);

            //Gem ændringer
            dataHandler.SaveBoardGamesToFile(storage.GetBoardGames());
            Console.WriteLine($"\nForespørgsel oprettet til '{selectedGame.Name}':");
            Console.WriteLine(newRequest);
            Console.ReadLine();
        }
        
        private static void ShowRequestsPerGame(Storage storage)
        {
            Console.Clear();
            BoardGame selectedGame = SelectBoardGame(storage, "se forespørgsler for");
            Console.Clear();
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name} ({selectedGame.Edition}, {selectedGame.Language})\n");
            selectedGame.ShowGameRequests();
        }

        private static void ShowAllRequests(Storage storage)
        {
            Console.Clear();
            Console.WriteLine("Alle forespørgsler på tværs af spil:\n");

            int total = 0;
            foreach (var game in storage.GetBoardGames())
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
        }

        private static void DeleteRequest(Storage storage)
        {
            // Saml alle requests fra hvert brætspil (brug den eksisterende Requests-list)
            var allRequests = new List<(BoardGame Game, Request Request)>();
            foreach (var game in storage.GetBoardGames())
            {
                foreach (var request in game.Requests)
                {
                    allRequests.Add((game, request));
                }
            }

            if (allRequests.Count == 0)
            {
                Console.WriteLine("Ingen forespørgsler tilgængelige for sletning.");
                Console.WriteLine("Tryk på en tast for at vende tilbage til menuen...");
                Console.ReadKey();
                return;
            }

            // Sorter listen baseret på RequestID
            allRequests = allRequests.OrderBy(r => r.Request.RequestID).ToList();

            // Vis alle requests med tilhørende brætspilnavn
            Console.WriteLine("Alle forespørgsler:");
            foreach (var entry in allRequests)
            {
                Console.WriteLine($"[{entry.Request.RequestID}] {entry.Request} (Brætspil: {entry.Game.Name})");
            }

            Console.Write("Indtast ID for den forespørgsel, du vil slette: ");
            if (!int.TryParse(Console.ReadLine(), out int requestId))
            {
                Console.WriteLine("Ugyldigt valg.");
                return;
            }

            // Find det entry med det matchende ID
            var selectedEntry = allRequests.FirstOrDefault(r => r.Request.RequestID == requestId);
            if (selectedEntry == default)
            {
                Console.WriteLine("Forespørgslen blev ikke fundet.");
                return;
            }

            BoardGame selectedGame = selectedEntry.Game;
            Request selectedRequest = selectedEntry.Request;

            // Find index for den valgte request i det tilhørende brætspils request-liste
            int requestIndex = selectedGame.Requests.IndexOf(selectedRequest);
            if (requestIndex == -1)
            {
                Console.WriteLine("Fejl: Forespørgslen blev ikke fundet i brætspillet.");
                return;
            }

            // Kald metoden i BoardGame-klassen for at fjerne requesten
            bool result = selectedGame.RemoveRequest(requestIndex);
            if (result)
            {
                Console.WriteLine("Forespørgslen blev slettet.");
            }
            else
            {
                Console.WriteLine("Fejl ved sletning af forespørgslen.");
            }
        }



        internal static BoardGame SelectBoardGame(Storage storage, string action)
        {
            List<BoardGame> boardGames = storage.GetBoardGames(); 

            Console.WriteLine($"Vælg et boardgame, som du vil {action}:");
            for (int i = 0; i < boardGames.Count; i++)
            {
                var game = boardGames[i];
                Console.WriteLine($"{i + 1}. {game.Name} ({game.Edition}, {game.Language})");
            }
            int selectedIndex = GetValidInt("Indtast nummeret for det ønskede boardgame: ", 1, boardGames.Count);
            return boardGames[selectedIndex - 1];
        }
        
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

        private static void ReturnToMenu()
        {

            Console.Clear();
        }

    }

}
