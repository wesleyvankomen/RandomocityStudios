using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RandomocityStudios.Models;
using Microsoft.AspNetCore.Authorization;

namespace RandomocityStudios.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string _webRoot;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRoot = _hostingEnvironment.WebRootPath;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Projects")]
        public IActionResult Projects()
        {
            string _projectsDataFilePath = _webRoot + "/files/projectsSeedData.json";
            List<Project> _projects = new List<Project>();

            // get projects data from json
            // TODO: use a DB instead of json once there are enough projects posts to justify doing so
            try
            {
                using (StreamReader file = new StreamReader(_projectsDataFilePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                    JToken projectArray = jsonObject.SelectToken("projects");
                    _projects = projectArray.ToObject< List<Project>>();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Project data could not be successfully parsed");
            }

            ViewData["Projects"] = _projects;

            return View();
        }

        [Route("/About")]
        public IActionResult About()
        {
            string directory = _webRoot + "/images/slideshow";

            ViewData["Title"] = "About Me";

            // retrieve music playlist
            try
            {
                using (StreamReader file = new StreamReader(_webRoot + "/files/music.json"))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                        JToken projectArray = jsonObject.SelectToken("music");

                        string musicPlayerOptions = @"?enablejsapi=1&version=3&playerapiid=ytplayer";
                        List<string> urls = projectArray.ToObject(typeof(List<string>)) as List<string>;

                        ViewData["Music"] = urls.Select(x => x + musicPlayerOptions).ToList();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Project data could not be successfully parsed");
            }

            // retrieve picture file paths
            List<string> pictures = Directory.GetFiles(directory, "*.jpg").ToList().Select(x => x.Split(_webRoot)[1]).ToList(); ;
            ViewData["Pictures"] = pictures;

            return View();
        }

        [Route("/Resume")]
        public IActionResult Resume()
        {
            string path = _hostingEnvironment.WebRootPath + @"/files/wvk_resume_sep_2023.pdf";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(stream, "application/pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        [Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
