using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Storage
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

        public void AddBoardGame()
        {
            BoardGame newBoardGame = new BoardGame;
            BoardGameList.Add(newBoardgame);
            Console.WriteLine("Indtast navn:");
            string inputName = Console.ReadLine();
            Console.WriteLine("Indtast udgave:");
            string inputEdition = Console.ReadLine();
            Console.WriteLine("Indtast minimum antal spillere:");
            string inputMinPlayerCount = Console.ReadLine();
            Console.WriteLine("Indtast maximum antal spillere:");
            string inputMaxPlayerCount = Console.ReadLine();
            Console.WriteLine("Indtast sprog:");
            string inputLanguage = Console.ReadLine();

            newBoardGame.Name = inputName;
            newBoardGame.Edition = inputEdition;
            newBoardGame.MinPlayerCount = inputMinPlayerCount;
            newBoardGame.MaxPlayerCount = inputMaxPlayerCount;
            newBoardGame.Language = inputLanguage;

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
