using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        private readonly IBookRepository _stall;
        private readonly string _connectionstring;
        public BookStoreController(IBookRepository stall, IConfiguration configuration)
        {
            _stall = stall;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }

        // GET: BookStore
        public ActionResult Index()
        {
            try
            {
                var result = _stall.GetAllBooks();
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult List()
        {
            try
            {
                var result = _stall.GetAllBookDetails();
                return View("List", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: BookStore/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _stall.GetByID(id);
                return View("Details", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: BookStore/Create
        public ActionResult Create(int ? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var Get = _stall.GetByID(id.Value);
                    return View("Create", Get);
                }
                else
                {
                    var result = new Book();
                    return View("Create", result);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: BookStore/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Book value)
        {
            try
            {
                if (value.BookId == 0)
                {
                    _stall.InsertBook(value);

                }
                else
                {
                    _stall.UpdateBook(value.BookId, value);
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: BookStore/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _stall.GetByID(id);
                return View("Edit", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: BookStore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book value)
        {
            try
            {
                _stall.UpdateBook(id, value);
                var result = _stall.GetAllBooks();
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }

        }

        

        // POST: BookStore/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _stall.DeleteBook(id);
                var result = _stall.GetAllBooks();
                return View("View", result);

            }
            catch
            {
                return View("Error");
            }
        }
    }
}
