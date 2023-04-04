using Class4Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class4Website.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext db = new BookDbContext();
        // GET: Books

        public ActionResult Index()
        {

            return View(db.Books.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(b);
        }

    }
}