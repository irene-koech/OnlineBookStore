using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreProject.Models;
using OnlineBookStoreProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

       /* public ViewResult List()
        {
            BooksListViewModel booksListViewModel = new BooksListViewModel();
            booksListViewModel.Books = _bookRepository.GetAllBooks;

            booksListViewModel.CurrentCategory = "Comedy books";
            return View(booksListViewModel);
        }*/

        public ViewResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.GetAllBooks.OrderBy(b => b.BookId);
                currentCategory = "All books";
            }
            else
            {
                books = _bookRepository.GetAllBooks.Where(b => b.Category.CategoryName == category)
                    .OrderBy(b => b.BookId);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new BooksListViewModel
            {
                Books = books,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }


    /**
    // GET: BookController
    public ActionResult Index()
    {
        return View();
    }

    // GET: BookController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: BookController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BookController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BookController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: BookController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BookController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BookController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }*/
}
}
