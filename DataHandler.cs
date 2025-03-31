using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class DataHandler
    {
        private string FilePath = "boardgames.txt";  // Filen gemmes i samme mappe som programmet

        public void SaveBoardGamesToFile(List<BoardGame> boardGames)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    foreach (var game in boardGames)
                    {
                        sw.WriteLine(game.ToFileString());

                        foreach (var product in game.Products)
                        {
                            sw.WriteLine(product.ToFileString());
                        }

                        foreach (var request in game.Requests)
                        {
                            sw.WriteLine(request.ToFileString());
                        }
                    }
                }
                Console.WriteLine("BoardGames gemt til boardgames.txt");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Fejl ved skrivning til filen: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("En ukendt fejl opstod under gemning: " + ex.Message);
            }
        }


        public List<BoardGame> LoadBoardGamesFromFile()
        {
            List<BoardGame> boardGames = new List<BoardGame>();

            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Ingen boardgames.txt fundet. Starter med en tom liste.");
                return boardGames;
            }

            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    BoardGame currentGame = null;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue; // Spring over tomme linjer

                        string[] parts = line.Split('|');
                        if (parts.Length == 0) continue;

                        try
                        {
                            switch (parts[0])
                            {
                                case "BoardGame":
                                    currentGame = BoardGame.FromString(line);
                                    boardGames.Add(currentGame);
                                    break;

                                case "Product":
                                    if (currentGame != null)
                                    {
                                        Product product = Product.FromString(line);
                                        currentGame.Products.Add(product);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Produkt fundet uden tilknyttet BoardGame: " + line);
                                    }
                                    break;

                                case "Request":
                                    if (currentGame != null)
                                    {
                                        Request request = Request.FromString(line);
                                        currentGame.Requests.Add(request);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Request fundet uden tilknyttet BoardGame: " + line);
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Ukendt datatypenavn: " + parts[0]);
                                    break;
                            }
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine("Fejl ved parsing af linje: " + line + " - " + fe.Message);
                        }
                    }
                }

                Console.WriteLine("BoardGames indlæst fra boardgames.txt");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Fejl ved læsning af filen: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("En ukendt fejl opstod under indlæsning: " + ex.Message);
            }

            return boardGames;
        }
    }
}