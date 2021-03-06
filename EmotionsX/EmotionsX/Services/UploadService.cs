﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;
using EmotionsX.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private const string UPLOAD_URL = "http://192.168.0.123:3000/api/upload";
        

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


        public async Task<RootObject> UploadPic(Bitmap image)
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
                    
                    //sto swma tou request eswmatwnw to token kai to locations gia na perasoun ston server
                    var prefs = Application.Context.GetSharedPreferences("Shared", FileCreationMode.Private);
                    string bearer = prefs.GetString("Bearer", "");
                    string location = prefs.GetString("Location", "");
                    //httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
           
                    httpClient.DefaultRequestHeaders.Add("Location", location);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer "+bearer);
                    //httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    

                    //HttpContent content = new StringContent(json);
                    try
                    {
                        //stelnw sto webapi mou gia na parw apotelesmata
                        //var response = await httpClient.PostAsync(UPLOAD_URL, formData);                       
                        //response.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                        //no1                      
                        HttpResponseMessage response = await httpClient.PostAsync(UPLOAD_URL, formData);
                        var responseStr = await response.Content.ReadAsStringAsync();
                        responseStr = responseStr.Replace(@"\", string.Empty).Trim(new char[] { '\"' });

                        //Deserialize
                        var aaa = JsonConvert.DeserializeObject<List<RootObject>>(responseStr);

                        //Handwrited json for testing purposes
                        //string jsontesting = @"[{'faceRectangle': {
                        //                                      'height': 100,
                        //                                      'left': 86,
                        //                                      'top': 31,
                        //                                      'width': 100

                        //                                            },
                        //                     'scores': {
                        //                              'anger': 4.18072176E-07,
                        //                              'contempt': 3.53371838E-08,
                        //                              'disgust': 3.424829E-07,
                        //                              'fear': 0.000125886916,
                        //                              'happiness': 0.0487938821,
                        //                              'neutral': 9.02477154E-07,
                        //                              'sadness': 1.2120166E-09,
                        //                              'surprise': 0.951078534
                        //                                 }
                        //                    }]";


                        if (response.IsSuccessStatusCode)
                        {

                            //writing to file
                            //var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
                            //var filePath = System.IO.Path.Combine(sdCardPath, "results.txt");
                            //using (Stream s = GenerateStreamFromString(response2))
                            //{
                            //    System.IO.StreamWriter write = new System.IO.StreamWriter(s);

                            //}


                            //dimiourgia tou model mou
                            //dynamic emotionObject = JArray.Parse(responseStr);                           
                            //RootObject emotioResult = emotionObject["scores"].ToObject<RootObject>();
                            //dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsontesting);
                            //dynamic test = json[0];                           
                            //dynamic testing = test.faceRectangle;
                            //string top = testing.top;



                            //JArray a = JArray.Parse(responseStr);

                            //foreach (JObject o in a.Children<JObject>())
                            //{
                            //    foreach (JProperty p in o.Properties())
                            //    {
                            //        string name = p.Name;
                            //        string value = (string)p.Value;

                            //    }

                            //}
                            //Works~~~sort of
                            //RootObject emotion = new RootObject();
                            //JArray resultJson = new JArray(responseStr);
                            //JArray resultInJson = JArray.Parse(responseStr);
                            //items = new ObservableCollection<Scores>(
                            //   resultInJson.Children().Select(jo => jo["anger"]["contempt"]["disgust"]["fear"]["happiness"]["neutral"]["sadness"]["surprise"].ToObject<Scores>()));

                            //IList<Scores> emotions = resultInJson.Select(p => new Scores
                            //{
                            //    anger = (double)p["anger"],
                            //    contempt = (double)p["contempt"],
                            //    disgust = (double)p["disgust"],
                            //    fear = (double)p["fear"],
                            //    happiness = (double)p["happiness"],
                            //    neutral = (double)p["neutral"],
                            //    sadness = (double)p["sadness"],
                            //    surprise = (double)p["surprise"]
                            //}
                            //).ToList();
                            //emotion = scores.ToObject<RootObject>();

                            //MemoryStream stream1 = new MemoryStream();
                            //stream1.Position = 0;
                            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
                            //var emotionObject = JsonConvert.DeserializeObject<List<RootObject>>(responseStr);
                            //Debug.WriteLine(emotion.scores.happiness);


                            //ser.WriteObject(stream1, emotion);
                            //RootObject emo = (RootObject)ser.ReadObject(stream1); 
                            //Debug.WriteLine(aaa[0].scores.anger);
                            //Debug.WriteLine("Image was succesfully uploaded to server!!");
                            //Debug.WriteLine(response2);
                            //Emotion = await ResponseMessageToEmotionModel(response).ConfigureAwait(false);
                            // return emotion;
                        }

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

        //Sunartisi gia to Authorize tou xrhsth
        public async Task<JsonResponse> Authorize(string username, string password)
        {

            string tokenaddress = "http://192.168.0.123:3000/Token";
            //var httpClient = new HttpClient();
            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
                //httpClient.BaseAddress.("http://192.168.0.123:3000/Token");
                httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                string requestBody = "grant_type=password&username=" + username + "&password=" + password;
                //HttpContent request = (HttpContent)requestBody;

                var jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(requestBody, Encoding.UTF8);
                var response = await httpClient.PostAsync(tokenaddress, content);
                //string sss = response.Content.ReadAsStringAsync().ToString();
                string jsonresponsestring = await response.Content.ReadAsStringAsync();

                JsonResponse jresponse = JsonConvert.DeserializeObject<JsonResponse>(jsonresponsestring);

                return jresponse;
            }
            
        }

        //sunarthsh gia to upload twn username kai location
        public async Task<string> UploadUserData()
        {
            string url = "http://192.168.0.123:3000/api/upload";

            using (var httpClient = new HttpClient())
            {
                var prefs = Application.Context.GetSharedPreferences("Shared", FileCreationMode.Private);
                string username = prefs.GetString("Username", "");
                string location = prefs.GetString("Location", "");

                string requestbody ="Username:"+username+"Location:"+location;
                var jsonString = JsonConvert.SerializeObject(requestbody);
                var content = new StringContent(requestbody, Encoding.UTF8);

                var response = await httpClient.PostAsync(url, content);

                return null;
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
