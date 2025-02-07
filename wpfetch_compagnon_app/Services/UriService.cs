using System;

namespace wpfetch_compagnon_app.Services;

public class UriService
{
    private const string AvaloniaUrl = "avares://wpfetch_compagnon_app/Assets/"; 

    public string GetUriString(string filename)
    {
        return AvaloniaUrl + filename;
    } 
    
    public Uri GetUri(string filename)
    {
        return new Uri(AvaloniaUrl  + filename);
    } 
}