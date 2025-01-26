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
    public partial class MainViewModel : ObservableObject
    {
        private static ObservableCollection<OsTan>? osTans;

        public MainViewModel()
        {
            string win10TanDescription;
            string win8TanDescription; 
            try
            {
                using var win10Desc = AssetLoader.Open(new Uri("avares://wpfetch_compagnon_app/Assets/win10.txt"));
                using var win8Desc = AssetLoader.Open(new Uri("avares://wpfetch_compagnon_app/Assets/win8.txt"));
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

            osTans = new ObservableCollection<OsTan>
            {
                new("Madobe Touko (窓辺 とうこ)", win10TanDescription, "avares://wpfetch_compagnon_app/Assets/win10.png"),
                new("Madobe Yu & Madobe Ai", win8TanDescription, "avares://wpfetch_compagnon_app/Assets/win8.png")
            };
            osTanDesc = osTans[Index].Description ?? "N/A";
            string temp = osTans[Index].Image ?? "avares://wpfetch_compagnon_app/Assets/win10.png";
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
            if (Index == 0) Index = (int)(osTans?.Count - 1 ?? 0);
            else Index--;
            UpdateMainInfoBox();
        }

        [RelayCommand]
        private void SetForwardButton()
        {
            Console.WriteLine("-------------------------------- Forward Button Pressed !! -----------------------");
            if (Index + 1 == osTans?.Count) Index = 0; 
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
            OsTanDesc = osTans?[Index].Description ?? "N/A";
            string temp = osTans?[Index].Image ?? "avares://wpfetch_compagnon_app/Assets/win10.png";
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
