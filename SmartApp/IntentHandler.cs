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
using Microsoft.Cognitive.LUIS;

namespace SmartApp
{
    class IntentHandler
    {
        [IntentHandler(0.5, Name = "OnTheLight")]
        public async void IdentifyObstacle(LuisResult result, object context)
        {
            var activity = context as MainActivity;
            activity.WriteInterpretation("The light was turned on.");
        }
        [IntentHandler(0.5, Name = "None")]
        public void None(LuisResult result, object context)
        {
            var activity = context as MainActivity;
            activity.WriteInterpretation("I couldn't understand you.");
        }
        [IntentHandler(0.5, Name = "OffTheLight")]
        public void SetPictures(LuisResult result, object context)
        {
            var activity = context as MainActivity;
            activity.WriteInterpretation("The light was turned off.");
        }
    }
}