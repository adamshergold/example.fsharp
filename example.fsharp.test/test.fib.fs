namespace Example.FSharp.Test

open NUnit.Framework

open Example.FSharp 

[<TestFixture>]
module FibTests =
    open Example.FSharp

    let impl = Example.FSharp.Fib.TR
    
    [<Test>]
    let ``Simple-1`` () = 
        Assert.AreEqual( 1, impl 1 )
        
    [<Test>]
    let ``Simple-2`` () = 
        Assert.AreEqual( 1, impl 2 )

    [<Test>]
    let ``Simple-3`` () = 
        Assert.AreEqual( 2, impl 3 )

    [<Test>]
    let ``Simple-4`` () = 
        Assert.AreEqual( 3, impl 4 )

    [<Test>]
    let ``Simple-5`` () = 
        Assert.AreEqual( 5, impl 5 )


    [<Test>]
    let ``Combos`` () = 
        let vs = [| "A"; "B"; "C" |]
        let r = Fib.Combos vs 3
        r |> Seq.iter ( fun s ->
            printfn "%A" (s |> Array.ofSeq) ) 
            
        Assert.Pass()
         
        
