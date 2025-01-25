using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class OsTanCollectionViewModel : ObservableObject
    {
        private readonly StreamReader streamReader;
        private readonly string win10TanDescription;

        private static ObservableCollection<OsTan>? osTans;

        public OsTanCollectionViewModel()
        {
            streamReader = new StreamReader("avares://wpfetch_compagnon_app/Assets/win10.txt");
            win10TanDescription = streamReader.ReadToEnd() ?? "N/A";
            osTans = [new OsTan("Madobe Touko (窓辺 とうこ)", win10TanDescription, "avares://wpfetch_compagnon_app/Assets/win10.png")];
            Console.WriteLine("-------------------------------------------------------- Liste OS-Tan inité ! -------------------------------------------------");
            osTanDesc = osTans[0].Description ?? "N/A";
            string temp = osTans[0].Image ?? "avares://wpfetch_compagnon_app/Assets/win10.png";
            Console.WriteLine("-------------------------------------------------------- Liste OS-Tan inité avec les propriété ! ! -------------------------------------------------");
            try
            {
                osTanImg = new Bitmap("win10.png");
            }
            catch
            {
                try
                {
                    osTanImg = new Bitmap(temp);
                }
                catch
                {
                    osTanImg = new Bitmap("avares://wpfetch_compagnon_app/Assets/win10.png)");
                }
            }
        }

        [ObservableProperty]
        private string osTanDesc;

        [ObservableProperty]
        private Bitmap osTanImg; 

        [RelayCommand]
        private void SetBackwardButton()
        {
            Console.WriteLine("-------------------------------- Backward Button Pressed !! -----------------------");
        }

        [RelayCommand]
        private void SetForwardButton()
        {
            Console.WriteLine("-------------------------------- Forward Button Pressed !! -----------------------");
        }
    }
}
