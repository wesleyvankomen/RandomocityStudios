using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomocityStudios.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Descriptions { get; set; }
    }
}
