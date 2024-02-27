open System.Text.RegularExpressions

[<EntryPoint>]
let main argv =
    printfn "Simple Calculator"
    printfn "%d tokens" argv.Length

    let digitPattern = new Regex("[+-]?\d+")
    let operatorPattern = new Regex("[+\-*/]")

    let distinguish x =
        if digitPattern.IsMatch x then printfn "%s is a digit" x
        elif operatorPattern.IsMatch x then printfn "%s is an operator" x
        else printfn "%s is a invalid token" x

    let rec parse list =
        match list with
        | [] -> ()
        | first::rest ->
            distinguish first
            parse rest

    let rec calculate x operator y =
        match operator with
        | "+" -> x + y
        | "-" -> x - y
        | "*" -> x * y
        | "/" -> x / y
        | _ -> 0

    //let add2times3 = (+) 2 >> (*) 3
    //printfn "%d" (add2times3 5)

    //let twoToFive = [2;3;4;5]
    //let oneToFive = 1 :: twoToFive
    //let zeroToFive = [0;1] @ twoToFive

    let tokens = ["1";"+";"2";"*";"3"]
    parse tokens
    printf "result: %d" (calculate 2 "+" 3)

    0