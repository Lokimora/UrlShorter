using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UrlShorter.Repository;

namespace UrlShorter.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UrlList()
        {
            return View();
        }
    }
}