﻿using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using System;

namespace Forms9PatchDemo.Droid
{
    //[Activity(Label = "Forms9Patch Demo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //public class MainActivity : FormsAppCompatActivity
    [Activity(Label = "Forms9Patch Demo", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Window.RequestFeature(WindowFeatures.ActionBar);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Forms9Patch.Droid.Settings.Initialize(this);
            LoadApplication(new Forms9PatchDemo.App());

            ActionBar.Hide();
            ActionBar.SetDisplayShowHomeEnabled(false);
            ActionBar.SetHomeButtonEnabled(false);

            FormsGestures.Droid.Settings.TappedThreshold = TimeSpan.FromMilliseconds(100);
        }

        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            System.Diagnostics.Debug.WriteLine("=======================================================================");
            System.Diagnostics.Debug.WriteLine("MainActivity.OnKeyUp[" + keyCode + "] e.Action[" + e.Action + "] e.Characters[" + e.Characters + "] e.DisplayLabel[" + (e.DisplayLabel == 0 ? "" : e.DisplayLabel.ToString()) + "] e.Flags[" + e.Flags + "] e.MetaStates[" + e.MetaState + "] e.Modifiers[" + e.Modifiers + "] e.Unicode[" + (e.UnicodeChar == 0 ? "" : ((char)e.UnicodeChar).ToString()) + "] ");
            var handled = Forms9Patch.Droid.HardwareKeyListener.OnKeyDown(keyCode, e);
            if (handled)
                return true;
            return base.OnKeyDown(keyCode, e);
        }


        public override void OnBackPressed()
        {
            if (Forms9Patch.Popup.SendBackPressed(base.OnBackPressed))
            {
                // do something here if there are some popups in the popup stack
            }
            else
            {
                // do something else if there are not any popups in the popup stack
            }
        }
    }
}



/*
using Android.App;
using Android.Widget;
using Android.OS;

namespace Forms9PatchDemo.Droid
{
    [Activity(Label = "Forms9PatchDemo.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}
*/

