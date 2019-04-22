using System;
using System.Web.Mvc;

namespace Microsoft.Teams.Samples.TaskModule.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("configure")]
        public ActionResult Configure()
        {
            return View();
        }

        [Route("CreateItem")]
        public ActionResult CreateItem()
        {
            ViewBag.Result = "Create Item";
            if (Request.HttpMethod.ToUpperInvariant() == "POST")
            {
                var item = new ItemInfo()
                {
                    Id = Guid.NewGuid(),
                    Name = Request.Form["name"],
                    Description = Request.Form["description"],
                    Link = Request.Form["link"],
                    Image = string.IsNullOrEmpty(Request.Form["image"]) ? "http://lorempixel.com/800/800?rand=" + DateTime.Now.Ticks.ToString() : Request.Form["image"],
                    CreatedUser = Request.Form["createdUser"],
                    CreatedTime = DateTime.Now,
                };
                ItemDB.AddItem(item);
            }

            return View(ViewBag);
        }

        [Route("UpdateItem/{id}")]
        public ActionResult UpdateItem(Guid id)
        {
            ViewBag.Result = "Update Item";
            var item = ItemDB.Items.Find(b => b.Id == id);
            if (Request.HttpMethod.ToUpperInvariant() == "POST")
            {
                item.Name = Request.Form["name"];
                item.Description = Request.Form["description"];
                item.Link = Request.Form["link"];
                item.Image = string.IsNullOrEmpty(Request.Form["image"]) ? "http://lorempixel.com/800/800?rand=" + DateTime.Now.Ticks.ToString() : Request.Form["image"];
                item.UpdatedUser = Request.Form["updatedUser"];
                item.UpdatedTime = DateTime.Now;
            }

            return View(item);
        }

        [Route("ListItem")]
        public ActionResult ListItem()
        {
            return View();
        }
    }
}
