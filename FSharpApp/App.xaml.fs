namespace FSharpApp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type App() =
    inherit Application()
    let _ = base.LoadFromXaml(typeof<App>)

    do base.MainPage <- NavigationPage(MainPage())