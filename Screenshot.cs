using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace snippet
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = $"{Path.GetTempPath()}test";
            Screenshot($"{path}\\{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second} {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.jpg");
            Console.ReadLine();
        }

        // References > System.Drawing
        public static void Screenshot(string path)
        {
            Bitmap img = new Bitmap(Convert.ToInt32(SystemParameters.PrimaryScreenWidth), Convert.ToInt32(SystemParameters.PrimaryScreenHeight));
            Size s = new Size(img.Width, img.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(0, 0, 0, 0, s);
            img.Save(path, ImageFormat.Jpeg);
            img.Dispose();
            g.Dispose();
        }
    }
}
