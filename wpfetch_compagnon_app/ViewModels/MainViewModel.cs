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
using wpfetch_compagnon_app.Services;

namespace wpfetch_compagnon_app.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private static readonly UriService UriService = new UriService();
        private static ObservableCollection<OsTan>? OsTans;

        public MainViewModel()
        {
            string win10TanDescription;
            string win8TanDescription; 
            try
            {
                using var win10Desc = AssetLoader.Open(UriService.GetUri("win10.md"));
                using var win8Desc = AssetLoader.Open(UriService.GetUri("win8.md"));
                using var win10reader = new StreamReader(win10Desc);
                using var win8reader = new StreamReader(win8Desc);
                win10TanDescription = win10reader.ReadToEnd() ?? "N/A";
                win8TanDescription = win8reader.ReadToEnd() ?? "N/A"; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                win10TanDescription = "Error while parsing information";
                win8TanDescription = "Error while parsing information"; 
            }

            OsTans = new ObservableCollection<OsTan>
            {
                new("Madobe Touko (窓辺 とうこ)", win10TanDescription, UriService.GetUriString("win10.png")),
                new("Madobe Yu & Madobe Ai", win8TanDescription, UriService.GetUriString("win8.png"))
            };
            osTanDesc = OsTans[Index].Description ?? "N/A";
            string temp = OsTans[Index].Image ?? UriService.GetUriString("win10.png");
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
        private string titleLabel = "Welcome to WPFetch: OS-Tan Collection!";

        [ObservableProperty]
        private string warningLabel = "This app is a work in progress!";

        [ObservableProperty]
        private string osTanDesc;

        [ObservableProperty]
        private Bitmap? osTanImg;

        [ObservableProperty]
        private int _index = 0;

        [RelayCommand]
        private void SetBackwardButton()
        {
            Console.WriteLine("-------------------------------- Backward Button Pressed !! -----------------------");
            if (Index == 0) Index = (int)(OsTans?.Count - 1 ?? 0);
            else Index--;
            UpdateMainInfoBox();
        }

        [RelayCommand]
        private void SetForwardButton()
        {
            Console.WriteLine("-------------------------------- Forward Button Pressed !! -----------------------");
            if (Index + 1 == OsTans?.Count) Index = 0; 
            else Index++;
            UpdateMainInfoBox();
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

        private void UpdateMainInfoBox()
        {
            OsTanDesc = OsTans?[Index].Description ?? "N/A";
            string temp = OsTans?[Index].Image ?? UriService.GetUriString("win10.png");
            try
            {
                using var imageStream = AssetLoader.Open(new Uri(temp));
                OsTanImg = new Bitmap(imageStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
