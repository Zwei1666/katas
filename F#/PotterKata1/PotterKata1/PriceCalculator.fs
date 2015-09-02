module PotterKata1.PriceCalculator

let baseBookPrice = 8.0
let disscount numOfDistinctBooks = 
        match numOfDistinctBooks with
        |2 -> 0.95
        |3 -> 0.9
        |4 -> 0.8
        |5 -> 0.75
        |_ -> 1.0

let replace3and5ForTwo4 (set:(int*int) seq) =
    let findOrDefault x set =
     match set |> Seq.tryFind (fun (x',_) -> x' = x) with
        |Some (_, y) -> y
        |None -> 0
    let numberOf3 = set |> findOrDefault 3
    let numberOf4 = set |> findOrDefault 4
    let numberOf5 = set |> findOrDefault 5
    let numberOfReplacements = min numberOf3 numberOf5
    set |> Seq.filter (fun (x,_) -> x<3 ||x >5) 
    |> Seq.append [
        (3, numberOf3 - numberOfReplacements)
        (4, numberOf4+2*numberOfReplacements)
        (5, numberOf5-numberOfReplacements)]

let calculatePrice(books:array<int>) =
    let distinctBooksSetPrice cardinality = float cardinality * baseBookPrice * disscount cardinality 
    let countsOfDistinctBooks = books |> Seq.countBy (fun x -> x) |> Seq.map snd  |> Seq.append [0] |> Seq.sortBy (fun x -> -x) 
    let numOfSetsWithDifferentCardinality = countsOfDistinctBooks |> Seq.pairwise |> Seq.mapi (fun i (x, y) -> (i+1, x-y) )
    let opimizedNumOfSetsWithDifferentCardinality = replace3and5ForTwo4 numOfSetsWithDifferentCardinality
    opimizedNumOfSetsWithDifferentCardinality |> Seq.map (fun (setCardinality, numOfSets)->float numOfSets * distinctBooksSetPrice setCardinality) |> Seq.sum
