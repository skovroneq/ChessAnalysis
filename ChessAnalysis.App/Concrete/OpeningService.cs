using ChessAnalysis.App.Common;
using ChessAnalysis.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnalysis.App.Concrete
{
    public class OpeningService : BaseService<Opening>
    {

        /*public int GameDetailSelectionView()
        {
            Console.WriteLine("Please enter ID for game you want to show in details:");
            var gameId = Console.ReadKey();
            int id;
            Int32.TryParse(gameId.KeyChar.ToString(), out id);

            return id;
        }

        public void GameDetailView(int detailId)
        {
            Game gameToShow = new Game();
            foreach (var game in Games)
            {
                if (game.Id == detailId)
                {
                    gameToShow = game;
                    break;
                }
            }

            Console.WriteLine($"Game ID: {gameToShow.Id}");
            Console.WriteLine($"Game name: {gameToShow.Name}");
            Console.WriteLine($"Game type ID: {gameToShow.TypeId}");
        }
        public int GameTypeSelectionView()
        {
            Console.WriteLine("Please enter type ID for game type you want to show:");
            var gameId = Console.ReadKey();
            int id;
            Int32.TryParse(gameId.KeyChar.ToString(), out id);

            return id;
        }

        public void GamesByTypeIdView(int typeId)
        {
            List<Game> gamesToShow = new List<Game>();

            foreach (var game in Games)
            {
                if (game.TypeId == typeId)
                {
                    gamesToShow.Add(game);
                }
            }

            for (int i = 0; i < gamesToShow.Count; i++)
            {
                Console.WriteLine($"\nID: {gamesToShow[i].Id}");
                Console.WriteLine($"Name: {gamesToShow[i].Name}");
            }
        }*/

    }
}

