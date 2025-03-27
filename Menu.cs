using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genspil;

namespace Genspil
{
    public static class Menu
    {/*
        private static List<BoardGame> dummyBoardGames = new List<BoardGame>
          {
          new BoardGame("Ticket to Ride", "1st Ed.", "Family", 2, 10, "Engelsk"),
          new BoardGame("Carcassonne", "3rd Ed.", "Strategy", 2, 5, "Tysk"),
          new BoardGame("Catan", "5th Ed.", "Strategy", 3, 15, "Dansk")
          };
        */
        private static int selectedIndex = 0;
        private static readonly string[] menuOptions = { "Søg", "Vis alle brætspil", "Tilføj nyt brætspil", "Rediger brætspil",
    "Administrer produkt", "Opret forespørgsler", "Vis forespørgsler for et spil",
    "Vis alle forespørgsler", "Afslut program" };

        public static void MainMenu()
        {
            
          

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
                        selectedIndex = 0; // Optional: reset til toppen efter valg
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        running = HandleMenuSelection(0);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        running = HandleMenuSelection(1);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        running = HandleMenuSelection(2);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        running = HandleMenuSelection(3);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        running = HandleMenuSelection(4);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        running = HandleMenuSelection(5);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        running = HandleMenuSelection(6);
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        running = HandleMenuSelection(7);
                        selectedIndex = 0;
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
            
            Console.WriteLine("Tilføjet nyt Brætspil");
            
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        private static void EditBoardGame()
        {

            Console.WriteLine("Rediger Brætspil");

            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        private static void EditProduct()
        {

            Console.WriteLine("Rediger Produkt");

            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        private static void AddRequest()
        {
            Console.WriteLine("Vælg et spil at lave en forespørgsel til:\n");

            for (int i = 0; i < dummyBoardGames.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {dummyBoardGames[i].Name}");
            }

            Console.Write("\nIndtast nummeret på spillet: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= dummyBoardGames.Count)
            {
                var selectedGame = dummyBoardGames[choice - 1];

                // Indtast kundeinformation
                Console.Write("\nIndtast kundens navn: ");
                string name = Console.ReadLine();

                Console.Write("Indtast kundens email: ");
                string email = Console.ReadLine();

                int phone;
                while (true)
                {
                    Console.Write("Indtast kundens telefonnummer: ");
                    if (int.TryParse(Console.ReadLine(), out phone)) break;
                    Console.WriteLine("Ugyldigt nummer, prøv igen.");
                }

                int customerID = selectedGame.Requests.Count + 1; // Midlertidig ID (du kan lave global ID senere)
                var customer = new Customer(name, email, phone);

                // Dummy-employee indtil medarbejdersystem er klar
                var dummyEmployee = new Employee("Test Medarbejder", "medarbejder@firma.dk", 87654321);                

                int requestID = selectedGame.Requests.Count + 1;
                var newRequest = new Request(requestID, DateTime.Now)
                {
                    Customer = customer,
                    Employee = dummyEmployee,
                    BoardGame = selectedGame
                };

                selectedGame.Requests.Add(newRequest);

                Console.WriteLine($"\n Forespørgsel oprettet til '{selectedGame.Name}':");
                Console.WriteLine(newRequest);
            }
            else
            {
                Console.WriteLine("Ugyldigt valg.");
            }

            Console.ReadKey();
        }

        private static void ShowRequestsPerGame()
        {
            Console.WriteLine("Vælg et spil for at se dets forespørgsler:\n");

            for (int i = 0; i < dummyBoardGames.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {dummyBoardGames[i].Name}");
            }

            Console.Write("\nIndtast nummeret på spillet: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= dummyBoardGames.Count)
            {
                var selectedGame = dummyBoardGames[choice - 1];
                Console.WriteLine($"\nForespørgsler for '{selectedGame.Name}':");

                if (selectedGame.Requests.Count == 0)
                {
                    Console.WriteLine("Ingen forespørgsler fundet.");
                }
                else
                {
                    foreach (var req in selectedGame.Requests)
                    {
                        Console.WriteLine(req);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ugyldigt valg.");
            }

            Console.ReadKey();
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
      /*  
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

        // Henter og validerer brugerens valg af boardgame eller andet af int.
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

        // Tilføjer et nyt produkt til et valgt boardgame
        public static void AddNewProduct()
        {
            // Vis en liste og lad brugeren vælge et boardgame
            Console.WriteLine("Vælg et boardgame, som du vil tilføje et nyt produkt til:");
            for (int i = 0; i < boardGames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {boardGames[i].Name}");
            }

            int selectedIndex = GetValidInt("Indtast nummeret for det ønskede boardgame: ", 1, boardGames.Count);
            BoardGame selectedGame = boardGames[selectedIndex - 1];
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");

            // Tilføj et nyt produkt til det valgte boardgame
            UserInputAddNewProduct(selectedGame);

            // Udskriv det opdaterede boardgame med alle dets produkter
            Console.WriteLine("\nOpdateret BoardGame:");
            Console.WriteLine(selectedGame);
            Console.ReadLine();
        }
        // Læser produktoplysninger fra konsollen, opretter et nyt Product-objekt og tilføjer det til det angivne boardgame.
        internal static void UserInputAddNewProduct(BoardGame game)
        {
            // Indtast produkt ID
            int id;
            while (true)
            {
                Console.Write("Indtast produkt ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                Console.WriteLine("Ugyldigt input. Indtast et heltal for produkt ID.");
            }

            // Indtast produkt status
            Console.Write("Indtast produkt status: ");
            string status = Console.ReadLine() ?? "";

            // Indtast produkt pris
            double price;
            while (true)
            {
                Console.Write("Indtast produkt pris (f.eks. 49.99): ");
                if (double.TryParse(Console.ReadLine(), out price))
                    break;
                Console.WriteLine("Ugyldigt input. Indtast en gyldig pris.");
            }
            // Opret produkt og tilføj til boardgame'et
            Product newProduct = new Product(id, status, price);
            game.AddProduct(newProduct);
            Console.WriteLine("\nNyt produkt er tilføjet!");
        }
        //Ændring af boardgame detaljer
        public static void UpdateBoardGameDetails()
        {
            // Vælg boardgame
            BoardGame selectedGame = SelectBoardGame("opdatere");
            Console.WriteLine($"\nDu har valgt: {selectedGame.Name}\n");

            // Hent nye detaljer
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

            // Opdater boardgame
            selectedGame.UpdateDetails(newName, newEdition, newGenre, newMinPlayerCount, newMaxPlayerCount, newLanguage);

            // Udskriv opdateret boardgame
            Console.WriteLine("\nOpdateret BoardGame:");
            Console.WriteLine(selectedGame);
            Console.ReadLine();

        }  
      */
       
    }
    /*
    public class BoardGame
    {
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public string Language { get; set; }

        public List<Request> Requests { get; set; } = new List<Request>();

        public BoardGame(string name, string edition, string genre, int minPlayers, int maxPlayers, string language)
        {
            Name = name;
            Edition = edition;
            Genre = genre;
            MinPlayerCount = minPlayers;
            MaxPlayerCount = maxPlayers;
            Language = language;
        }

        public override string ToString() => $"{Name} ({Edition})";
    }
    */
    public class Employee
    {
        public string Name { get; set; }
        public Employee(string name, string email, int phone) => Name = name;
    }

}
