using System;
using System.Linq;
using FSharpApp.UWP;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(UWPTextToSpeech))]
namespace FSharpApp.UWP
{
    public class UWPTextToSpeech : ITextToSpeech
    {
        MediaElement _mediaElement;
        SpeechSynthesizer _synthesizer;

        public UWPTextToSpeech()
        {
            _mediaElement = new MediaElement();
            _synthesizer = new SpeechSynthesizer();
            var voice = SpeechSynthesizer.AllVoices.Where(v => v.Gender == VoiceGender.Female).FirstOrDefault();
            _synthesizer.Voice = voice;
        }

        public async void Speak(string text)
        {
            var stream = await _synthesizer.SynthesizeTextToStreamAsync(text);
            _mediaElement.SetSource(stream, stream.ContentType);
            _mediaElement.Play();
        }
    }
}