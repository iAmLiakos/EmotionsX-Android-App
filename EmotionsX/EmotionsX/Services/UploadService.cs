using Android.App;
using Android.Graphics;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmotionsX.Services
{
    public class UploadService
    {
        private const string UPLOAD_URL = "http://192.168.0.119:81/api/upload";
        //private const string UPLOAD_URL = "http://10.0.2.2:62363/api/upload";

        public async Task<string> UploadBitmap(Bitmap bitmap)
        {
            string _message = "Failed retreiving data..";

            try
            {
                //converting bitmap into byte stream
                byte[] bitmapData;
                var stream = new System.IO.MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                bitmapData = stream.ToArray();
                var fileContent = new ByteArrayContent(bitmapData);

                fileContent.Headers.ContentLength = bitmapData.Length;
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");


                string boundary = "---------------------------acebdf13572468";
                MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
                multipartContent.Add(fileContent);

                //Toast.MakeText(Application.Context, "Sending image...", ToastLength.Long).Show();
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage response = await httpClient.PostAsync(UPLOAD_URL, multipartContent);
                if (response.IsSuccessStatusCode)
                {
                    Toast.MakeText(Application.Context, "Success", ToastLength.Long).Show();
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }


                Toast.MakeText(Application.Context, "Failed damn...", ToastLength.Long).Show();
                return _message;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}
