using OpenTK.Graphics.OpenGL4;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace RoomExplorer;

public class Texture
{
    public int Handle { get; private set; }

        public Texture(string path)
        {
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Texture file not found: {path}\nCurrent directory: {Directory.GetCurrentDirectory()}");
            }
            Handle = GL.GenTexture();
            Use();

            // Load image
            using (var image = new Bitmap(path))
            {
                // Flip image vertically 
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Lock bitmap data
                var data = image.LockBits(
                    new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb
                );

                // Upload to GPU
                GL.TexImage2D(
                    TextureTarget.Texture2D,
                    0,
                    PixelInternalFormat.Rgba,
                    data.Width,
                    data.Height,
                    0,
                    PixelFormat.Bgra,  
                    PixelType.UnsignedByte,
                    data.Scan0
                );

                image.UnlockBits(data);
            }

            // Texture parameters
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            // Generate mipmaps
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            Console.WriteLine($"Texture loaded: {path}");
        }

        public void Use(TextureUnit unit = TextureUnit.Texture0)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }

        public void Dispose()
        {
            GL.DeleteTexture(Handle);
        }
    }
