using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [RouteAttribute("/artists")]
        [HttpGet]

        public JsonResult AllArtists()
        {
            var allOfTheArtists = allArtists;
            return Json(allOfTheArtists);
        }


        [RouteAttribute("/artists/name/{name}")]
        [HttpGet]

        public JsonResult ArtistName(string name)
        {

            var stuff = from artist in allArtists
                        where artist.ArtistName == name
                        select artist;
            return Json(stuff);
        }

        [RouteAttribute("/artists/realname/{name}")]
        [HttpGet]

        public JsonResult ArtistRealName(string name)
        {

            var stuff = from artist in allArtists
                        where artist.RealName.Equals(name)
                        select artist;
            return Json(stuff);
        }

        [RouteAttribute("/artists/hometown/{town}")]
        [HttpGet]

        public JsonResult ArtistHomeTown(string town)
        {

            var stuff = from artist in allArtists
                        where artist.Hometown == town
                        select artist;
            return Json(stuff);
        }

        [RouteAttribute("/artists/groupid/{id}")]
        [HttpGet]

        public JsonResult ArtistID(int id)
        {

            var stuff = from artist in allArtists
                        where artist.GroupId.Equals(id)
                        select artist;
            return Json(stuff);
        }
    }
}