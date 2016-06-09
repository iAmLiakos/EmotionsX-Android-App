using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;
using EmotionsX.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace EmotionsX.Services
{
    public class UploadService
    {
        private const string UPLOAD_URL = "http://192.168.0.125:3000/api/upload";
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
                try
                {

                    HttpResponseMessage response = await httpClient.PostAsync(UPLOAD_URL, multipartContent);
                    //Toast.MakeText(Application.Context, "Success", ToastLength.Long).Show();
                    if (response.IsSuccessStatusCode)
                    {

                        string content = await response.Content.ReadAsStringAsync();
                        Toast.MakeText(Application.Context, "Success", ToastLength.Long).Show();
                        return content;
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }

                Toast.MakeText(Application.Context, "Failed damn...", ToastLength.Long).Show();
                return _message;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<string> UploadPic(Bitmap image)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(5);
                using (var formData = new MultipartFormDataContent())
                {
                    //pernaw to bitmap ston server gia na apothikeutei ws jpeg
                    byte[] bitmapData;
                    var stream = new System.IO.MemoryStream();
                    image.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    bitmapData = stream.ToArray();
                    var httpContent = new ByteArrayContent(bitmapData);
                    formData.Add(httpContent, "file", "picture.jpg");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //HttpContent content = new StringContent(json);
                    try
                    {
                        //stelnw sto webapi mou gia na parw apotelesmata
                        //var response = await httpClient.PostAsync(UPLOAD_URL, formData);                       
                        //response.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                        Task<HttpResponseMessage> getResponse = httpClient.PostAsync(UPLOAD_URL, formData);
                        HttpResponseMessage response = await getResponse;
                        var responseStr = await response.Content.ReadAsStringAsync();
                        
                        
                        //var response2 = response.Content.ToString();
                        

                        if (response.IsSuccessStatusCode)
                        {
                            var response3 = response.Content.ReadAsStringAsync().Result;
                            //writing to file
                            //var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
                            //var filePath = System.IO.Path.Combine(sdCardPath, "results.txt");
                            //using (Stream s = GenerateStreamFromString(response2))
                            //{
                            //    System.IO.StreamWriter write = new System.IO.StreamWriter(s);

                            //}


                            //dimiourgia tou model mou
                            //JObject instaCall = JObject.Parse(responseStr);
                            //RootObject emotioResult = instaCall["RootObject"].ToObject<RootObject>();

                            //JArray a = JArray.Parse(responseStr);

                            //foreach (JObject o in a.Children<JObject>())
                            //{
                            //    foreach (JProperty p in o.Properties())
                            //    {
                            //        string name = p.Name;
                            //        string value = (string)p.Value;

                            //    }

                            //}
                            //RootObject emotion = new RootObject();                           
                            //MemoryStream stream1 = new MemoryStream();
                            //stream1.Position = 0;
                            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));

                            //var emotionobject = JsonConvert.DeserializeObject<RootObject>(responseStr);
                            //Debug.WriteLine(emotion.scores.happiness);
                            //ser.WriteObject(stream1, emotion);
                            //RootObject emo = (RootObject)ser.ReadObject(stream1); 
                            //Debug.WriteLine(emo.scores.anger);
                            Debug.WriteLine("Image was succesfully uploaded to server!!");
                            //Debug.WriteLine(response2);
                            //Emotion = await ResponseMessageToEmotionModel(response).ConfigureAwait(false);
                        }
                        return responseStr;
                    }
                    catch (HttpRequestException ex)
                    {
                        Debug.WriteLine("HttpRequestException");
                    }
                    catch (TaskCanceledException ex)
                    {
                        Debug.WriteLine("TaskCanceledException");
                    }

                    return null;
                }
            }

        }

        public Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private Task ResponseMessageToEmotionModel(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }
    }
}
