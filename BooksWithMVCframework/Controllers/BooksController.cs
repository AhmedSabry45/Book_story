using BooksWithMVCframework.Models;
using BooksWithMVCframework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BooksWithMVCframework.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        //take instance from db
        private readonly AppDbContext _context;

        public BooksController()
        {
            _context=new AppDbContext();
        }
        public ActionResult Index()
        {
            var books = _context.Books.Include(m=>m.categories).ToList();
            return View(books);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //when make search by primaryid of table
            var book = _context.Books.Include(m=>m.categories).SingleOrDefault(m=>m.Id==id); 

            if(book == null)
                return HttpNotFound();

            return View(book);
        
        
        }
        public ActionResult Create()
        { 
            var viewModel = new BookFormVm
            {
                categories=_context.categories.Where(m=>m.Action).ToList()        
            };
            return View("BookForm",viewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var book=_context.Books.Find(id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormVm
            {
                Id=book.Id,
                Title =book.Title,
                Author = book.Author,
                categoriesId = book.categoriesId,
                Description = book.Description,
                categories=_context.categories.Where(m=>m.Action).ToList() 
            };
            return View("BookForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFormVm model)
        {
            //make validation in server side
            if (!ModelState.IsValid)
            {
                model.categories = _context.categories.Where(m => m.Action).ToList();
                return View("BookForm");
            }

            if (model.Id == 0)
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    categoriesId = model.categoriesId,
                    Description = model.Description
                };

                _context.Books.Add(book);

            } 
            else
            {
                var book=_context.Books.Find(model.Id);

                if(book == null)
                    return HttpNotFound();

                book.Title = model.Title;
                book.Author = model.Author;
                book.categoriesId= model.categoriesId;
                book.Description = model.Description;
            }
            _context.SaveChanges();

            //for Toastr
            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index");
        }
    }
}