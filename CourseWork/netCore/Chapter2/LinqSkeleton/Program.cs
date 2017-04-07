using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            System.Console.WriteLine("");
            System.Console.WriteLine("There is only one artist in this collection from Mount Vernon, what is their name and age?");

            var foundArtistInMtVernon = from artist in Artists
                                        where artist.Hometown == "Mount Vernon"
                                        select new {artist.RealName, artist.Age};

            foreach(var i in foundArtistInMtVernon)
            {
                System.Console.WriteLine(i);
            }
            

            // IEnumerable<Artist> foundArtistInMtVernonList = Artists.Where(str => str.Hometown == "Mount Vernon");

            // foreach(var i in foundArtistInMtVernonList)
            // {
            //     System.Console.WriteLine(i.RealName + " " + i.Age);
            // }

            //Who is the youngest artist in our collection of artists?
            // var foundYoungestArtist = from artist in Artists
            //                           orderby artist.Age
            //                           select new {artist.RealName, artist.Age};
            
            // System.Console.WriteLine(foundYoungestArtist.First().RealName + " " + foundYoungestArtist.First().Age);


            System.Console.WriteLine("");
            System.Console.WriteLine("Who is the youngest artist in our collection of artists?");
            var foundYoungestArtistList = Artists.OrderBy(x => x.Age).First();

            System.Console.WriteLine(foundYoungestArtistList.RealName + " " + foundYoungestArtistList.Age);

            //Display all artists with 'William' somewhere in their real name
            System.Console.WriteLine("");
            System.Console.WriteLine("Display all artists with 'William' somewhere in their real name");
            var foundArtistWilliam = from artist in Artists
                                     where artist.RealName.Contains("William")
                                     select artist;
                                     //select new {artist.RealName, artist.ArtistName, artist.Age};
            
                            
            foreach(var i in foundArtistWilliam)
            {
                System.Console.WriteLine(i.ArtistName);
            }

            // Display all groups with names less than 8 characters in length.
            System.Console.WriteLine("");
            System.Console.WriteLine("Display all groups with names less than 8 characters in length.");

            var groupNameWithLessThan8Chars = Groups.Where(i => i.GroupName.Count() < 8);


            foreach(var i in groupNameWithLessThan8Chars)
            {
                System.Console.WriteLine(i.GroupName);
            }

            //Display the 3 oldest artist from Atlanta
            // var foundArtistFromAtlanta = from artist in Artists
            //                              orderby artist.Age descending
            //                              select new {artist.ArtistName, artist.Age};

            // foreach(var i in foundArtistFromAtlanta)
            // {
            //     System.Console.WriteLine(i);
            // }

            System.Console.WriteLine("");
            System.Console.WriteLine("Display the 3 oldest artist from Atlanta");

            IEnumerable<Artist> foundArtistFromAtlantaList = Artists.OrderByDescending(i => i.Age)
                                                                    .Where(i => i.Hometown ==  "Atlanta")
                                                                    .Take(3)
                                                                    .ToList();
            foreach(var i in foundArtistFromAtlantaList)
            {
                System.Console.WriteLine(i.RealName + " " + i.Age);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // var groupnamesFromNewYorkCity = Groups.Join(Artists,
            //                                            gItem => gItem,
            //                                            aItem => aItem,
            //                                            (gItem, aItem) =>
            //                                            {
            //                                                 return gItem + " " + aItem;
            //                                            }).Where(aItem => aItem.Hometown == "New York City");
            System.Console.WriteLine("");
            System.Console.WriteLine("(Optional) Display the Group Name of all groups that have members that are not from New York City");
            var groupnamesFromNewYorkCityList = from g in Groups
                                                join a in Artists on g.Id equals a.GroupId
                                                where a.Hometown != "New York City"// && gGroup.Count() == 1
                                                group g by new {ggroupname = g.GroupName, gid = g.Id} into g select new{
                                                    ggroupname = g.Key.ggroupname,
                                                    gid = g.Key.gid,
                                                };

            foreach(var i in groupnamesFromNewYorkCityList)
            {
                System.Console.WriteLine(i);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            System.Console.WriteLine("");
            System.Console.WriteLine("(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'");
            var ArtistNameOfGroup = from a in Artists
                                    join g in Groups on a.GroupId equals g.Id
                                    where g.GroupName == "Wu-Tang Clan"
                                    select new {a.ArtistName, g.GroupName};

            foreach(var i in ArtistNameOfGroup)
            {
                System.Console.WriteLine(i);
            }
        }
    }
}
