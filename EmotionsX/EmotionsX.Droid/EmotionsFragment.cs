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
            View view = inflater.Inflate(Resource.Layout.emotionpage, container, false);
            return view;
        }

        public void OnClick(View v)
        {
            switch (v.Id)
            {
                //case Resource.Id.startuploadingbutton:
                //    //uploading to my api
                //    Toast.MakeText(this.Context, "Hello", ToastLength.Long).Show();
                //    break;
                case Resource.Id.infobutton:
                    //print a message and stoping the service
                    EventHandler<DialogClickEventArgs> nullHandler = null;
                    Activity activity = Activity;
                    if (activity != null)
                    {
                        new AlertDialog.Builder(activity)
                            .SetMessage("Diploma")
                            .SetPositiveButton(Android.Resource.String.Ok, nullHandler)
                            .Show();

                    }

                    break;
            }
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //View.FindViewById(Resource.Id.startuploadingbutton).SetOnClickListener(this);
            View.FindViewById(Resource.Id.infobutton).SetOnClickListener(this);
        }
    }
}