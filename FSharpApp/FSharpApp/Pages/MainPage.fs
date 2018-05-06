namespace FSharpApp

open System
open Xamarin.Forms

type MainPage() as this =
    inherit ContentPage()

    let testLabel1 = Label ( Text = "F# Test Xamarin.Forms", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center)
    let testLabel2 = Label ( Text = "Multiple Labels in a StackLayout", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center)
    let stackLayout = StackLayout(VerticalOptions = LayoutOptions.Center, HorizontalOptions= LayoutOptions.Center)
    do stackLayout.Children.Add(testLabel1)
    do stackLayout.Children.Add(testLabel2)

    let button = Button(Text="Navigate to XamlPage")
    do button.Clicked.AddHandler( new EventHandler(fun sender e -> do this.Navigation.PushAsync(TestXamlPage()) |> ignore ))
    do stackLayout.Children.Add(button)

    do base.Content <- stackLayout

    member this.OnButtonClick (sender : Object, args : EventArgs)  = 
           do this.Navigation.PushAsync(MainPage()) |> ignore

    override this.OnAppearing() =
        do base.OnAppearing()