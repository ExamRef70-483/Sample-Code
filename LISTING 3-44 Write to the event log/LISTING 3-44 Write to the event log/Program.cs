using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace LISTING_3_44_Write_to_the_event_log
{
    class Program
    {
        static EventLog imageEventLog;

        enum CreationResult
        {
            CreatedLog,
            LoadedLog
        };

        static CreationResult SetupLog()
        {
            string categoryName = "Image Processing";

            if (EventLog.SourceExists(categoryName))
            {
                imageEventLog = new EventLog();
                imageEventLog.Source = categoryName;
                return CreationResult.LoadedLog;
            }

            EventLog.CreateEventSource(source: categoryName,
                logName: categoryName + " log");

            return CreationResult.CreatedLog;
        }

        public static void MakeThumbnail(string sourceFile, string destDir, int width, int height)
        {
            String filename = Path.GetFileName(sourceFile);

            String destPath = Path.Combine(destDir, filename);

            Bitmap bitmap = new Bitmap(sourceFile);

            float scale = Math.Min((float)width / bitmap.Width, (float)height / bitmap.Height);

            int scaleWidth = (int)(bitmap.Width * scale);
            int scaleHeight = (int)(bitmap.Height * scale);

            Bitmap resized = new Bitmap(bitmap, new Size(scaleWidth, scaleHeight));
            resized.Save(destPath);
        }

        public static void MakeThumbnailsSeq(string sourceDir, string destDir, int width = 320, int height = 240)
        {
            String[] files = Directory.GetFiles(sourceDir, "*.jpg");

            Directory.CreateDirectory(destDir);

            foreach (string filename in files)
            {
                MakeThumbnail(filename, destDir, width, height);
            }
        }

        public static void MakeThumbnailsParallel(string sourceDir, string destDir, int width = 320, int height = 240)
        {
            String[] files = Directory.GetFiles(sourceDir, "*.jpg");

            Directory.CreateDirectory(destDir);

            Parallel.ForEach(files, (filename) =>
            {
                MakeThumbnail(filename, destDir, width, height);
            });
        }

        static void sequentialTest()
        {
            // sourceDir is a directory of images
            // destDir is to the destination directory which will be automatically 
            // created.

            MakeThumbnailsSeq(sourceDir: @"..\..\..\..\images",
                destDir: @"..\..\..\..\images\Serial");
        }

        static void parallelTest()
        {
            MakeThumbnailsParallel(sourceDir: @"..\..\..\..\images",
                destDir: @"..\..\..\..\images\Parallel");
        }

        static void Main(string[] args)
        {
            if (SetupLog() == CreationResult.CreatedLog)
            {
                Console.WriteLine("Log created");
                Console.WriteLine("Restart the program");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Processing started");

            imageEventLog.WriteEntry("Image processing started");

            sequentialTest();

            parallelTest();
            imageEventLog.WriteEntry("Image processing ended");

            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
