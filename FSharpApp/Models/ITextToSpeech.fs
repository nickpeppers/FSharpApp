namespace FSharpApp

type ITextToSpeech =
    abstract member Speak : string -> unit