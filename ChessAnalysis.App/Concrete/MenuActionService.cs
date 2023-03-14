using ChessAnalysis.App.Common;
using ChessAnalysis.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnalysis.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();

            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Enter the games base", "Main"));
            AddItem(new MenuAction(2, "Enter the openings base", "Main"));
            AddItem(new MenuAction(3, "Exit", "Main"));

            AddItem(new MenuAction(1, "Add game", "GamesMenu"));
            AddItem(new MenuAction(2, "Remove game", "GamesMenu"));
            AddItem(new MenuAction(3, "Show details", "GamesMenu"));
            AddItem(new MenuAction(4, "List of games", "GamesMenu"));
            AddItem(new MenuAction(5, "Exit to main menu", "GamesMenu"));
            AddItem(new MenuAction(6, "Exit", "GamesMenu"));

            AddItem(new MenuAction(1, "Add opening", "OpeningsMenu"));
            AddItem(new MenuAction(2, "Remove opening", "OpeningsMenu"));
            AddItem(new MenuAction(3, "Show details", "OpeningsMenu"));
            AddItem(new MenuAction(4, "List of openings", "OpeningsMenu"));
            AddItem(new MenuAction(5, "Exit to main menu", "OpeningsMenu"));
            AddItem(new MenuAction(6, "Exit", "OpeningsMenu"));

            AddItem(new MenuAction(1, "Playing white pieces", "AddNewGameMenu"));
            AddItem(new MenuAction(2, "Playing black pieces", "AddNewGameMenu"));

            AddItem(new MenuAction(1, "D4", "AddNewOpeningMenu"));
            AddItem(new MenuAction(2, "E4", "AddNewOpeningMenu"));
            AddItem(new MenuAction(3, "Other", "AddNewOpeningMenu"));

        }

    }
}
