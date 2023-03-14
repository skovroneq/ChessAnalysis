using ChessAnalysis.App.Concrete;
using ChessAnalysis.App.Managers;
using System;

namespace ChessAnalysis
{
    public class Program
    {
        static void Main(string[] args)
        {

            MenuActionService actionService = new MenuActionService();
            GameManager gameManager = new GameManager(actionService);
            OpeningManager openingManager = new OpeningManager(actionService);
            bool shouldContinue = true;

            Console.WriteLine("Welcome to chess analysis app ;)");
            while (shouldContinue)
            {
                bool gamesMenuContinue = true;
                bool openingsMenuContinue = true;
                Console.WriteLine("Type a proper number to execute one of below actions:");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        while (gamesMenuContinue)
                        {
                            var gamesMenu = actionService.GetMenuActionsByMenuName("GamesMenu");
                            Console.WriteLine("");

                            for (int i = 0; i < gamesMenu.Count; i++)
                            {
                                Console.WriteLine($"{gamesMenu[i].Id}. {gamesMenu[i].Name}");
                            }

                            var gamesOperation = Console.ReadKey();
                            Console.WriteLine("");

                            switch (gamesOperation.KeyChar)
                            {
                                case '1':
                                    var newId = gameManager.AddNewGame();
                                    break;
                                case '2':
                                    gameManager.RemoveGame();
                                    break;
                                case '3':
                                    gameManager.GameDetailView();
                                    break;
                                case '4':
                                    gameManager.GamesByTypeIdView();
                                    break;
                                case '5':
                                    gamesMenuContinue = false;
                                    break;
                                case '6':
                                    gamesMenuContinue = false;
                                    shouldContinue = false;
                                    break;
                                default:
                                    Console.WriteLine("Action you entered does not exist");
                                    break;
                            }
                        }
                        break;
                    case '2':
                        while (openingsMenuContinue)
                        {
                            var openingsMenu = actionService.GetMenuActionsByMenuName("OpeningsMenu");
                            Console.WriteLine("");

                            for (int i = 0; i < openingsMenu.Count; i++)
                            {
                                Console.WriteLine($"{openingsMenu[i].Id}. {openingsMenu[i].Name}");
                            }

                            var openingsOperation = Console.ReadKey();
                            Console.WriteLine("");

                            switch (openingsOperation.KeyChar)
                            {
                                case '1':
                                    var newId = openingManager.AddNewOpening();
                                    break;
                                case '2':
                                    openingManager.RemoveOpening();
                                    break;
                                case '3':
                                    openingManager.OpeningDetailView();
                                    break;
                                case '4':
                                    openingManager.OpeningsByTypeIdView();
                                    break;
                                case '5':
                                    openingsMenuContinue = false;
                                    break;
                                case '6':
                                    openingsMenuContinue = false;
                                    shouldContinue = false;
                                    break;
                                default:
                                    Console.WriteLine("Action you entered does not exist");
                                    break;
                            }
                        }
                        break;
                    case '3':
                        shouldContinue = false;
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }

                
            }

        }
    }
}
