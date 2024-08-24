using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Core.Interfaces;
using System.Collections.Generic;
using YouTube.Services;

namespace YouTube.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index", "Video");
            }

            ViewData["Results"] = searchService.Search(query);
            return View();
        }
    }
}
