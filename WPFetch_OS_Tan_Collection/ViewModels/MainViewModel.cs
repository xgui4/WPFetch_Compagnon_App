﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Net;
using System.Net.Http;

namespace WPFetch_OS_Tan_Collection.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private async Task SetDownloadButtonAsync()
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
        else if (OperatingSystem.IsAndroid()) {
            Console.WriteLine("This feature isnt available yet in mobile !");
        }
        else if (OperatingSystem.IsBrowser()) {
            Console.WriteLine("This feature isnt available yet in the browser !");
        }
    }
}
