namespace Example.FSharp

module Factorial = 

    let Simple (n:int) =
    
        let rec impl n = 
            if n < 0 then 
                failwithf "Invalid argument: %d" n
            elif n = 0 then 
                0
            elif n = 1 then 
                1
            else 
                n * (impl (n-1))
                
        impl n
        

    let TR (n:int) = 
    
        let rec impl (n,acc) = 
        
            if n < 0 then
                failwithf "Invalid argument: %d" n
            elif n = 0 then
                0
            elif n = 1 then 
                acc 
            else 
                impl (n-1,n*acc)
                
        impl (n,1) 
                 
                    