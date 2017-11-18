using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class BookController : Controller
    {
        BookStoreContext db = new BookStoreContext();
        public ActionResult Index()
        {
            var model = db.Books;
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.Authors = db.Authors;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ViewBag.Authors = db.Authors;
            try
            {

                if (!collection.AllKeys.Contains("author"))
                {
                    ModelState.AddModelError("", "Please select any author");
                    return View();
                }
                var book = new BookViewModel() { Title = collection["Title"], DateEdition = Convert.ToDateTime(collection["DateEdition"]) };

                var authors = collection.Get("author").Split(',').Select(x => int.Parse(x.ToString())).ToArray();
                db.Books.Add(book);
                db.SaveChanges();
                SaveBookAuthor(book.BookID, authors);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(collection);
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private void SaveBookAuthor(int id, int[] authors)
        {
            try
            {
                foreach (var item in authors)
                {
                    db.BookAuthors.Add(new BookAuthorViewModel() { BookID = id, AuthorID = item });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
