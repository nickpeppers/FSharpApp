namespace FSharpApp

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<MainPage>)

    let _editor = base.FindByName<Editor>("SpeechEditor")

    member this.OnSpeakClicked (sender : Object, args : EventArgs ) =
        do DependencyService.Get<ITextToSpeech>().Speak(_editor.Text)

    member this.OnNextClicked (sender : Object, args : EventArgs ) =
        do this.Navigation.PushAsync(TestViewModelPage()) |> ignore