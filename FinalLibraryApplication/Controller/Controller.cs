using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLibraryApplication
{
    public class Controller
    {
        #region ENUMERABLES
        #endregion

        #region FIELDS

        bool active = true;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            ApplicationControl();
        }
        #endregion

        #region METHODS

        private void ApplicationControl()
        {
            AppEnum.LibraryManager userActionChoice;

            ConsoleView.DisplayWelcomeScreen();

            while (active)
            {
                userActionChoice = ConsoleView.GetUserActionChoice();

                switch (userActionChoice)
                {
                    case AppEnum.LibraryManager.None:
                        break;
                    case AppEnum.LibraryManager.ListAllTheBooks:
                        ListAllTheBooks();
                        break;
                    case AppEnum.LibraryManager.DisplayLibraryDetail:
                        DisplayLibraryDetails();
                        break;
                    case AppEnum.LibraryManager.RemoveABook:
                        RemoveABook();
                        break;
                    case AppEnum.LibraryManager.AddABook:
                        AddABook();
                        break;
                    case AppEnum.LibraryManager.UpatedABook:
                        UpdatedABook();
                        break;
                    case AppEnum.LibraryManager.Quit:
                        active = false;
                        break;
                    default:
                        break;
                }
            }
            ConsoleView.DisplayExitPrompt();
        }

        private static void ListAllTheBooks()
        {
            FinalLibraryRepositorySQL libraryRepository = new FinalLibraryRepositorySQL();
            List<Library> librarys;

            using (libraryRepository)
            {
                librarys = libraryRepository.SelectAll();
                ConsoleView.DisplayAllTheBooks(librarys);
                ConsoleView.DisplayContinuePrompt();
            }
        }

        private static void DisplayLibraryDetails()
        {
            FinalLibraryRepositorySQL libraryRepository = new FinalLibraryRepositorySQL();
            List<Library> librarys;
            Library library = new Library();
            int libraryID;

            using (libraryRepository)
            {
                librarys = libraryRepository.SelectAll();
                libraryID = ConsoleView.GetLibraryID(librarys);
                library = libraryRepository.SelectById(libraryID);
            }

            ConsoleView.DisplayLibraryDetail(library);
            ConsoleView.DisplayContinuePrompt();
        }

        private static void AddABook()
        {
            FinalLibraryRepositorySQL libraryRepository = new FinalLibraryRepositorySQL();
            Library library = new Library();

            library = ConsoleView.AddABookTitle();
            using (libraryRepository)
            {
                libraryRepository.Insert(library);
            }

            ConsoleView.DisplayContinuePrompt();
        }

        private static void UpdatedABook()
        {
            FinalLibraryRepositorySQL libraryRepository = new FinalLibraryRepositorySQL();
            List<Library> librarys = libraryRepository.SelectAll();
            Library library = new Library();
            int libraryID;

            using (libraryRepository)
            {
                librarys = libraryRepository.SelectAll();
                libraryID = ConsoleView.GetLibraryID(librarys);
                library = libraryRepository.SelectById(libraryID);
                library = ConsoleView.UpdateABookTitle(library);
                libraryRepository.Update(library);
            }
        }

        private static void RemoveABook()
        {
            FinalLibraryRepositorySQL libraryRepository = new FinalLibraryRepositorySQL();
            List<Library> librarys = libraryRepository.SelectAll();
            Library library = new Library();
            int libraryID;
            string message;

            libraryID = ConsoleView.GetLibraryID(librarys);

            using (libraryRepository)
            {
                libraryRepository.Delete(libraryID);
            }

            ConsoleView.DisplayReset();

            message = String.Format("Library ID: {0} had been deleted.", libraryID);

            ConsoleView.DisplayMessage(message);
            ConsoleView.DisplayContinuePrompt();
        }

        #endregion


    }
}
