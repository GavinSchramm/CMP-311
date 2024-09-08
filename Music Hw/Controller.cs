using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    class Controller
    {
        public Controller()
        {
            Model model = new Model();
            View view = new View();

            bool endApp = false;

            view.PrintLine("Welcome to Music application"); // welcome the user

            while (!endApp)
            {
                string title; // to get song title info
                string artist; // to get artist info
                string special; // special because it will either store
                // the year or the orgin

                view.PrintLine("\nWhat would you like to do?"); // ask the user what to do
                view.PrintLine("1: Add pop song"); // option 1
                view.PrintLine("2: Add musical song"); // option 2
                view.PrintLine("3: Print list out"); // option 3
                view.PrintLine("4: End app"); // option 4
                view.PrintLine("Type '1', '2', '3', or '4'"); // tells the user the valid options
                string userInput = view.GetInput(); // get the input from user

                if (userInput == "1") // add pop to list
                {
                    view.PrintLine("\nWrite the song title"); // ask for song title
                    title = view.GetInput(); // get input
                    while (title == "") // check if the title is an empty string
                    {
                        view.PrintLine("Please input valid song title! "); // if is empty, tell them that not allowed
                        title = view.GetInput(); // ask for another input
                    }

                    view.PrintLine("\nWrite the artist of the song"); // ask for artist
                    artist = view.GetInput(); // get input
                    while (artist == "") // check if the artist is an empty string
                    {
                        view.PrintLine("Please input valid artist! "); // if is empty, tell them that not allowed
                        artist = view.GetInput(); // ask for another input
                    }

                    view.PrintLine("\nWrite the year the song came out"); // ask for the year
                    special = view.GetInput(); // gets input

                    model.AddPop(title, artist, special); // add the user inputs to the list
                }
                else if (userInput == "2") // add musical to list
                {
                    view.PrintLine("\nWrite the song title"); // ask for song title
                    title = view.GetInput(); // get input
                    while (title == "") // check if the title is an empty string
                    {
                        view.PrintLine("Please input valid song title! "); // if is empty, tell them that not allowed
                        title = view.GetInput(); // ask for another input
                    }

                    view.PrintLine("\nWrite the artist of the song"); // ask for artist
                    artist = view.GetInput(); // get input
                    while (artist == "") // check if the artist is an empty string
                    {
                        view.PrintLine("Please input valid artist! "); // if is empty, tell them that not allowed
                        artist = view.GetInput(); // ask for another input
                    }

                    view.PrintLine("\nWhich musical is your song from?"); // ask for the musical
                    special = view.GetInput(); // gets input

                    model.AddMusical(title, artist, special); // add the user inputs to the list
                }
                else if (userInput == "3") // to sort list
                {
                    view.PrintLine("\nHow would you like to sort it by?");
                    view.PrintLine("1: by order it was added");
                    view.PrintLine("2: by song title");
                    view.PrintLine("3: by artist");
                    view.PrintLine("Please print '1', '2', '3', or press any thing else to cancel the print.");
                    userInput = view.GetInput();

                    if (userInput == "1") // no sort, print as added
                    {
                        view.PrintLine("\nYour List is:");
                        foreach (Music music in model.SortList("Order", model.ReturnList()))
                        {
                            view.PrintLine(music.ToString());
                        }
                        view.PrintLine("\nEnd of List");
                    }
                    else if (userInput == "2") // sort by title
                    {
                        view.PrintLine("\nYour List is:");
                        foreach (Music music in model.SortList("Title", model.ReturnList()))
                        {
                            view.PrintLine(music.ToString());
                        }
                        view.PrintLine("\nEnd of List");
                    }
                    else if (userInput == "3") // sort by artist
                    {
                        view.PrintLine("\nYour List is:");
                        foreach (Music music in model.SortList("Artist", model.ReturnList()))
                        {
                            view.PrintLine(music.ToString());
                        }
                        view.PrintLine("\nEnd of List");
                    } 

                }
                else if (userInput == "4")
                {
                    endApp = true;
                }
                else
                {
                    view.PrintLine("\nUh oh! That's not a valid input. Please be more responsible next time... ok?");
                }
            }
        }
    }
}
