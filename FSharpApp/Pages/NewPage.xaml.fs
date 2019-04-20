namespace FSharpApp

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type NewPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<NewPage>)

    let _label = base.FindByName<Label>("_label")

    let Add x y = x + y

    member this.OnButtonClicked (sender : Object, args : EventArgs) =
        let textValue = _label.Text |> int
        let newText = Add textValue 1
        do _label.Text <- newText.ToString()