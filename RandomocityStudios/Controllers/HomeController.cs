﻿using System;
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
        private readonly string _webRoot;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRoot = _hostingEnvironment.WebRootPath;
            
        }

        /// <summary>
        /// Returns a splash page for incoming users
        /// </summary>
        public IActionResult Index()
        {

            string _projectsDataFilePath = _webRoot + "/files/projectsSeedData.json";
            List<NewsUpdate> _updates = new List<NewsUpdate>();

            // get projects data from json
            // TODO: use a DB instead of json once there are enough projects posts to justify doing so
            try
            {
                using (StreamReader file = new StreamReader(_projectsDataFilePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                    JToken projectArray = jsonObject.SelectToken("updates");
                    _updates = projectArray.ToObject<List<NewsUpdate>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Project data could not be successfully parsed");
            }


            ViewData["Updates"] = _updates;


            return View();
        }
        
        /// <summary>
        /// Returns a page with a list of projects
        /// </summary>
        public IActionResult Projects()
        {
            ViewData["Message"] = "Coming Soon!";

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
            catch (Exception ex)
            {
                Console.WriteLine("Project data could not be successfully parsed");
            }
            

            ViewData["Projects"] = _projects;

            return View();
        }

        public IActionResult AboutMe()
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
            catch (Exception ex)
            {
                Console.WriteLine("Project data could not be successfully parsed");
            }


            // retrieve picture file paths
            List<string> pictures = Directory.GetFiles(directory, "*.jpg").ToList().Select(x => x.Split(_webRoot)[1]).ToList(); ;
            ViewData["Pictures"] = pictures;

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
