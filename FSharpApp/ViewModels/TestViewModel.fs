namespace FSharpApp

type TestViewModel() = 
    inherit BaseViewModel()

    let mutable _id = 0
    let mutable _text = "Text"

    member this.Text
        with get() = _text
        and set value =
            _text <- value
            base.OnPropertyChanged "Text"
     
     member this.Id
        with get() = _id
        and set value =
            _id <- value
            base.OnPropertyChanged "Id"