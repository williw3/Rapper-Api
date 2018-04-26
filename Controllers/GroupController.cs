using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
        [Route("/groups")]
        [HttpGet]
        public JsonResult GroupsAll()
        {
            return Json(allGroups);
        }
        [Route("/groups/name/{name}/{members}")]
        [HttpGet]
        public JsonResult Names(string name)
        {
            var AnonObj = allGroups.Where( str => str.GroupName == name);
            return Json(AnonObj);
        }
        [Route("/groups/id/{id}")]
        [HttpGet]
        public JsonResult GroupId(int id)
        {
            var AnonObj = allGroups.Where( num => num.Id == id);
            return Json(AnonObj);
        }
    }
}