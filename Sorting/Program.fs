// For more information see https://aka.ms/fsharp-console-apps
printfn "Quicksort-like"

let rec quicksort list =
    match list with
    | [] -> []
    | firstElem::otherElements ->
        let smallerElements =
            otherElements
            |> List.filter (fun e -> e < firstElem)
            |> quicksort
        let largerElements =
            otherElements
            |> List.filter (fun e -> e > firstElem)
            |> quicksort
        // combine
        List.concat [smallerElements; [firstElem]; largerElements]

let rec quicksort2 = function
    | [] -> []
    | first::rest ->
        let smaller, larger = List.partition ((>=) first) rest
        List.concat [quicksort2 smaller; [first]; quicksort2 larger]

printfn "quicksort"
printfn "%A" (quicksort [1;5;23;18;9;1;3])
printfn "%A" (quicksort ["1";"2";"23";"18";"33"])
  
printfn "quicksort2"
printfn "%A" (quicksort [1;5;23;18;9;1;3])
printfn "%A" (quicksort ["1";"2";"23";"18";"33"])