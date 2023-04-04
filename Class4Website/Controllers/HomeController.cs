using Class4Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class4Website.Controllers
{


    public class HomeController : Controller
    {
        //private readonly BookDbContext db = new BookDbContext();
        // GET: Home
        public ActionResult Index()
        {
            //db.Books.ToList();
            return View();
        }
    }
}