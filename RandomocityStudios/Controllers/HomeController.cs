using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RandomocityStudios.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace RandomocityStudios.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _projectsDataFilePath;
        private List<Project> _projects;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _projectsDataFilePath = _hostingEnvironment.WebRootPath + "/files/projectsSeedData.json";
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

            // get projects data from json
            // TODO: use a DB instead of json once there are enough projects posts to justify doing so
            if(_projects == null || _projects.Count == 0)
            {
                try
                {
                    using (StreamReader file = new StreamReader(_projectsDataFilePath))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                        JToken projectArray = jsonObject.SelectToken("projects");
                        _projects = (List<Project>)projectArray.ToObject(typeof(List<Project>));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Project data could not be successfully parsed");
                }
            }

            ViewData["Projects"] = _projects;

            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult Resume()
        {
            string path = _hostingEnvironment.WebRootPath + @"/files/wvk_resume_apr_2019.pdf";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(stream, "application/pdf");
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
