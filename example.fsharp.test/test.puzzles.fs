namespace Example.FSharp.Test

open NUnit.Framework

open Example.FSharp 

[<TestFixture>]
module PuzzleTests =

    [<Test>]
    let ``BinaryGap-1`` () = 
    
        let bg = Puzzles.BinaryGap 1
        
        Assert.AreEqual( 0, bg )
                      
    [<Test>]
    let ``BinaryGap-40`` () = 
    
        let bg = Puzzles.BinaryGap 40
        
        Assert.AreEqual( 3, bg )
                      