namespace Example.FSharp

module Fib = 

    let Simple (n:int) = 
        
        let rec impl n = 
            if n < 1 then
                failwithf "Invalid argument: %d" n
            elif n < 3 then
                1
            else
                (impl (n-1)) + (impl (n-2))
            
        impl n
        
    let TR (n:int) =
    
        let rec impl (n,a,b) =
            if n < 1 then   
                failwithf "Invalid argument: %d" n
            elif n = 1 || n = 2 then
                1
            elif n = 3 then   
                a+b
            else
                impl (n-1,a+b,a)
        
        impl (n,1,1)
        
    let Combos (vs:seq<'T>) (n:int) =
    
        let rec impl (n:int) = 
            if n = 1 then 
                vs |> Seq.map Seq.singleton
            else
                let next = impl (n-1)
                vs
                |> Seq.map ( fun v -> 
                    next |> Seq.map ( fun n -> Seq.append (Seq.singleton v) n ) )
                |> Seq.concat  
                
        impl n      
         