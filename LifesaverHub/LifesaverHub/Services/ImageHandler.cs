namespace LifesaverHub.Services;

public static class ImageHandler
{
    public static void Test(string name)
    {
        var imageBytes = File.ReadAllBytes(name + ".jpg");
        var base64String = Convert.ToBase64String(imageBytes);
        Console.WriteLine("\n\n\n\nTEST:" + base64String + "\n\n");
    }
}