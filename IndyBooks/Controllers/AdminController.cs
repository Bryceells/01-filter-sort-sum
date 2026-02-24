using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using IndyBooks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IndyBooks.Controllers
{
    public class AdminController : Controller
    {
        private Services.Repository _repo;
        public AdminController(Services.Repository repo) { _repo = repo; }
    
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchVM searchVM)
        {
            var searchResults = searchVM.HalfPriceSale ?
            new SearchResultsVM { 
                Books = _repo.SaleResults,
                isSale = true
            } : 
            new SearchResultsVM { 
                Books = _repo.searchResults(searchVM).ToList(),
                isSale = false
            }; 

            return View("SearchResults", searchResults);
        }
    }
}
