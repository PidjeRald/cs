https://sun9-10.userapi.com/impg/cEA-12FZATP13eqBptYp2ot_mfRG-Pso41lp6g/ZfT0s7ZEtrE.jpg?size=852x823&quality=96&sign=6291ba6f9b31952045bf333a25f31229&type=album
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Drawing;

class ImageProcessor
{
    private Bitmap image;

    public ImageProcessor(string imagePath)
    {
        image = new Bitmap(imagePath);
    }

    public void SaveImage(string outputPath)
    {
        image.Save(outputPath);
    }

    private int[] GetHistogram(Bitmap image)
    {
        int[] histogram = new int[256];
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
                int intensity = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                histogram[intensity]++;
            }
        }
        return histogram;
    }

    private int[] GetCumulativeHistogram(int[] histogram)
    {
        int[] cumulativeHistogram = new int[256];
        cumulativeHistogram[0] = histogram[0];
        for (int i = 1; i < 256; i++)
        {
            cumulativeHistogram[i] = cumulativeHistogram[i - 1] + histogram[i];
        }
        return cumulativeHistogram;
    }

    public void HistogramEqualization()
    {
        int[] histogram = GetHistogram(image);
        int[] cumulativeHistogram = GetCumulativeHistogram(histogram);
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
                int intensity = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                int newIntensity = cumulativeHistogram[intensity] * 255 / (image.Width * image.Height);
                Color newPixel = Color.FromArgb(newIntensity, newIntensity, newIntensity);
                image.SetPixel(x, y, newPixel);
            }
        }
    }

    public void HistogramStretching()
    {
        int minIntensity = 255;
        int maxIntensity = 0;
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
                int intensity = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                if (intensity < minIntensity)
                {
                    minIntensity = intensity;
                }
                if (intensity > maxIntensity)
                {
                    maxIntensity = intensity;
                }
            }
        }
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
                int intensity = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                int newIntensity = (int)((intensity - minIntensity) * 255.0 / (maxIntensity - minIntensity));
                Color newPixel = Color.FromArgb(newIntensity, newIntensity, newIntensity);
                image.SetPixel(x, y, newPixel);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string imagePath = "C:\\Users\\asdf\\Desktop\\1.png";
        string outputImagePath1 = "C:\\Users\\asdf\\Desktop\\2.png";
        string outputImagePath2 = "C:\\Users\\asdf\\Desktop\\3.png";

        ImageProcessor image1 = new ImageProcessor(imagePath);
        image1.HistogramEqualization();
        image1.SaveImage(outputImagePath1);

        ImageProcessor image2 = new ImageProcessor(imagePath);
        image2.HistogramStretching();
        image2.SaveImage(outputImagePath2);
    }
}
