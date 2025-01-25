using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace wpfetch_compagnon_app.ViewModels;

public partial class MainViewModel : ObservableObject
{
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
            Console.WriteLine("This feature isnt available yet in mobile !");
        }
        else if (OperatingSystem.IsBrowser())
        {
            Console.WriteLine("This feature isnt available yet in the browser !");
        }
    }
}
