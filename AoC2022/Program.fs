module Main

let d1p1 = AoC2022.Helpers.FileHelpers.readFileGroupByDoubleNewLineToInts("../../../Day1Input.txt")
           |> Seq.map(fun g -> g |> Seq.sum)
           |> Seq.max
           
let d1p2 = AoC2022.Helpers.FileHelpers.readFileGroupByDoubleNewLineToInts("../../../Day1Input.txt")
            |> Seq.map(fun g -> g |> Seq.sum)
            |> Seq.sortDescending
            |> Seq.take 3
            |> Seq.sum
           
printfn $"D1P1: %d{d1p1}"
printfn $"D1P2: %d{d1p2}"