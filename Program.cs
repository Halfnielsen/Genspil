using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;

namespace Genspil
{
    internal class Program
    {
       // Deklarér boardGames som et statisk felt
        //private static List<BoardGame> boardGames;

        public static void Main(string[] args)
        {
            DataHandler dataHandler = new DataHandler();
            List<BoardGame> boardGames = dataHandler.LoadBoardGamesFromFile();

            try
            {
                Menu.MainMenu();
            }
            finally
            {
                dataHandler.SaveBoardGamesToFile(boardGames);
            }
        }


        
       



        

        



       
    }
}

