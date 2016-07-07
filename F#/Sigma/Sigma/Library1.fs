namespace Sigma

module Core =
    open Microsoft.FSharp.Core

    let sigma(start:^a) (stop:^a) (f : (^a -> ^b) ) : ^b =
        seq {start .. stop} |> Seq.map f |> Seq.sum


module CoreTests =
    open Xunit

    [<Fact>]
    let sigma () = 
    2
    ()

