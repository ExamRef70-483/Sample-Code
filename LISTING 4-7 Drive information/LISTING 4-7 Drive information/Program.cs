using System;
using System.IO;

namespace LISTING_4_7_Drive_information
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.Write("Name:{0} ", drive.Name);
                if (drive.IsReady)
                {
                    Console.Write("  Type:{0}", drive.DriveType);
                    Console.Write("  Format:{0}", drive.DriveFormat);
                    Console.Write("  Free space:{0}", drive.TotalFreeSpace);
                }
                else
                {
                    Console.Write("  Drive not ready");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
