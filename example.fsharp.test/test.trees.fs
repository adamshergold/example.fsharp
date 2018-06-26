namespace Example.FSharp.Test

open NUnit.Framework

open Example.FSharp.Trees 

[<TestFixture>]
module TreesTests = 

    [<Test>]
    let ``Depth-Empty`` () = 
        let t = Tree.Make()
        Assert.AreEqual( 0, Depth t )

    [<Test>]
    let ``Depth-One-Node`` () =
     
        let t =
            let root = 
                Node.Make(1) 
            Tree.Make(root)
            
        Assert.AreEqual( 1, Depth t )

    [<Test>]
    let ``Print`` () =
     
        let n5 =
         
            let n3 =
                Node<_>.Make(3)
        
            let n6 = 
                Node<_>.Make(6)
                
            Node<_>.Make(5,n3,n6)    
        
        let n7 =
        
            let n8 = 
                Node<_>.Make(8) 
            Node<_>.Make(7,n5,n8) 
            
        let n10 = 
            Node<_>.Make(10,n7)
            
        let t = 
            Tree<_>.Make(n10)
            
        Printing.Lines t
        |> Seq.iter ( fun line ->
            printfn "%s" line ) 
                    
        Assert.Pass()
        
