using System.Globalization;
using System.Text.RegularExpressions;

namespace C__Review_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string currentFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = currentFolder + Path.DirectorySeparatorChar + "videogames.csv";

            //decleration of the video game library using List
            List<VideoGame> gameLibrary = new List<VideoGame>();

            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Welcome to Lab 1: C# Review, programmed by Trevor \"Goose\" Rhudy\n");
            Console.WriteLine("-----------------------------------------\n\n");

            //Adds all values from the file into the list
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
              
                while (!reader.EndOfStream)
                {
                    string? linePulled = reader.ReadLine();

                    string[] lineInformation = linePulled.Split(',');

                    VideoGame vg = new VideoGame()
                    {
                        Name = lineInformation[0],
                        Platform = lineInformation[1],
                        Year = Int32.Parse(lineInformation[2]),
                        Genre = lineInformation[3],
                        Publisher = lineInformation[4],
                        NAsales = Double.Parse(lineInformation[5]),
                        EUSales = Double.Parse(lineInformation[6]),
                        JPSales = Double.Parse(lineInformation[7]),
                        OtherSales = Double.Parse(lineInformation[8]),
                        GlobalSales = Double.Parse(lineInformation[9])

                    };

                    gameLibrary.Add(vg);
                }

            } //end using statement

          
            gameLibrary.Sort();

            //Finds unique developers
            var uniquePublishers = gameLibrary.Select(x => x.Publisher).Distinct();

            Console.WriteLine("Which game developer would you like to view? Please input a number from 1 to 577.\n");
            int publisherCounter = 1;
            foreach (var publisher in uniquePublishers)
            {

                Console.WriteLine($"{publisherCounter}. {publisher}");
                publisherCounter++;
            }

            //checks the numerical input
            string publisherSelectionInString = null;
            int publisherSelectionInInt;
            bool validInput = false;

            while (!validInput)
            {
                if (int.TryParse(Console.ReadLine(), out publisherSelectionInInt) && publisherSelectionInInt >= 1 && publisherSelectionInInt <= uniquePublishers.Count())
                {
                    var uniquePublisherList = uniquePublishers.ToList();

                    publisherSelectionInString = uniquePublisherList[publisherSelectionInInt - 1];

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou Selected: {publisherSelectionInString}");
                    Console.ForegroundColor = ConsoleColor.White;

                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input! Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            //Display each unique genre for user input selection

            Console.WriteLine("Please select a genre from the list: \n");
            var uniqueGenres = gameLibrary.Select(x => x.Genre).Distinct();

            int genreCounter = 1;
            foreach (var genres in uniqueGenres) 
            { 
                Console.WriteLine($"{genreCounter}. {genres}"); 
                genreCounter++;
            }

            //validation check for user input on genre
            string genreSelectionInString = null;
            int genreSelectionInInt;
            bool validInput2 = false;

            while (!validInput2)
            {
                if (int.TryParse(Console.ReadLine(), out genreSelectionInInt) && genreSelectionInInt >= 1 && genreSelectionInInt <= uniqueGenres.Count())
                {
                    var uniqueGenreList = uniqueGenres.ToList();

                    genreSelectionInString = uniqueGenreList[genreSelectionInInt - 1];

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou Selected: {genreSelectionInString}\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    validInput2 = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input! Please enter a valid number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }



            //passing info into methods that displays genre choice and publisher games

            PublisherData(gameLibrary, publisherSelectionInString);

            GenreData(gameLibrary, genreSelectionInString, publisherSelectionInString);


            //Method to display all games and data from the publisher given
            static void PublisherData(List<VideoGame> gameLibrary,string publisherSelectionInString)
            {
                //Displaying all of the games availible from the selected publisher
                Console.WriteLine($"\nAll games listed from publisher of choice: {publisherSelectionInString}");
                var gamePublisher = gameLibrary.Where(vg => vg.Publisher == publisherSelectionInString);

                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var vg in gamePublisher)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(vg);
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n\n");

                float totalGameCount = gameLibrary.Count();

                float selectedPublisherGameCount = gamePublisher.Count();

                double selectedPublisherGamePercentage = (selectedPublisherGameCount / totalGameCount) * 100;

                Console.WriteLine($"\n{publisherSelectionInString} has developed {selectedPublisherGameCount} games out of {totalGameCount} games given, totalling to {selectedPublisherGamePercentage:0.##}% of the games developed.\n\n");
                Console.ForegroundColor = ConsoleColor.White;
            }


            // Genre display and statistics from inputed developer
            static void GenreData(List<VideoGame> gameLibrary, string genreSelectionInString, string publisherSelectionInString)
            {
                var selectedPublisherGames = gameLibrary.Where(vg => vg.Publisher == publisherSelectionInString).ToList();

                var genreList = selectedPublisherGames.Where(p => p.Genre == genreSelectionInString);

                double selectedPublisherGameCount = selectedPublisherGames.Count();

                double genreListCount = genreList.Count();

                var percentage = (genreListCount / selectedPublisherGameCount) * 100;

                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach(var vg in genreList)
                {
                    Console.WriteLine(vg);
                }

                Console.WriteLine($"\nThere are {genreListCount} {genreSelectionInString} genre games out of {selectedPublisherGameCount} from {publisherSelectionInString}, totalling to {percentage:0.##}% of their games.\n");

                Console.ForegroundColor = ConsoleColor.Black;
            }
            
        }
    }
}