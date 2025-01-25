using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfetch_compagnon_app.Models;

namespace wpfetch_compagnon_app.ViewModels
{
    public partial class MainInfoBoxViewModel : ObservableObject
    {
        private readonly static StreamReader streamReader = new("Assets/win10.txt");
        private static readonly string win10TanDescription = streamReader.ReadToEnd() ?? "N/A";

        [ObservableProperty]
        private ObservableCollection<OsTan> osTans =
        [
            new OsTan("Madobe Touko (窓辺 とうこ)", win10TanDescription, "win10.png")
        ];
    }
}
