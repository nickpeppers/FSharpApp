namespace FSharpApp

open System
open System.Linq;
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<MainPage>)

    let _editor = base.FindByName<Editor>("SpeechEditor")
    let _outputLabel = base.FindByName<Label>("OutputLabel")

    let Add x y = x + y
    let Subtract x y = x - y
    let Multiply x y = x * y

    member this.OnRunClicked (sender : Object, args : EventArgs) =
        let text = _editor.Text
        let firstNumber = text.Split(' ').FirstOrDefault() |> int
        let secondNumber = text.Split(' ').LastOrDefault() |> int
        let newText = Add firstNumber secondNumber 
        do _outputLabel.Text <- newText.ToString()

    member this.OnSpeakClicked (sender : Object, args : EventArgs ) =
        do DependencyService.Get<ITextToSpeech>().Speak(_editor.Text)

    member this.OnNextClicked (sender : Object, args : EventArgs ) =
        do this.Navigation.PushAsync(TestViewModelPage()) |> ignore