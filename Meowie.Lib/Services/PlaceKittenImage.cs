namespace Meowie.Lib.Services;

public static class PlaceKittenImage
{
    public static string GetUrl(int width, int height)
    {
        return $"https://placekitten.com/{width}/{height}";
    }

    public static string GetRandomUrl(int maxWidth,  int minWidth = 50)
    {
        int size = Random.Shared.Next(minWidth, maxWidth);
        string url = 
         $"https://placekitten.com/{size}/{size}";

        return url;
    }
}