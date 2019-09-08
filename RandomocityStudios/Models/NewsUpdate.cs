using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace RandomocityStudios.Models
{
    public class NewsUpdate
    {
        public NewsUpdate() { }

        public NewsUpdate(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jsonProject = jObject["updates"];
            Title = (string)jsonProject["title"];
            Description = (string)jsonProject["description"];
            ImagePath = (string)jsonProject["imagepath"];
            PublishDate = (string)jsonProject["publishDate"];
            Author = (string)jsonProject["author"];
            Keywords = jsonProject["keywords"].ToObject<List<string>>() ;
        }


        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<string> Keywords { get; set; }

        //TODO: change this to DateTime when searching is implemented
        public string PublishDate { get; set;}

        public string Author { get; set; }
    }
}
