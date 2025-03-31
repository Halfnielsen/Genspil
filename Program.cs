using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;

namespace Genspil
{
    internal class Program
    {
       

        public static void Main(string[] args)
        {
            DataHandler dataHandler = new DataHandler();
            List<BoardGame> boardGames = dataHandler.LoadBoardGamesFromFile();


            Storage storage = new Storage(boardGames); 

            try
            {
                Menu.MainMenu(storage); 
            }
            finally
            {
                dataHandler.SaveBoardGamesToFile(storage.GetBoardGames()); 

            }
        }


        
       



        

        



       
    }
}

