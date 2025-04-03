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
            if (BoardGames.Exists(b =>
                b.Name.Equals(boardGame.Name, StringComparison.OrdinalIgnoreCase) &&
                b.Edition.Equals(boardGame.Edition, StringComparison.OrdinalIgnoreCase) &&
                b.Language.Equals(boardGame.Language, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Brætspillet {boardGame.Name} ({boardGame.Edition}, {boardGame.Language}) eksisterer allerede.");
                return;
            }

            BoardGames.Add(boardGame);
            Console.WriteLine($"Brætspillet: {boardGame.Name} ({boardGame.Edition}, {boardGame.Language}) er tilføjet.");
        }
        
        public List<BoardGame> GetBoardGames()
        {
            return BoardGames;
        }

        public List<BoardGame> GetBoardGamesSortedByName()
        {
            return BoardGames.OrderBy(b => b.Name, StringComparer.OrdinalIgnoreCase).ToList();
        }

        public List<BoardGame> GetBoardGamesSortedByGenre()
        {
            return BoardGames.OrderBy(b => b.Genre, StringComparer.OrdinalIgnoreCase).ToList();
        }

        public bool RemoveBoardGame(BoardGame boardGame)
        {
            if (BoardGames.Contains(boardGame))
            {
                BoardGames.Remove(boardGame);
                return true;
            }
            return false;
        }


    }
}