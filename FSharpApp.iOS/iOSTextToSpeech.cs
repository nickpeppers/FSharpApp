using AVFoundation;
using FSharpApp.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSTextToSpeech))]
namespace FSharpApp.iOS
{
    public class iOSTextToSpeech : ITextToSpeech
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.DefaultSpeechRate,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 1f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}