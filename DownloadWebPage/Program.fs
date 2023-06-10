open System.Net.Http
open System.IO

printfn "Download a web page"

let fetchUrl (url : string) =
    let client = new HttpClient()
    client.GetStreamAsync(url) |> Async.AwaitTask

let printStreamContent (stream : Stream) =
    use reader = new StreamReader(stream)
    while not reader.EndOfStream do
        printfn "%s" (reader.ReadLine())
    done
    printfn

let urls = ["https://rioil.dev";"https://rioil.net"]
urls
    |> List.map fetchUrl
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Array.map printStreamContent
    |> ignore