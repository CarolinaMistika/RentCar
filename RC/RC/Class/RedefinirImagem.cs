using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace RC.Class
{
    public class RedefinirImagem
    {
        public static void MudaExtencaoImagem(string caminho, string imagemOriginal, string nomeImagem)
        {
            try
            {
                caminho = caminho.Replace(imagemOriginal, "");
                // Load the image.
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(@"" + caminho + imagemOriginal);
                // Save the image in JPEG format.
                image1.Save(@"" + caminho + nomeImagem + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
            }
        }

        public static void ResizeImage(string originalFile, string newFile, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            try
            {
                Image fullsizeImage = Image.FromFile(originalFile);

                // Prevent using images internal thumbnail
                fullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                fullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                if (onlyResizeIfWider)
                {
                    if (fullsizeImage.Width <= newWidth)
                    {
                        newWidth = fullsizeImage.Width;
                    }
                }

                int newHeight = fullsizeImage.Height * newWidth / fullsizeImage.Width;
                if (newHeight > maxHeight)
                {
                    // Resize with height instead
                    newWidth = fullsizeImage.Width * maxHeight / fullsizeImage.Height;
                    newHeight = maxHeight;
                }

                Image newImage = fullsizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

                // Clear handle to original file so that we can overwrite it if necessary
                fullsizeImage.Dispose();

                // Save resized picture
                newImage.Save(newFile);
            }
            catch (Exception ex)
            {
            }
        }
    }
}