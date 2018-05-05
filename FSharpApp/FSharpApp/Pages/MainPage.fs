namespace FSharpApp

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()

    let testLabel1 = Label ( Text = "F# Test Xamarin.Forms", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center)
    let testLabel2 = Label ( Text = "Multiple Labels in a StackLayout", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center)
    let stackLayout = StackLayout(VerticalOptions = LayoutOptions.Center, HorizontalOptions= LayoutOptions.Center)
    do stackLayout.Children.Add(testLabel1)
    do stackLayout.Children.Add(testLabel2)

    do base.Content <- stackLayout

    member this.OnButtonClick (sender : Object, args : EventArgs)  = 
           do this.Navigation.PushAsync(MainPage()) |> ignore

    override this.OnAppearing() =
        do base.OnAppearing()
        let newLabel = Label ( Text = "Label added in OnAppearing()", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center)
        do stackLayout.Children.Add(newLabel)
        let button = Button(Text="Navigate to XamlPage")
        button.Clicked.Add(fun _ ->
            do this.Navigation.PushAsync(MainPage()) |> ignore)
        do stackLayout.Children.Add(button)