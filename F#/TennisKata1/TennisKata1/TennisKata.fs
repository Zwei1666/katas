module TennisKata

type Player = 
    |PlayerA 
    |PlayerB

type Points =
    |Love
    |Fifteen
    |Thirty
    |Forty
    |Game

type Score =
    {
        PlayerA:Points
        PlayerB:Points
    }

let addPoint point =
    match point with
    |Love -> Fifteen
    |Fifteen -> Thirty
    |Thirty -> Forty
    |Forty -> Game
    |Game -> failwith "Can't add point to Game"

let addPoints score scoringPlayer =
    match scoringPlayer with
    | PlayerA -> {score with PlayerA = addPoint score.PlayerA}
    | PlayerB -> {score with PlayerB = addPoint score.PlayerB}

// state data
type AdvantageData = Player
type WinData = Player
type NormalData = Score

//states
type GameState =
    |NormalState of NormalData
    |AdvantageState of AdvantageData
    |DeuceState
    |WinState of WinData

let startState = NormalState {PlayerA=Love; PlayerB=Love}

//transitions
let normalStateTransition nextPoint (normalData:NormalData) =
    let newScore = nextPoint |> addPoints normalData
    match newScore with
    | s when s.PlayerA = Game -> WinState PlayerA
    | s when s.PlayerB = Game -> WinState PlayerB
    | s when s.PlayerA = Forty && s.PlayerB = Forty -> DeuceState
    | s -> NormalState s

let deuceStateTransition (nextPoint:Player) = nextPoint |> AdvantageState

let advantageStateTransition nextPoint (advantageData:AdvantageData) =
    match nextPoint with
    | winner when winner = (advantageData:Player)  -> WinState winner
    | _ -> DeuceState

let winStateTransition winData = WinState winData

let run getNextPoint =
    let rec nextState state =
        match getNextPoint() with
        | Some nextPoint ->
                match state with
                |NormalState nd     -> normalStateTransition nextPoint nd
                |DeuceState         -> deuceStateTransition nextPoint
                |AdvantageState ad  -> advantageStateTransition nextPoint ad
                |WinState wd         -> winStateTransition wd
                |> nextState
        | None -> state
    startState |> nextState 