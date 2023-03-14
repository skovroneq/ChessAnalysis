using ChessAnalysis.App.Concrete;
using ChessAnalysis.Domain.Entity;
using ChessAnalysis.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnalysis.App.Managers
{
    public class OpeningManager
    {
        private readonly MenuActionService _actionService;
        private OpeningService _openingService;
        public OpeningManager(MenuActionService actionService)
        {
            _openingService = new OpeningService();
            _actionService = actionService;
        }
        public int AddNewOpening()
        {
            var addNewOpeningMenu = _actionService.GetMenuActionsByMenuName("AddNewOpeningMenu");

            Console.WriteLine("\nPlease select opening type:");

            for (int i = 0; i < addNewOpeningMenu.Count; i++)
            {
                Console.WriteLine($"{addNewOpeningMenu[i].Id}. {addNewOpeningMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            int typeId;

            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            var lastId = _openingService.GetLastId();

            Console.WriteLine("\n\nPlease enter the name for new opening:");

            var name = Console.ReadLine();

            Opening opening = new Opening(lastId + 1, name, typeId);

            Console.WriteLine("\n\nPlease enter description for new opening:");

            var description = Console.ReadLine();
            opening.Description = description;

            _openingService.AddItem(opening);

            return opening.Id;
        }

        public void RemoveOpening()
        {
            Console.WriteLine("\nPlease enter ID for opening you want to delete: ");

            int openingId;
            int.TryParse(Console.ReadLine(), out openingId);

            var opening = _openingService.Items.FirstOrDefault(p => p.Id == openingId);

            if (opening != null)
            {
                _openingService.RemoveItem(opening);
            }
            else
            {
                Console.WriteLine($"Game with ID = {openingId} doesn't exist.");
            }
        }

        public void OpeningDetailView()
        {
            Console.WriteLine("\nInsert the ID of opening you want to show in details: ");

            int detailId;

            int.TryParse(Console.ReadLine(), out detailId);

            Opening openingToShow = new Opening(detailId, "", 0);

            foreach (var item in _openingService.Items)
            {
                if (item.Id == detailId)
                {
                    openingToShow = item;
                    break;
                }

            }

            if (openingToShow.TypeId == 0)
            {
                Console.WriteLine($"Opening with ID = {detailId} doesn't exist.");
            }
            else
            {
                Console.WriteLine($"\nOpening id: {openingToShow.Id}");
                Console.WriteLine($"Name: {openingToShow.Name}");
                Console.WriteLine($"Description: {openingToShow.Description}");
            }

        }

        public void OpeningsByTypeIdView()
        {
            Console.WriteLine("\nPlease enter Type ID for opening type you want to show:");
            var openingId = Console.ReadKey();
            int typeId;
            Int32.TryParse(openingId.KeyChar.ToString(), out typeId);

            List<Opening> openingsToShow = new List<Opening>();
            foreach (var opening in _openingService.Items)
            {
                if (opening.TypeId == typeId)
                {
                    openingsToShow.Add(opening);
                }
            }

            for (int i = 0; i < openingsToShow.Count; i++)
            {
                Console.WriteLine($"\nID: {openingsToShow[i].Id}");
                Console.WriteLine($"Name: {openingsToShow[i].Name}");
            }
        }
    }
}

