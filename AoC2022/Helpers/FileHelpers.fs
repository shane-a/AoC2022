module AoC2022.Helpers.FileHelpers

open System
open System.IO

let readFileByLine filename = File.ReadAllText(filename).Split("\n", StringSplitOptions.TrimEntries)

let readFileSplitOnDoubleNewLine filename = File.ReadAllText(filename).Split("\n\n")

let readFileGroupByDoubleNewLineToInts filename = readFileSplitOnDoubleNewLine filename
                                                |> Array.map(fun s -> s.Split("\n") |> Array.map (fun i -> i |> int))

let readFileSplitToPairs filename = readFileByLine filename
                                    |> Array.map(fun s -> s.Split(" ", StringSplitOptions.TrimEntries))
                                                

