using System;

namespace wpfetch_compagnon_app.Services;

public class ImageService
{
    private const string AvaloniaUrl = "avares://wpfetch_compagnon_app/Assets/"; 
    
    public string GetImageUriString(string filename)
    {
        return filename + AvaloniaUrl;
    } 
    
    public Uri GetImageUri(string filename)
    {
        return new Uri(filename + AvaloniaUrl);
    } 
}