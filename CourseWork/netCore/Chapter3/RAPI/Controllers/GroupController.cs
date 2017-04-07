using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        [RouteAttribute("/groups")]
        [HttpGet]

        public JsonResult AllGroups()
        {
            var allOfTheGroups = allGroups;
            return Json(allOfTheGroups);
        }

        [RouteAttribute("/groups/name/{name}/{displayArtists}")]
        [HttpGet]

        public JsonResult GroupName(string name, bool displayArtists)
        {
            if(displayArtists == true)
            {
                var ArtistNameOfGroup = from a in allArtists
                                    join g in allGroups on a.GroupId equals g.Id
                                    where g.GroupName == name
                                    select new {g.GroupName, a};
                return Json(ArtistNameOfGroup);
            }
            else
            {
                var ArtistNameOfGroup = from a in allArtists
                                    join g in allGroups on a.GroupId equals g.Id
                                    where g.GroupName == name
                                    select g;
                return Json(ArtistNameOfGroup);
            }
            
        }

        [RouteAttribute("/groups/id/{id}/{displayArtists}")]
        [HttpGet]

        public JsonResult GroupID(int id, bool displayArtists)
        {
            if(displayArtists == true)
            {
                var ArtistNameOfGroup = from a in allArtists
                                    join g in allGroups on a.GroupId equals g.Id
                                    where g.Id == id
                                    select new {g.GroupName, a};
                return Json(ArtistNameOfGroup);
            }
            else
            {
                var ArtistNameOfGroup = from a in allArtists
                                    join g in allGroups on a.GroupId equals g.Id
                                    where g.Id == id
                                    select g;
                return Json(ArtistNameOfGroup);
            }
        }
    }
}