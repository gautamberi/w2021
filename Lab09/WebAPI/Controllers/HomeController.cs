using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using WebAPI.Services;


namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ImageFeed feed = new ImageFeed();
            ImageFeedService service = new ImageFeedService();
            feed.items = new List<Item>();
            
            //feed = service.GetFeed("niagarafalls");
            return View(feed);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            ImageFeed feed = new ImageFeed();
            ImageFeedService service = new ImageFeedService();

            feed = service.GetFeed(search);
            return View(feed);
        }

    }
}