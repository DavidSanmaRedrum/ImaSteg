using System.Drawing;
using System.Drawing.Imaging;

namespace ImaSteg.Functionalities {
    class FileFunctionality {

        public static void SaveEditedImage(Bitmap bitmap, string path) {
            bitmap.Save(path, ImageFormat.Png);
        }

    }
}
