using Avalonia.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfetch_compagnon_app.Models
{
    public class OsTan
    {
        public OsTan(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }

}