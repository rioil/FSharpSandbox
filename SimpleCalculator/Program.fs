let squareFunction x = x * x

[<EntryPoint>]
let main argv =
    printfn "Simple Calculator"
    printfn "%d tokens" argv.Length
    printfn "%d" (squareFunction 5)
    0
