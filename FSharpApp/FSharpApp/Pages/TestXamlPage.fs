namespace FSharpApp

open System
open System.Linq
open Xamarin.Forms
open Xamarin.Forms.Xaml
open System.Collections.ObjectModel

type TestXamlPage() as this =
    inherit ContentPage()

    do base.LoadFromXaml(typeof<TestXamlPage>) |> ignore
    let _listView = base.FindByName<ListView>("ListView")
    let _removeButton = base.FindByName<Button>("RemoveButton")
    let _backButton = base.FindByName<Button>("BackButton")

    let peopleList = new ObservableCollection<TestViewModel>()
    let AddPeople() =
        for i = 0 to 100 do 
            peopleList.Add(new TestViewModel(Id=i, Text="This is text"))

    do AddPeople()
    do _listView.ItemsSource <- peopleList

    let backHandler = new EventHandler( fun sender e -> do this.Navigation.PopAsync() |> ignore)
    do _backButton.Clicked.AddHandler(backHandler)

    let removeHandler = new EventHandler( fun sender e -> do peopleList.Remove(peopleList.LastOrDefault()) |> ignore)
    do _removeButton.Clicked.AddHandler(removeHandler)