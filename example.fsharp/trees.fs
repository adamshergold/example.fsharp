namespace Example.FSharp

open System

module Trees =

    type INode<'T when 'T :> IComparable> =
        abstract Key : 'T with get
        abstract Left : INode<'T> option with get
        abstract Right : INode<'T> option with get
        
    type ITree<'T when 'T :> IComparable> = 
        abstract Root : INode<'T> option with get
        
    type Node<'T when 'T :> IComparable>( k, left, right ) =
        member val Key = k
        member val Left = left
        member val Right = right
    with
        static member Make( k ) = 
            new Node<_>( k, None, None ) :> INode<_>
            
        static member Make( k, left, right ) = 
            new Node<_>( k, Some left, Some right ) :> INode<_>

        static member Make( k, left ) = 
            new Node<_>( k, Some left, None ) :> INode<_>
            
        interface INode<'T>
            with
                member this.Key = this.Key
                member this.Left = this.Left
                member this.Right = this.Right    
                
    type Tree<'T when 'T :> IComparable>( root ) = 
        member val Root = root 
    with
        static member Make() = 
            new Tree<_>( None ) :> ITree<_>
            
        static member Make( root ) = 
            new Tree<_>( Some root ) :> ITree<_>
            
        interface ITree<'T>
            with 
                member this.Root = this.Root      
                
    let Depth (t:ITree<_>) =
    
        let rec impl (node:INode<_> option) =
         
            match node with 
            | Some node ->
                1 +  max (impl node.Left) (impl node.Right)
            | None ->
                0
            
        impl t.Root 
        
        
    module Printing =
    
        type Point = 
            {
                X : int
                Y : int
            }
            static member Make( x, y ) = { X = x; Y = y }
            
        type Item = 
            { 
                P : Point
                V : string
            }
            static member Make( x, y, v ) = { P = Point.Make(x,y); V = v } 
            static member Make( p, v ) = { P = p; V = v }
            
        let ItemWidth = 1 
       
        let TotalWidth (t:ITree<_>) = 
            (ItemWidth + 1 ) * (int)(System.Math.Pow(2.0,(float)((Depth t)-1))) - 1
    
        let TotalHeight (t:ITree<_>) = 
        
            let gaps =
                seq { 0 .. Depth t } |> Seq.map ( fun i -> System.Math.Pow(2.0,(float)i) ) |> Seq.sum 
        
            (int)gaps + Depth t 
                             
        let Lines (t:ITree<_>) = 

            let totalWidth = 
                TotalWidth t
            
            let totalHeight = 
                TotalHeight t 
             
            let depth = 
                Depth t 
                   
            let gap (level:int) = 
                (int)(System.Math.Pow( 2.0, (float)(depth-level-2)))
                               
            let leftLine (p:Point) (level:int) = 
                seq { 1 .. (gap level) } 
                |> Seq.map ( fun i -> 
                    Item.Make(p.X-i,p.Y+i,"/") )

            let rightLine (p:Point) (level:int) = 
                seq { 1 .. (gap level) } 
                |> Seq.map ( fun i -> 
                    Item.Make(p.X+i,p.Y+i,@"\") )
                
            let nextLeftRoot (p:Point) (level:int) = 
                Point.Make(p.X/2,p.Y+1+gap level)

            let nextRightRoot (p:Point) (level:int) = 
                Point.Make(p.X+p.X/2,p.Y+1+gap level)
                                        
            let rec impl (node:INode<_>) (root:Point) (level:int) =
                seq {
                    yield Item.Make(root,node.Key.ToString())
                    if node.Left.IsSome then 
                        yield! leftLine root level
                        yield! impl node.Left.Value (nextLeftRoot root level) (level+1)
                    if node.Right.IsSome then 
                        yield! rightLine root level
                        yield! impl node.Right.Value (nextRightRoot root level) (level+1)                        
                }
               
            let root = 
                Point.Make(totalWidth/2,0)
            
            let items = 
                Seq.toArray <| match t.Root with | Some node -> impl node root 0 | None -> Seq.empty 
                
            let itemsToString (items:seq<Item>) =
                let cs = Array.init totalWidth ( fun _ -> ' ' )
                items |> Seq.iter ( fun item ->
                    for i = 0 to item.V.Length-1 do
                        cs.[item.P.X+i] <- item.V.Chars(i)  )
                String(cs)
                
            let lines = 
                seq { 0 .. totalHeight }
                |> Seq.map ( fun h ->
                    items 
                    |> Array.filter ( fun i -> i.P.Y = h )
                    |> itemsToString )

            Seq.append 
                (seq {
                    yield sprintf "Depth=%d" depth
                    yield sprintf "TotalWidth=%d" totalWidth
                    yield sprintf "TotalHeight=%d" totalHeight
                    yield sprintf "gap 0 =%d" (gap 0)
                    yield sprintf "gap 1 =%d" (gap 1)
                    yield sprintf "gap 2 =%d" (gap 2)
                     
                })                
                lines 
                    
                                                   