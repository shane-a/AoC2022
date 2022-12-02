module AoC2022.Helpers.FileHelpers

open System
open System.IO

let readFileGroupByDoubleNewLineToInts filename = File.ReadAllText(filename).Split("\n\n", StringSplitOptions.TrimEntries)
                                                |> Array.map(fun s -> s.Split("\n") |> Array.map (fun i -> i |> int))

