using Android.Speech.Tts;
using FSharpApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidTextToSpeech))]
namespace FSharpApp.Droid
{
    public class AndroidTextToSpeech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speaker;
        string _toSpeak;

        public void Speak(string text)
        {
            _toSpeak = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(MainActivity.Instance, this);
            }
            else
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}