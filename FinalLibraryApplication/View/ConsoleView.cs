using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLibraryApplication;


namespace FinalLibraryApplication
{
    public static class ConsoleView
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPALY_VERITCAL_MARGIN = ViewSettings.DISPLAY_VERITCAL_MARGIN;

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        public static AppEnum.LibraryManager GetUserActionChoice()
        {
            AppEnum.LibraryManager userActionChoice = AppEnum.LibraryManager.None;

            string leftTab = ConsoleUtilCenter.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtilCenter.Center("Library Application Manager Menu", WINDOW_WIDTH));
            DisplayMessage("");

            Console.WriteLine(
                leftTab + "1. List All the Books" + Environment.NewLine +
                leftTab + "2. Display the Books Detail" + Environment.NewLine +
                leftTab + "3. Add a Book" + Environment.NewLine +
                leftTab + "4. Delete a Book" + Environment.NewLine +
                leftTab + "5. Updated a Book" + Environment.NewLine +
                leftTab + "Q. Quite" + Environment.NewLine);

            DisplayMessage("");
            DisplayPromptMessage("Enter the number/letter from the menu choice: ");
            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case '1':
                    userActionChoice = AppEnum.LibraryManager.ListAllTheBooks;
                    break;
                case '2':
                    userActionChoice = AppEnum.LibraryManager.DisplayLibraryDetails;
                    break;
                case '3':
                    userActionChoice = AppEnum.LibraryManager.AddABook;
                    break;
                case '4':
                    userActionChoice = AppEnum.LibraryManager.RemoveABook;
                    break;
                case '5':
                    userActionChoice = AppEnum.LibraryManager.UpatedABook;
                    break;
                case 'Q':
                case 'q':
                    userActionChoice = AppEnum.LibraryManager.Quit;
                    break;
                default:
                    DisplayMessage("");
                    DisplayMessage("");
                    DisplayMessage("It appears that you have selected the incorrect choice in the Library Application Menu.");
                    DisplayMessage("");
                    DisplayMessage("Please be sure to press any key to try again or the ESC key to exit.");

                    userResponse = Console.ReadKey(true);
                    if (userResponse.Key == ConsoleKey.Escape)
                    {
                        userActionChoice = AppEnum.LibraryManager.Quit;
                    }
                    break;
            }
            return userActionChoice;
        }

        public static void DisplayAllTheBooks(List<Library> librarys)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtilCenter.Center("Display All Librarys", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the existing librarys are displayed below;");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("BookTitle".PadRight(35));
            columnHeader.Append("Author".PadRight(35));
            columnHeader.Append("Genre".PadRight(25));
            columnHeader.Append("Series".PadRight(25));
            columnHeader.Append("ISBN".PadRight(30));

            DisplayMessage(columnHeader.ToString());

            foreach (Library library in librarys)
            {
                StringBuilder libraryInfo = new StringBuilder();

                libraryInfo.Append(library.ID.ToString().PadRight(8));
                libraryInfo.Append(library.BookTitle.PadRight(35));
                libraryInfo.Append(library.Author.PadRight(35));
                libraryInfo.Append(library.Genre.PadRight(25));
                libraryInfo.Append(library.Series.PadRight(25));
                libraryInfo.Append(library.ISBN.ToString().PadRight(30));

                DisplayMessage(libraryInfo.ToString());
            }
        }

        public static void DisplayLibraryDetail(Library library)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtilCenter.Center("Library Details", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("BookTitle: {0}", library.BookTitle));
            DisplayMessage("");

            DisplayMessage(String.Format("Author: {0}", library.Author));
            DisplayMessage("");

            DisplayMessage(String.Format("Genre: {0}", library.Genre));
            DisplayMessage("");

            DisplayMessage(String.Format("Series: {0}", library.Series));
            DisplayMessage("");

            DisplayMessage(String.Format("ISBN: {0}", library.ISBN));
            DisplayMessage("");

            DisplayMessage(String.Format("ID: {0}", library.ID.ToString()));

            DisplayMessage("");
        }

        public static Library AddABookTitle()
        {
            Library library = new Library();

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtilCenter.Center("Add A BookTitle", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the library ID: ");
            library.ID = ConsoleUtilCenter.ValidateIntegerResponse("Please enter the library ID: ", Console.ReadLine());
            DisplayMessage("");

            DisplayPromptMessage("Enter the BookTitle: ");
            library.BookTitle = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the Author: ");
            library.Author = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the Genre: ");
            library.Genre = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the Series: ");
            library.Series = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter the book ISBN: ");
            library.ISBN = Console.ReadLine();
            DisplayMessage("");

            return library;
        }

        public static Library UpdateABookTitle(Library library)
        {
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtilCenter.Center("Edit any BookTitle that you like", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Current BookTitle: {0}", library.BookTitle));
            DisplayPromptMessage("Enter a new BookTitle or just press Enter to keep the current BookTitle: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                library.BookTitle = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current Author: {0}", library.Author));
            DisplayPromptMessage("Enter a new Author or just press Enter to keep the current Author: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                library.Author = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current Genre: {0}", library.Genre));
            DisplayPromptMessage("Enter a new Genre or just press Enter to keep the current Genre: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                library.Genre = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current Series: {0}", library.Series));
            DisplayPromptMessage("Enter a new series or just press Enter to keep the current series: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                library.Series = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current ISBN: {0}", library.ISBN.ToString()));
            DisplayPromptMessage("Enter a new ISBN or just press Enter to keep the current ISBN: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                library.ISBN = userResponse;
            }

            DisplayMessage("");

            DisplayContinuePrompt();

            return library;
        }

        public static int GetLibraryID(List<Library> librarys)
        {
            int libraryID = -1;

            DisplayAllTheBooks(librarys);

            DisplayMessage("");
            DisplayPromptMessage("Enter the library ID: ");

            libraryID = ConsoleUtilCenter.ValidateIntegerResponse("Please enter the library ID: ", Console.ReadLine());

            return libraryID;
        }

        public static void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtilCenter.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtilCenter.Center("Library Application", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtilCenter.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void DisplayMessage(string message)
        {

            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            if (message != "")
            {
                List<string> messageLines;
                messageLines = ConsoleUtilCenter.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            else
            {
                Console.WriteLine();
            }
        }

        public static void DisplayPromptMessage(string message)
        {
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            List<string> messageLines;
            messageLines = ConsoleUtilCenter.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }

        public static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.WriteLine(ConsoleUtilCenter.Center("Please press any key to continue.", WINDOW_WIDTH));
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        public static void DisplayExitPrompt()
        {
            DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for using our Library Application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        public static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtilCenter.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtilCenter.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtilCenter.Center("The Library Application", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtilCenter.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        #endregion

    }
}