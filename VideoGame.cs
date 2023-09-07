using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Review_Lab1
{
    public class VideoGame: IComparable<VideoGame> 
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NAsales { get; set; }
        public double EUSales { get; set; }
        public double JPSales { get; set; }
        public double OtherSales { get; set;}
        public double GlobalSales { get; set; }

        //Default empty constructor
        public VideoGame() { }
 
        //Class constructor w/ values
        public VideoGame(string name, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NAsales = naSales;
            EUSales = euSales;
            JPSales = jpSales;
            OtherSales = otherSales;
            GlobalSales = globalSales;
        }

        //sort the names of video games from a-z       
        public int CompareTo(VideoGame? other)
        {
            return Name.CompareTo(other.Name);
        }


        //Formats all the data into a string
        public override string ToString()
        {
            string VideoGameDisplay = "";
            VideoGameDisplay += $"Game Title: {Name}\n";
            VideoGameDisplay += $"Platform: {Platform}\n";
            VideoGameDisplay += $"Year: {Year}\n";
            VideoGameDisplay += $"Publisher: {Publisher}\n";
            VideoGameDisplay += $"NA Sales: {NAsales} \n";
            VideoGameDisplay += $"EU Sales: {EUSales} \n";
            VideoGameDisplay += $"JP Sales: {JPSales} \n";
            VideoGameDisplay += $"Other Sales: {OtherSales} \n";
            VideoGameDisplay += $"Global Sales: {GlobalSales} \n";

            return VideoGameDisplay;
        }

    }

}
