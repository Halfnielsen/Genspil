using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Storage
    {
        List<string> BoardGameList = new List<string>();

        public Storage() 
        {
            BoardGameList.Add("Sequence");
            BoardGameList.Add("Ticket to Ride");
            BoardGameList.Add("7 Wonders");
            BoardGameList.Add("Alverdens");
            BoardGameList.Add("A la carte: Dessert");
            BoardGameList.Add("Bad People");
        }



        public void ShowBoardGameList()
        {
            Console.WriteLine($"Brætspil:");
            BoardGameList.ForEach(Console.WriteLine);
        }


        public void ShowAvalaibleBoardGames()
        {
            
        }


    }
}
