using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;

namespace UI
{
    public static class VisualTesting
    {
        public static byte[] GetElementScreenshotBytes(this IWebDriver driver, IWebElement element)
        {
            var img = Image.FromStream(new MemoryStream(((ITakesScreenshot)driver).GetScreenshot().AsByteArray)) as Bitmap;
            Point fixedElementLocation = element.Location;
            fixedElementLocation.X += element.Size.Width;
            fixedElementLocation.Y += element.Size.Height;
            return (byte[])new ImageConverter()
                .ConvertTo(
                    img.Clone(
                        new Rectangle(fixedElementLocation, element.Size),
                        img.PixelFormat),
                    typeof(byte[]));
        }

        public static string GetElementScreenshotString(this IWebDriver driver, IWebElement element)
            => BitConverter.ToString(driver.GetElementScreenshotBytes(element));
    }
}
