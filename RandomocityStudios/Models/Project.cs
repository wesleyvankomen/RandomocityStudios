using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomocityStudios.Models
{
    // TODO: Use an ORM once there are too many projects to manage in json
    public class Project
    {
        public Project() { }

        public Project(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jsonProject = jObject["project"];
            Title = (string)jsonProject["title"];
            ImagePath = (string)jsonProject["imagepath"];
            Description = (string)jsonProject["description"];
            Url = (string)jsonProject["url"];
            Source = (string)jsonProject["source"];
            Tech = (string)jsonProject["tech"];
        }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public string Url { get; set; }

        public string Tech { get; set; }
    }
}
