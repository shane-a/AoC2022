﻿module Main

open System
open System.IO

let d1p1 () = AoC2022.Helpers.FileHelpers.readFileGroupByDoubleNewLineToInts("../../../Day1Input.txt")
           |> Seq.map(fun g -> g |> Seq.sum)
           |> Seq.max
           |> string
           
let d1p2 () = AoC2022.Helpers.FileHelpers.readFileGroupByDoubleNewLineToInts("../../../Day1Input.txt")
            |> Seq.map(fun g -> g |> Seq.sum)
            |> Seq.sortDescending
            |> Seq.take 3
            |> Seq.sum
            |> string
            
let d2p1 () = AoC2022.Helpers.FileHelpers.readFileSplitToPairs("../../../Day2Input.txt")
            |> Seq.map(fun pair -> AoC2022.DayHelpers.Day2.calcRoundScore(pair[0], pair[1]))
            |> Seq.sum
            |> string
            
let d2p2 () = AoC2022.Helpers.FileHelpers.readFileSplitToPairs("../../../Day2Input.txt")
            |> Seq.map(fun pair -> [|pair[0]; AoC2022.DayHelpers.Day2.calcRequiredMove(pair[0], pair[1])|])
            |> Seq.map(fun pair -> AoC2022.DayHelpers.Day2.calcRoundScore(pair[0], pair[1]))
            |> Seq.sum
            |> string
            
let d3p1 () = AoC2022.Helpers.FileHelpers.readFileByLine("../../../Day3Input.txt")
            |> Seq.map(AoC2022.DayHelpers.Day3.splitStringInHalf)
            |> Seq.map(fun (a,b) -> Set.intersect (Set.ofArray(a.ToCharArray())) (Set.ofArray(b.ToCharArray())))
            |> Seq.map(fun s -> Set.toArray(s)[0])
            |> Seq.map(AoC2022.DayHelpers.Day3.getItemScore)
            |> Seq.sum
            |> string
            
let d3p2 () = AoC2022.Helpers.FileHelpers.readFileByLine("../../../Day3Input.txt")
            |> Array.chunkBySize 3
            |> Seq.map(fun set -> set |> Seq.map(fun bp -> bp.ToCharArray() |> Set.ofArray) |> Set.intersectMany )
            |> Seq.map(fun s -> Set.toArray(s)[0])
            |> Seq.map(AoC2022.DayHelpers.Day3.getItemScore)
            |> Seq.sum
            |> string

let d4p1 () = AoC2022.Helpers.FileHelpers.readFileByLine("../../../Day4Input.txt")
            |> Seq.map (fun i -> i.Split(','))
            |> Seq.map (fun i -> i |> Seq.map(fun j -> j.Split('-') |> Seq.map(fun k -> k |> int) |> Array.ofSeq))
            |> Seq.map Array.ofSeq
            |> Seq.filter(fun i -> (i[0][0] <= i[1][0] && i[0][1] >= i[1][1]) || (i[0][0] >= i[1][0] && i[0][1] <= i[1][1]) )
            |> Seq.length
            |> string
            
let d4p2 () = AoC2022.Helpers.FileHelpers.readFileByLine("../../../Day4Input.txt")
            |> Seq.map (fun i -> i.Split(','))
            |> Seq.map (fun i -> i |> Seq.map(fun j -> j.Split('-') |> Seq.map(fun k -> k |> int) |> Array.ofSeq))
            |> Seq.map Array.ofSeq
            |> Seq.map(fun i -> [| seq{i[0][0] .. i[0][1]}; seq{i[1][0] .. i[1][1]} |])
            |> Seq.filter(fun i -> Set.intersect (Set.ofSeq(i[0])) (Set.ofSeq(i[1])) |> Set.isEmpty |> not )
            |> Seq.length
            |> string
            
let d5p1 () =
    let input = AoC2022.Helpers.FileHelpers.readFileSplitOnDoubleNewLine("../../../Day5Input.txt")
    let mutable init = AoC2022.DayHelpers.Day5.getInitialState input[0]
    
    input[1].Split("\n")
             |> Seq.iter(fun row -> AoC2022.DayHelpers.Day5.applyRowAction(row, init))
    
    init |> Seq.map(fun s -> s.Head)
         |> Array.ofSeq
         |> String
         
let d5p2 () =
    let input = AoC2022.Helpers.FileHelpers.readFileSplitOnDoubleNewLine("../../../Day5Input.txt")
    let mutable init = AoC2022.DayHelpers.Day5.getInitialState input[0]
    
    input[1].Split("\n")
             |> Seq.iter(fun row -> AoC2022.DayHelpers.Day5.applyRowAction9001(row, init))
    
    init |> Seq.map(fun s -> s.Head)
         |> Array.ofSeq
         |> String
         
let d6p1 () = File.ReadAllText("../../../Day6Input.txt")
            |> Seq.windowed 4
            |> Seq.findIndex (fun elem -> (elem |> Seq.distinct |> Seq.length) = 4)
            |> (fun i -> i + 4)
            |> string

let d6p2 () = File.ReadAllText("../../../Day6Input.txt")
            |> Seq.windowed 14
            |> Seq.findIndex (fun elem -> (elem |> Seq.distinct |> Seq.length) = 14)
            |> (fun i -> i + 14)
            |> string
                

[<EntryPoint>]
let main _ =
    printf $"Which day do you want to run? "
    
    let input = Console.ReadLine()
                |> int
    let p1, p2 = match input with
                    | 1 -> (d1p1(), d1p2())
                    | 2 -> (d2p1(), d2p2())
                    | 3 -> (d3p1(), d3p2())
                    | 4 -> (d4p1(), d4p2())
                    | 5 -> (d5p1(), d5p2())
                    | 6 -> (d6p1(), d6p2())
                    | _ -> raise (InvalidOperationException($"Day %d{input} has no functions"))
    
    printfn $"Day %d{input}\nPart 1: %s{p1}\nPart 2: %s{p2}"
    
    0