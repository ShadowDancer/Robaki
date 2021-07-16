using System;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;
using ImageTools.Core;
using Robaki.Logic.MapGen;
using X;
using Xunit;

namespace Robaki.Tests
{
    public class Playground
    {
        [Fact]
        public void Test1()
        {
            var map = new MapGenerator().GenerateMap(1024, 1024);
            Bitmap b = new Bitmap(map.GetLength(0), map.GetLength(1));

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    var pixel = map[x, y];
                    b.SetPixel(x, y, Color.FromArgb(255, pixel, pixel,pixel));
                }
            }

            b.Save("File.bmp");
        }

        [Fact]
        public void Test2()
        {
            PerlinNoise2 noise = new PerlinNoise2(42);
            var z = Enumerable.Range(0, 999999).Select(n => noise.Noise(n/1000.0, n / 1000.0, 1 / 1000.0)).ToArray();
            double max = z.Max();
            double min = z.Min();


        }
    }
}
