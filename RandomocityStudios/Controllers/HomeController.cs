using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RandomocityStudios.Models;

namespace RandomocityStudios.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Returns a splash page for incoming users
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Returns a page with a list of projects
        /// </summary>
        public IActionResult Projects()
        {
            ViewData["Message"] = "Coming Soon!";

            return View();
        }

        /// <summary>
        /// Returns a pdf resume file stream
        /// </summary>
        public IActionResult Resume()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var stream = new FileStream(webRootPath+@"\files\wvk_resume_apr_2019.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
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
