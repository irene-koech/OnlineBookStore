using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStoreProject.Models;
using OnlineBookStoreProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Onsale = _bookRepository.BooksOnSale
            };

            return View(homeViewModel);
        }
    }
}
