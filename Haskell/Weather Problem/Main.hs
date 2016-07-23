module Main (main) where

import Data.List (sortOn)

type Day = Int
type MaxTemp = Int
type MinTemp = Int

data Entry = Entry Day MaxTemp MinTemp
    deriving  (Show)

parseInput::String -> [Entry]
parseInput input =
       processEntries $ removeStars $ divideIntoWords $ removeSumupEntryAndHeaders $ lines $ input where
           divideIntoWords = (map words)
           removeSumupEntryAndHeaders = init.tail.tail
           processEntries = map (\[day, min, max] -> Entry day min max) . map (map read) . map takeDayMinAndMaxTemp
           takeDayMinAndMaxTemp = take 3
           removeStars = map $ map $ filter (/='*')

getAmplitude::Entry -> Int
getAmplitude (Entry _ max min) = abs  (max - min)

getAmplitudeWithDay::Entry -> (Day, Int)
getAmplitudeWithDay e = (day, getAmplitude e) where
    (Entry day _ _) = e

getDayWithLeastSpread::[Entry] -> Day
getDayWithLeastSpread = fst . minimumOn snd . map getAmplitudeWithDay where
    minimumOn:: ( Ord b) => (a -> b) -> [a] -> a
    minimumOn f = head . sortOn f

main :: IO ()
main = do
    filePath <- getLine
    input <- readFile filePath
    let output = getDayWithLeastSpread $ parseInput $ input
    print output
