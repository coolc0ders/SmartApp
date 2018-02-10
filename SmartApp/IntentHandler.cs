using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SmartApp
{
    class IntentHandler
    {
        [IntentHandler(0.5, Name = "")]
        public async void IdentifyObstacle(LuisResult result, object context)
        {

        }
        [IntentHandler(0.5, Name = "None")]
        public void None(LuisResult result, object context)
        {
            (context as MainActivity).Speak("Sory, but I didn't understand what you meant.");
        }
        [IntentHandler(0.5, Name = "")]
        public void SetPictures(LuisResult result, object context)
        {
        }
    }
}