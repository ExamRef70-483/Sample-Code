// Ex 1.1  Parallel Thumbnails
// Shows how the parallel ForEach construction can be used to improve performance
// by performing multiple resizes on a folder full of images. 

// Change the source and destination paths to match folders on your computer


using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

public class Example
{

    public static void MakeThumbnail(string sourcePath, string destPath, int width, int height)
    {
        Bitmap bitmap = new Bitmap(sourcePath);

        float scale = Math.Min((float)width / bitmap.Width, (float)height / bitmap.Height);

        int scaleWidth = (int)(bitmap.Width * scale);
        int scaleHeight = (int)(bitmap.Height * scale);

        Bitmap resized = new Bitmap(bitmap, new Size(scaleWidth, scaleHeight));
        resized.Save(destPath);
    }

    public static void MakeThumbnailsSeq(string source, string dest, int width = 320, int height = 240)
    {
        String[] files = Directory.GetFiles(source, "*.jpg");

        Directory.CreateDirectory(dest);

        foreach (string sourcePath in files)
        {
            String filename = Path.GetFileName(sourcePath);
            String destPath = Path.Combine(dest, filename);
            MakeThumbnail(sourcePath, destPath, width, height);
        }
    }

    public static void MakeThumbnailsParallel(string source, string dest, int width = 320, int height = 240)
    {
        String[] files = Directory.GetFiles(source, "*.jpg");

        Directory.CreateDirectory(dest);

        Parallel.ForEach(files, (sourcePath) =>
        {
            String filename = Path.GetFileName(sourcePath);
            String destPath = Path.Combine(dest, filename);
            MakeThumbnail(sourcePath, destPath, width, height);

        });
    }

    public static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        MakeThumbnailsSeq(source: @"C:\Users\Rob\OneDrive\Blog Pictures",
            dest: @"C:\Users\Public\Pictures\Sample Pictures\Parallel"); ;

        stopwatch.Stop();

        Console.Error.WriteLine("Sequential time in milliseconds: {0}",
                                        stopwatch.ElapsedMilliseconds);

        stopwatch.Restart();

        MakeThumbnailsParallel(source: @"C:\Users\Rob\OneDrive\Blog Pictures",
            dest: @"C:\Users\Public\Pictures\Sample Pictures\Parallel");

        stopwatch.Stop();

        Console.Error.WriteLine("Parallel loop time in milliseconds: {0}",
                                        stopwatch.ElapsedMilliseconds);

        Console.WriteLine("Processing complete. Press any key to exit.");
        Console.ReadKey();
    }
}