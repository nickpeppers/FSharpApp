namespace FSharpApp

open System.ComponentModel

type BaseViewModel() =
    let propertyChanged = Event<PropertyChangedEventHandler,  PropertyChangedEventArgs>()

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = propertyChanged.Publish
    
    member self.OnPropertyChanged name =
        propertyChanged.Trigger(self, PropertyChangedEventArgs(name))