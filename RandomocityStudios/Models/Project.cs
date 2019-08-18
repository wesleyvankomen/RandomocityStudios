using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomocityStudios.Models
{
    public class Project
    {
        public Project() { }

        public Project(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jsonProject = jObject["project"];
            Id = (int)jsonProject["id"];
            Title = (string)jsonProject["title"];
            ImagePath = (string)jsonProject["imagepath"];
            Description = (string)jsonProject["description"];
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
