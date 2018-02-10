using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Speech;
using Android.Runtime;

namespace SmartApp
{
    [Activity(Label = "SmartApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private bool isRecording;
        private readonly int VOICE = 10;
        private Button recButton;
        private TextView textView;
        private string _userCommand;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            recButton = FindViewById<Button>(Resource.Id.button1);
            textView = FindViewById<TextView>(Resource.Id.textView1);

            recButton.Click += RecButton_Click;
        }

        public void WriteInterpretation(string msg)
        {
            textView.Text = msg;
        }

        private void RecButton_Click(object sender, System.EventArgs e)
        {// change the text on the button
            recButton.Text = "End Recording";
            isRecording = !isRecording;
            if (isRecording)
            {
                // create intent and start the activity
                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

                // put a message on the modal dialog
                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");

                // end speech if 1.5 secs have passed
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);

                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
                StartActivityForResult(voiceIntent, VOICE);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == VOICE)
            {
                if (resultCode == Result.Ok)
                {
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if (matches.Count != 0)
                    {
                        _userCommand = matches[0];
                    }
                    else
                    {
                        //Speech not recognized
                    }
                }

                base.OnActivityResult(requestCode, resultCode, data);
            }
        } 
    }
}

