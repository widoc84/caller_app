using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Content;

namespace App2.Droid
{
    [Activity(Label = "App2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity, TextView.IOnClickListener
    {
        EditText userMsg, userNum;
        Button smsBut, callBut;
        string no = "";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            userMsg = (EditText)FindViewById(Resource.Id.msg);
            userNum = (EditText)FindViewById(Resource.Id.number);
            smsBut = (Button)FindViewById(Resource.Id.sms);
            callBut = (Button)FindViewById(Resource.Id.call);
            smsBut.SetOnClickListener(this);
            callBut.SetOnClickListener(this);
        }
        public void initialize()
        {

        }
        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.sms:
                    if (!(userNum.Text.ToString().Equals("")) && !(userMsg.Text.ToString().Equals("")))
                    {
                        no = userNum.Text.ToString();
                        string userMessage = userMsg.Text.ToString();
                        SmsManager smManager = SmsManager.Default;
                        smManager.SendTextMessage(no, null, userMessage, null, null);
                    }
                    else
                    {
                        Toast.MakeText(this, "Empty Fields", ToastLength.Short).Show();
                    }
                    break;
                case Resource.Id.call:
                    if (!userNum.Text.ToString().Equals(""))
                    {
                        no = userNum.Text.ToString();
                        Intent callIntent = new Intent(Intent.ActionCall);
                        callIntent.SetData(Android.Net.Uri.Parse("tel:" + no));
                        StartActivity(callIntent);
                    }
                    break;
            }
        }
    }
}