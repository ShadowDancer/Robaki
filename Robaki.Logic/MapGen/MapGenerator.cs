using System;
using ImageTools.Core;
using X;

namespace Robaki.Logic.MapGen
{
    public class MapGenerator
    {
        private PerlinNoise2 _perlinNoise;
        private OpenSimplexNoise _simplexNoise;

        public MapGenerator()
        {
            _perlinNoise = new PerlinNoise2(2);
            _simplexNoise = new OpenSimplexNoise();
        }

        public byte[,] GenerateMap(int width, int height)
        {
            byte[,] data = new byte[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var noise = MakeNoise(x, y);

                    if (noise > 0.5 && noise < 0.55)
                    { 
                        continue;
                    }
                    else
                    {
                        noise = 0.99999;
                    }

                    
                    data[x, y] =  (byte)(Math.Floor(noise * 256) % 256);
                }
            }

            return data;
        }

        private  double MakeNoise(int x, int y)
        {
            float scale = 0.00925f;


            double noise;
            //noise = _perlinNoise.Noise(x/10000.0, y / 10000.0, 1 / 10000.0);


            //noise = _simplexNoise.Evaluate(dx, dy);
            //noise = ((noise + 1) / 2);

            noise = SimplexNoise2.CalcPixel2D(x, y, scale);
            noise = noise / 256;

            return noise;

        }
    }
}