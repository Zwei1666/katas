module PotterKata1.Tests

open System
open PriceCalculator
open FsUnit
open NUnit.Framework

let f = Array.reduce (*)
let trim (x:String) = x.Trim()
let f2 (s:string) =
    let skladniki = s.Split '+'
    let skladniki' = skladniki |> Array.map (fun x -> x.Split '*' |> Array.map trim |> Array.map float) |> Array.map f
    skladniki' |> Array.sum

type HappyTests() =
    [<TestCase("0.0", ([||]:int array), TestName = "0 books cost 0")>]
    [<TestCase("8.0", [|0|], TestName = "1 book costs 8")>]
    [<TestCase("0.95 * 2.0 * 8.0", [|0; 1|], TestName = "2 different books cost 0.95*2*8")>]
    [<TestCase("0.9 * 3.0 * 8.0", [|0; 1; 2|], TestName = "3 different books cost 0.9*3*8")>]
    [<TestCase("0.8 * 4.0 * 8.0", [|0; 1; 2; 3|], TestName = "4 different books cost 0.8*4*8")>]
    [<TestCase("0.75 * 5.0 * 8.0", [|0; 1; 2; 3; 4|], TestName = "5 different books cost 0.75*5*8")>]
    [<TestCase("2.0 * 8.0", [|0; 0|], TestName = "2 same books cost 2*8")>]
    [<TestCase("3.0 * 8.0", [|1; 1; 1|], TestName = "3 same books cost 3*8")>]
    [<TestCase("8 + 8 * 2 * 0.95", [|0; 0; 1|], TestName = "2 same books and 1 different book cost 8+0.95*2*8")>]
    [<TestCase("2 * 8 * 2 * 0.95", [|0; 0; 1; 1|], TestName = "2 same books and 2 same different books cost 2*2*8*0.95")>]
    [<TestCase("8 * 4 * 0.8 + 8 * 2 * 0.95", [|0; 0; 1; 2; 2; 3|], TestName = "4 different books and 2 different books cost 0.8*8*4+0.95*8*2")>]
    [<TestCase("8 + 8 * 5 * 0.75",[|0; 1; 1; 2; 3; 4|], TestName = "5 different books and one book cost 5*8*0.75 + 8")>]
    [<TestCase("2 * 8 * 4 * 0.8", [|0; 0; 1; 1; 2; 2; 3; 4|], TestName = "2*8*4*0.8")>]
    [<TestCase("3 * 8 * 5 * 0.75 + 2 * 8 * 4 * 0.8",
            [|
            0; 0; 0; 0; 0; 
            1; 1; 1; 1; 1;
            2; 2; 2; 2; 
            3; 3; 3; 3; 3; 
            4; 4; 4; 4
            |], TestName = "2*8*4*0.8 + 3*8*5*0.75")>]
    member this.``Should properly compute price of different book sets`` price bookSet  =
        calculatePrice bookSet |> should equal (f2 price)
  
        