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

namespace EmotionsX.Droid
{
    public class EmotionsFragment : Fragment
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
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Id.emotionsfragment, container, false);
            return view;
        }
    }
}