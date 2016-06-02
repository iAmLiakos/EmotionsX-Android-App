using Android.Graphics;
using EmotionsX.Services;
using System.Threading.Tasks;

namespace EmotionsX.Droid
{
    internal class UploadServiceConsumer
    {

        private Bitmap bmp;

        public async Task<string> UploadServiceCons(Bitmap bmp)
        {
            this.bmp = bmp;
            UploadService service = new UploadService();
            string response = await service.UploadBitmap(bmp);
            return response;
           
        }
    }
}