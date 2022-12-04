module AoC2022.DayHelpers.Day3

let splitStringInHalf (input: string) = (input.Substring(0, (input.Length/2)), input.Substring(input.Length/2) )

let getItemScore (input: char) = match input with
                                | tmp when (tmp |> int) >= 97 -> (tmp |> int) - 96
                                | tmp when (tmp |> int) >= 65 -> (tmp |> int) - 38