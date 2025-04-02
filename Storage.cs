using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Storage
    {
       List<BoardGame> BoardGames;

        public Storage(List<BoardGame> boardGames)
        {
            this.BoardGames = boardGames;
        }

        public void AddBoardGame(BoardGame boardGame)
        {
            if (BoardGames.Exists(b => b.Name.ToLower() == boardGame.Name.ToLower()))
            {
                Console.WriteLine($"Brætspillet {boardGame.Name} eksisterer allerede.");
                return;
            }
            BoardGames.Add(boardGame);
            Console.WriteLine($"Brætspillet: {boardGame.Name} er tilføjet. ");
        }
        /*
        public void ShowBoardGameList()
        {
            if (BoardGames.Count == 0)
            {
                Console.WriteLine("Ingen brætspil tilgængelige. ");
                return;
            }
            foreach (BoardGame boardGame in BoardGames)
            {
                Console.WriteLine(boardGame.Name);
            }
        }
        
        public void ShowProductList()
        {
            if (BoardGames.Count == 0)
            {
                Console.WriteLine("Ingen brætspil tilgængelige. ");
                return;
            }
            Console.WriteLine("Brætspil og dets produkter: ");
            foreach (BoardGame boardGame in BoardGames)
            {
                Console.WriteLine($"Brætspil: {boardGame.Name}");
                foreach (var product in boardGame.Products)
                {
                    Console.WriteLine($"Produkt ID: {product.getId()}, Status: {product.getStatus()}, Pris: {product.getPrice()} kr., Stand: {product.getStand()}");
                }
            }


        }

        public void PrintProductList()
        {
            Console.WriteLine("Alle produkter:");
            foreach (BoardGame boardGame in BoardGames)
            {
                foreach (var product in boardGame.Products)
                {
                    Console.WriteLine($"Brætspil: {boardGame.Name}, Produkt ID: {product.getId()}, Status: {product.getStatus()}, Pris: {product.getPrice()} kr., Stand: {product.getStand()}");
                }
            }
        }
        //Skal nok fjernes
        public void ShowAvalaibleBoardGames()
        {
            Console.WriteLine("Tilgængelige brætspil:");
            foreach (BoardGame boardGame in BoardGames)
            {
                if (boardGame.Products.Exists(p => p.getStatus() == "på lager"))
                    Console.WriteLine(boardGame.Name);
            }
        }
        */
        public List<BoardGame> GetBoardGames()
        {
            return BoardGames;
        }

        
    }
}