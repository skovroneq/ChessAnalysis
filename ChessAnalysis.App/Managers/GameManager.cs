using ChessAnalysis.App.Concrete;
using ChessAnalysis.Domain.Entity;
using ChessAnalysis.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessAnalysis.App.Managers
{
    public class GameManager
    {
        private readonly MenuActionService _actionService;
        private GameService _gameService;
        public GameManager(MenuActionService actionService)
        {
            _gameService = new GameService();
            _actionService = actionService;
        }

        public int AddNewGame()
        {
            var addNewGameMenu = _actionService.GetMenuActionsByMenuName("AddNewGameMenu");

            Console.WriteLine("\nPlease select game type:");

            for (int i = 0; i < addNewGameMenu.Count; i++)
            {
                Console.WriteLine($"{addNewGameMenu[i].Id}. {addNewGameMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            int typeId;

            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            var lastId = _gameService.GetLastId();

            Console.WriteLine("\n\nPlease enter name for new game:");

            var name = Console.ReadLine();

            Game game = new Game(lastId + 1, name, typeId);

            Console.WriteLine("\nPlease enter result of the game (0 - Loss, 1 - Win, 2 - Draw): ");

            Enum.TryParse(Console.ReadLine(), out PossibleResult result);
            string gameResult = result.ToString();
            game.Result = gameResult;

            Console.WriteLine("\nPlease enter the name of opening used in a game:");

            var openingName = Console.ReadLine();
            game.Opening = openingName;

            Console.WriteLine("\nPlease enter the date of the game:");

            DateTime.TryParse(Console.ReadLine(), out var gameDate);
            game.Date = gameDate;

            _gameService.AddItem(game);

            return game.Id;
        }

        public void RemoveGame()
        {
            Console.WriteLine("\nPlease enter ID for game you want to delete: ");

            int gameId;
            int.TryParse(Console.ReadLine(), out gameId);

            var game = _gameService.Items.FirstOrDefault(p => p.Id == gameId);

            if (game != null)
            {
                _gameService.RemoveItem(game);
            }
            else
            {
                Console.WriteLine($"Game with ID = {gameId} doesn't exist.");
            }
        }

        public void GameDetailView()
        {
            Console.WriteLine("\nInsert the ID of game you want to show in details: ");

            int detailId;

            int.TryParse(Console.ReadLine(), out detailId);

            Game gameToShow = new Game(detailId, "", 0);

            foreach (var item in _gameService.Items)
            {
                if (item.Id == detailId)
                {
                    gameToShow = item;
                    break;
                }

            }

            if (gameToShow.TypeId == 0)
            {
                Console.WriteLine($"Game with ID = {detailId} doesn't exist.");
            }
            else
            {
                Console.WriteLine($"\nGame id: {gameToShow.Id}");
                Console.WriteLine($"Game name: {gameToShow.Name}");
                Console.WriteLine($"Date: {gameToShow.Date}");
                Console.WriteLine($"Result: {gameToShow.Result}");
                Console.WriteLine($"Opening: {gameToShow.Opening}");
                Console.WriteLine($"Game type id: {gameToShow.TypeId}");
            }

        }

        public void GamesByTypeIdView()
        {
            Console.WriteLine("\nPlease enter Type ID for game type you want to show:");
            var gameId = Console.ReadKey();
            int typeId;
            Int32.TryParse(gameId.KeyChar.ToString(), out typeId);

            List<Game> gamesToShow = new List<Game>();
            foreach (var game in _gameService.Items)
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
        }
    }
}
