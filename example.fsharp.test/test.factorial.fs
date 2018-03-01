namespace Example.FSharp.Test

open NUnit.Framework

open Example.FSharp 

[<TestFixture>]
module FactorialTests =

    let impl = Example.FSharp.Factorial.TR
    
    [<Test>]
    let ``Simple-0`` () = 
        Assert.AreEqual( 0, impl 0 )
        
    [<Test>]
    let ``Simple-1`` () = 
        let v = impl 1         
        printf "v=%d" v 
        Assert.AreEqual(1,v)                
                
    [<Test>]
    let ``Simple-5`` () = 
        let v = impl 5
        printf "v=%d" v
        Assert.AreEqual( 5*4*3*2, v )              