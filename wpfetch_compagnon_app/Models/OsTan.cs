using Avalonia.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfetch_compagnon_app.Models
{
    public class OsTan(string? name, string? description, string? image)
    {
        public string Name { get; set; } = name ?? "Unknown OS-Tan";
        public string Description { get; set; } = description ?? "This OS-Tan is mysterious!";
        public string Image { get; set; } = image ?? "UnknownOSTan.png";
    }
}
