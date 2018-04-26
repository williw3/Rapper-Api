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
        [Route("/artists")]
        [HttpGet]
        public List<Artist> getAll()
        {
            return allArtists;
        }
        [Route("/artists/name/{name}")]
        [HttpGet]
        public JsonResult Names(string name)
        {
            var AnonObj = allArtists.Where( str => str.ArtistName == name);
            return Json(AnonObj);
        }
        [Route("/artists/realname/{name}")]
        [HttpGet]
        public JsonResult RealName(string name)
        {
            var AnonObj = allArtists.Where( str => str.RealName == name);
            return Json(AnonObj);
        }
        [Route("/artists/hometown/{hometown}")]
        [HttpGet]
        public JsonResult HomeTown(string hometown)
        {
            var AnonObj = allArtists.Where( str => str.Hometown == hometown);
            return Json(AnonObj);
        }
        [Route("/artists/groupid/{id}")]
        [HttpGet]
        public JsonResult HomeTown(int id)
        {
            var AnonObj = allArtists.Where( num => num.GroupId == id);
            return Json(AnonObj);
        }
    }
}