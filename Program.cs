using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;

namespace Genspil
{
    internal class Program
    {
       // Deklarér boardGames som et statisk felt
        private static List<BoardGame> boardGames;

        public static void Main(string[] args)
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


            
        }


        
       



        

        



       
    }
}

