namespace FSharpApp

open Xamarin.Forms

type App() =
    inherit Application()

    do base.MainPage <- NavigationPage(MainPage())