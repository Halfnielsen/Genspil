using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Storage
    {
        List<BoardGame> BoardGameList = new List<BoardGame>();

        public Storage() 
        {
            
        }



        public void ShowBoardGameList()
        {
            Console.WriteLine("Brætspil:");
            Console.WriteLine(bg => Console.WriteLine(bg.Name));
        }


        public void ShowAvalaibleBoardGames()
        {
            foreach (BoardGame game in BoardGameList)
            {
                if (game.Count > 0)
                {
                    Console.WriteLine(game.Name);
                }
            }
        }

        public void AddBoardGame(BoardGame newBoardGame)
        {
            Console.WriteLine("Indtast navn:");
            string BoardGame.Name = Console.ReadLine(); 
            BoardGameList.Add(newBoardGame);
            Console.WriteLine($"{newBoardGame.Name} er nu tilføjet.");
        }

        public void Search()
        {

        }

        public void ShowProductList()
        {

        }
        
        public void PrintProductList()
        {

        }
    
    
    
    
    }

}
