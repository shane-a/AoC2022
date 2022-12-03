module AoC2022.DayHelpers.Day2


let calcRoundScore (opp : string, me : string) = match (opp, me) with
                                                    | ("A", "X") -> 3
                                                    | ("A", "Y") -> 6
                                                    | ("A", "Z") -> 0
                                                    | ("B", "X") -> 0
                                                    | ("B", "Y") -> 3
                                                    | ("B", "Z") -> 6
                                                    | ("C", "X") -> 6
                                                    | ("C", "Y") -> 0
                                                    | ("C", "Z") -> 3
                                                + match me with
                                                    | "X" -> 1
                                                    | "Y" -> 2
                                                    | "Z" -> 3
                                                    
let calcRequiredMove (opp: string, result: string) = match (opp, result) with
                                                        | ("A", "X") -> "Z"
                                                        | ("A", "Y") -> "X"
                                                        | ("A", "Z") -> "Y"
                                                        | ("B", "X") -> "X"
                                                        | ("B", "Y") -> "Y"
                                                        | ("B", "Z") -> "Z"
                                                        | ("C", "X") -> "Y"
                                                        | ("C", "Y") -> "Z"
                                                        | ("C", "Z") -> "X"