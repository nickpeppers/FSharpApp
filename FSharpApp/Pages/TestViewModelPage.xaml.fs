namespace FSharpApp

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml
open System.Collections.ObjectModel

type TestViewModelPage() as this =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<TestViewModelPage>)

    let _listView = base.FindByName<ListView>("ListView")
    let _removeButton = base.FindByName<Button>("RemoveButton")
    let _backButton = base.FindByName<Button>("BackButton")

    let viewModelList = ObservableCollection<TestViewModel>()
    let AddItems x =
        for i = 0 to x do 
            viewModelList.Add(TestViewModel(Id=i, Text="This is text"))

    do AddItems 100
    do _listView.ItemsSource <- viewModelList

    let backHandler = EventHandler(fun sender e -> do this.Navigation.PopAsync() |> ignore)
    do _backButton.Clicked.AddHandler(backHandler)

    let removeHandler = EventHandler(fun sender e -> 
        try
            let selectedItem = _listView.SelectedItem :?> TestViewModel
            do viewModelList.Remove(selectedItem) |> ignore
        with | exc ->
            printf "%s\n Exception" exc.Message)

    do _removeButton.Clicked.AddHandler(removeHandler)