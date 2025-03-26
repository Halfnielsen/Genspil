using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;

namespace Genspil
{
    internal class Program
    {
        // Deklarér boardGames
        private static List<BoardGame> boardGames;

        public static void Main(string[] args)
        {
<<<<<<< HEAD
            
=======
            boardGames = new List<BoardGame>
            {
                new BoardGame("Catan", "Standard", "Strategy", 3, 4, "English"),
                new BoardGame("Ticket to Ride", "Deluxe", "Family", 2, 5, "English")
            };

            // Tilføj nogle produkter til hvert boardgame
            boardGames[0].AddProduct(new Product(1, "God", 75));
            boardGames[0].AddProduct(new Product(2, "Okay", 40));
            boardGames[1].AddProduct(new Product(3, "God", 75));
            boardGames[1].AddProduct(new Product(4, "God", 75));

            
            // Kør metoden AddNewProduct (brugeren bliver bedt om at vælge boardgame etc.)
            AddNewProduct();

            // Kør metoden UpdateBoardGameDetails (brugeren bliver bedt om at vælge boardgame etc.)
            UpdateBoardGameDetails();
        }


        //Metode til valg af boardgame
        public static BoardGame SelectBoardGame(string action)
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
        public static void UserInputAddNewProduct(BoardGame game)
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
>>>>>>> main
        }
    }
}

