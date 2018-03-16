namespace Example.FSharp

module Puzzles =

    let BinaryGap (n:int32) =
    
        n <<< 1 |> ignore // shift high order-bit
        
        let mask : uint32 = System.Ma 
        
        let rec impl (max:int32,cmax:int32,i,started) =
        
            if i > 31 then
                System.Math.Max(max,cmax)
            else
                let bt = (mask >>> i) &&& n
                //let bt = n <<< i
                
                if bt = 0 && started then
                    impl (max,cmax+1,i+1,started) 
                elif bt = 1 then
                    impl (System.Math.Max(max,cmax),0,i+1,true)
                else
                    impl (max,cmax,i+1,started)        
            
            
        impl (0,0,1,false)    