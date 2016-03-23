module TennisKata2.Engine

type Player = 
    |PlayerA 
    |PlayerB

type Points =
    |Love
    |Fifteen
    |Thirty
    |Forty
    |Game

type ScoreA = Points
type ScoreB = Points
type Score = ScoreA * ScoreB


let addPoint point =
    match point with
    |Love -> Fifteen
    |Fifteen -> Thirty
    |Thirty -> Forty
    |Forty -> Game
    |Game -> failwith "Can't add point to Game"

let addPoints ((scoreA, scoreB):Score) scoringPlayer :Score =
    match scoringPlayer with
    | PlayerA -> (addPoint scoreA, scoreB)
    | PlayerB -> (scoreA, addPoint scoreB)

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

let startState:GameState = NormalState (Love,Love)

//transitions
let normalStateTransition nextPoint (normalData:NormalData) =
    let newScore = nextPoint |> addPoints normalData
    match newScore with
    | (a, _) when a = Game -> WinState PlayerA
    | (_, b) when b = Game -> WinState PlayerB
    | (a, b) when a = Forty && b = Forty -> DeuceState
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
