module AoC2022.DayHelpers.Day5


let getInitialState (input: string) =
    let initState = input.Split("\n")
                    |> Seq.map(fun s -> s.ToCharArray())
                    |> Array.ofSeq
    let mutable stacks = Array.create 9 List.Empty
    for i = initState.Length - 2 downto 0 do
        if (initState[i][1] <> ' ') then stacks[0] <- initState[i][1] :: stacks[0]
        if (initState[i][5] <> ' ') then stacks[1] <- initState[i][5] :: stacks[1]
        if (initState[i][9] <> ' ') then stacks[2] <- initState[i][9] :: stacks[2]
        if (initState[i][13] <> ' ') then stacks[3] <- initState[i][13] :: stacks[3]
        if (initState[i][17] <> ' ') then stacks[4] <- initState[i][17] :: stacks[4]
        if (initState[i][21] <> ' ') then stacks[5] <- initState[i][21] :: stacks[5]
        if (initState[i][25] <> ' ') then stacks[6] <- initState[i][25] :: stacks[6]
        if (initState[i][29] <> ' ') then stacks[7] <- initState[i][29] :: stacks[7]
        if (initState[i][33] <> ' ') then stacks[8] <- initState[i][33] :: stacks[8]
        
    stacks
    
let applyRowAction (row: string, state: char list[]) =
    let split = row.Split(" ")
    let count, source, dest = split[1] |> int, split[3] |> int, split[5] |> int
    for i = count downto 1 do
        let move = state[source-1].Head
        state[dest-1] <- move :: state[dest-1]
        state[source-1] <- state[source-1].Tail
        
let applyRowAction9001 (row: string, state: char list[]) =
    let split = row.Split(" ")
    let count, source, dest = split[1] |> int, split[3] |> int, split[5] |> int
    let move = state[source-1][..(count-1)]
    state[dest-1] <- move @ state[dest-1]
    state[source-1] <- state[source-1][count..]