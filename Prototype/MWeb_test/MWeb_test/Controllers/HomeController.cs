using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWeb_test.Models;

namespace MWeb_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly Mweb_DataTableFirstContext _context;

        public HomeController(Mweb_DataTableFirstContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Markers
        public async Task<IActionResult> Index()
        {
            var mweb_DataTableFirstContext = _context.Markers;
            return View(await mweb_DataTableFirstContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
