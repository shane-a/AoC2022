module Main

let d1p1 = AoC2022.Helpers.FileHelpers.readFileGroupByDoubleNewLineToInts("../../../Day1Input.txt")
           |> Seq.map(fun g -> g |> Seq.sum)
           |> Seq.max
           
let d1p2 = AoC2022.Helpers.FileHelpers.readFileGroupByDoubleNewLineToInts("../../../Day1Input.txt")
            |> Seq.map(fun g -> g |> Seq.sum)
            |> Seq.sortDescending
            |> Seq.take 3
            |> Seq.sum
            
let d2p1 = AoC2022.Helpers.FileHelpers.readFileSplitToPairs("../../../Day2Input.txt")
            |> Seq.map(fun pair -> AoC2022.DayHelpers.Day2.calcRoundScore(pair[0], pair[1]))
            |> Seq.sum
            
let d2p2 = AoC2022.Helpers.FileHelpers.readFileSplitToPairs("../../../Day2Input.txt")
            |> Seq.map(fun pair -> [|pair[0]; AoC2022.DayHelpers.Day2.calcRequiredMove(pair[0], pair[1])|])
            |> Seq.map(fun pair -> AoC2022.DayHelpers.Day2.calcRoundScore(pair[0], pair[1]))
            |> Seq.sum
           
printfn $"D1P1: %d{d1p1}"
printfn $"D1P2: %d{d1p2}"

printfn $"D2P1: %d{d2p1}"
printfn $"D2P2: %d{d2p2}"