namespace Example.FSharp.Test

open NUnit.Framework

open Example.FSharp.Sorting

[<TestFixture>]
module QuickSortTests =
    
    [<Test>]
    let ``Empty`` () = 
        Assert.AreEqual( Array.empty, QuickSort.Sort Array.empty )
        
    [<Test>]
    let ``Simple-1`` () = 
        Assert.AreEqual( [| 1 |], QuickSort.Sort [| 1 |] )
         
    [<Test>]
    let ``Simple-1-2-3`` () = 
        Assert.AreEqual( [| 1; 2; 3 |], QuickSort.Sort [| 1; 2; 3 |] )
         
    [<Test>]
    let ``Simple-3-2-1`` () = 
        Assert.AreEqual( [| 1; 2; 3 |], QuickSort.Sort [| 3; 2; 1 |] )
         
    [<Test>]
    let ``Simple-4-3-2-1`` () = 
        Assert.AreEqual( [| 1; 2; 3; 4 |], QuickSort.Sort [| 4; 3; 2; 1 |] )
         
    [<Test>]
    let ``Simple-1-2-3-4`` () = 
        Assert.AreEqual( [| 1; 2; 3; 4 |], QuickSort.Sort [| 1; 2; 3; 4 |] )
         