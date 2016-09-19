using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using EmotionsX.Services;
using System.Threading.Tasks;
using EmotionsX.Models;
using Android.Preferences;

namespace EmotionsX.Droid
{
    public class EmotionsFragment : Fragment, View.IOnClickListener
    {       

        public static EmotionsFragment NewInstance()
        {
            EmotionsFragment fragment = new EmotionsFragment();
            fragment.RetainInstance = true;
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
            //var uploadactivity = new Services.UploadService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.Login, container, false);
            var prefs = Application.Context.GetSharedPreferences("Shared", FileCreationMode.Private);
            string username = prefs.GetString("Username", "");
            string location = prefs.GetString("Location", "");

            //EditText editTXT = (EditText)Resource.Id.editText1;
            EditText editUsername = (EditText)view.FindViewById(Resource.Id.editText1); 
            editUsername.SetText(username, TextView.BufferType.Normal);
            EditText editLocation = (EditText)view.FindViewById(Resource.Id.editText3);
            editLocation.SetText(location, TextView.BufferType.Normal);

            
            return view;
        }

        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.button1:
                    //Communicate with my web api and retreive bearer token
                    GetTokenBearer();
                    
                //case Resource.Id.startuploadingbutton:
                //    //uploading to my api
                //    Toast.MakeText(this.Context, "Hello", ToastLength.Long).Show();
                //    break;
                //case Resource.Id.infobutton:
                //    //print a message and stoping the service
                //    EventHandler<DialogClickEventArgs> nullHandler = null;
                //    Activity activity = Activity;
                //    if (activity != null)
                //    {
                //        new AlertDialog.Builder(activity)
                //            .SetMessage("Diploma")
                //            .SetPositiveButton(Android.Resource.String.Ok, nullHandler)
                //            .Show();

                //    }

                    break;
            }
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //View.FindViewById(Resource.Id.startuploadingbutton).SetOnClickListener(this);
            //View.FindViewById(Resource.Id.infobutton).SetOnClickListener(this);
            View.FindViewById(Resource.Id.button1).SetOnClickListener(this);
            

        }

        public async Task<JsonResponse> GetTokenBearer()
        {
            EditText mUsername = (EditText)View.FindViewById(Resource.Id.editText1);
            string musername = mUsername.Text.ToString();

            EditText mPassword = (EditText)View.FindViewById(Resource.Id.editText2);
            string mpassword = mPassword.Text.ToString();

            EditText mLocation = (EditText)View.FindViewById(Resource.Id.editText3);
            string mlocation = mLocation.Text.ToString();
            

            UploadService service = new UploadService();
            var result = await service.Authorize(musername, mpassword);

            
            //edw prepei na ginei h epilogh tou bearer mono kai tou expires
            var acckey = result.access_token.ToString();
            var exprires = result.expires_in.ToString();

            //ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this.Context);
            var prefs = Application.Context.GetSharedPreferences("Shared", FileCreationMode.Private);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("Username", musername);
            editor.PutString("Bearer", acckey);
            editor.PutString("Location", mlocation);
            editor.PutString("Expires", exprires);
            editor.Apply();
            

            if (result != null)
            {
                Toast.MakeText(this.Activity, "Login Success", ToastLength.Long).Show();
                FragmentManager.BeginTransaction().Replace(Resource.Id.fragmentcontainer, CameraFragment.NewInstance()).Commit();
            }
            else
                Toast.MakeText(this.Activity , "Error", ToastLength.Long).Show();

            return result;
        }
    }
}