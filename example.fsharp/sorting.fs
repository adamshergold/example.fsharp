namespace Example.FSharp

open System

module Sorting = 

    module QuickSort =
    
        let Sort<'T when 'T :> IComparable> (vs:'T[]) =
        
            let res = 
                Array.init vs.Length ( fun idx -> vs.[idx])
            
            let rec impl (lo:int) (hi:int) =
            
                let partition (lo:int) (hi:int) =
                
                    let swap i j = 
                        let t = res.[i]
                        res.[i] <- res.[j]
                        res.[j] <- t 
                        
                    let pv = res.[lo]
                    let mutable m = lo
                    for i = lo to hi do
                        if res.[i].CompareTo(pv) < 0 then 
                            m <- m+1
                            swap m i
                        else
                            ()
                    swap m lo
                    m 
                         
                     
                if lo < hi then
                    let p = partition lo hi
                    impl lo (p-1)
                    impl (p+1) hi 
                else
                    ()
                       
            impl 0 (res.Length-1)
                
            res
        