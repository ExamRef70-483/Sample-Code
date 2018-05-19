using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace LISTING_3_43_Create_performance_counters
{
    class Program
    {
        static PerformanceCounter TotalImageCounter;
        static PerformanceCounter ImagesPerSecondCounter;

        enum CreationResult
        {
            CreatedCounters,
            LoadedCounters
        };

        static CreationResult SetupPerformanceCounters()
        {
            string categoryName = "Image Processing";

            if (PerformanceCounterCategory.Exists(categoryName))
            {
                TotalImageCounter = new PerformanceCounter(categoryName:categoryName, 
                    counterName:"# of images processed", 
                    readOnly:false);
                ImagesPerSecondCounter = new PerformanceCounter(categoryName:categoryName, 
                    counterName: "# images processed per second", 
                    readOnly:false);
                return CreationResult.LoadedCounters;
            }

            CounterCreationData[] counters = new CounterCreationData[] {
                new CounterCreationData(counterName:"# of images processed",
                counterHelp:"number of images resized",
                counterType:PerformanceCounterType.NumberOfItems64),
                new CounterCreationData(counterName: "# images processed per second", 
                counterHelp:"number of images processed per second", 
                counterType:PerformanceCounterType.RateOfCountsPerSecond32)
            };

            CounterCreationDataCollection counterCollection = new CounterCreationDataCollection(counters);

            PerformanceCounterCategory.Create(categoryName:categoryName,
                categoryHelp:"Image processing information", 
                categoryType: PerformanceCounterCategoryType.SingleInstance, 
                counterData:counterCollection);

            return CreationResult.CreatedCounters;
        }

        public static void MakeThumbnail(string sourceFile, string destDir, int width, int height)
        {
            TotalImageCounter.Increment();

            ImagesPerSecondCounter.Increment();

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
                destDir: @"..\..\..\..\images\Serial"); ;
        }

        static void parallelTest()
        {
            MakeThumbnailsParallel(sourceDir: @"..\..\..\..\images",
                destDir: @"..\..\..\..\images\Parallel");
        }

        static void Main(string[] args)
        {

            if(SetupPerformanceCounters() == CreationResult.CreatedCounters)
            {
                Console.WriteLine("Performance counters created");
                Console.WriteLine("Restart the program");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Processing started");

            sequentialTest();

            parallelTest();

            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
