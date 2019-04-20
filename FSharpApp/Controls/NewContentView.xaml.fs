namespace FSharpApp.Controls

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type NewContentView() =
    inherit ContentView()
    let _ = base.LoadFromXaml(typeof<NewContentView>)

    let _label = base.FindByName<Label>("_label")

    let Add x y = x + y

    member this.OnButtonClicked (sender : Object, args : EventArgs) =
        let textValue = _label.Text |> int
        let newText = Add textValue 1
        do _label.Text <- newText.ToString()