using BepInNode.Core;
using Veldrid.ImageSharp;

namespace BepInNode.Utilities
{
    public class ImageController
    {
        private static Dictionary<string, IntPtr> _images = new();

        public static IntPtr GetImageByName(string name)
        {
            if (_images.TryGetValue(name, out var image))
            {
                return image;
            }
            return IntPtr.Zero;
        }

        // should be called on program initialization
        public static void LoadImage(string embeddedResourceName)
        {
            Helpers.TryGetEmbeddedResourceBytes(embeddedResourceName, out var imgData);
            Stream stream = new MemoryStream();
            stream.Write(imgData);
            stream.Position = 0;

            var img = new ImageSharpTexture(stream);
            var dimg = img.CreateDeviceTexture(Program._gd, Program._gd.ResourceFactory);
            _images.Add(embeddedResourceName, Program._controller.GetOrCreateImGuiBinding(Program._gd.ResourceFactory, dimg));
        }
    }
}
