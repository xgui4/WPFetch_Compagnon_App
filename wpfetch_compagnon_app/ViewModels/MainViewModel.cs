using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using wpfetch_compagnon_app.Models;

namespace wpfetch_compagnon_app.ViewModels
{
    public partial class MainViewModel : ObservableObject, IDisposable
    {
        private static ObservableCollection<OsTan>? osTans;

        public MainViewModel()
        {
            string win10TanDescription;
            try
            {
                using var stream = AssetLoader.Open(new Uri("avares://wpfetch_compagnon_app/Assets/win10.txt"));
                using var reader = new StreamReader(stream);
                win10TanDescription = reader.ReadToEnd() ?? "N/A";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                win10TanDescription = "Error while parsing information";
            }

            osTans = new ObservableCollection<OsTan>
            {
                new OsTan("Madobe Touko (窓辺 とうこ)", win10TanDescription, "avares://wpfetch_compagnon_app/Assets/win10.png")
            };
            osTanDesc = osTans[0].Description ?? "N/A";
            string temp = osTans[0].Image ?? "avares://wpfetch_compagnon_app/Assets/win10.png";
            try
            {
                using var imageStream = AssetLoader.Open(new Uri(temp));
                osTanImg = new Bitmap(imageStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

        [RelayCommand]
        private void SetDownloadButton()
        {
            string url = "https://github.com/xgui4/WPFetch/releases";
            if (OperatingSystem.IsWindows() || OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            else if (OperatingSystem.IsAndroid())
            {
                Console.WriteLine("This feature isn't available yet in mobile!");
            }
            else if (OperatingSystem.IsBrowser())
            {
                Console.WriteLine("This feature isn't available yet in the browser!");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
