﻿namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics
open Microsoft.CodeAnalysis


[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type SolarSystemNeighboursBenchmark()=
    
    

    [<Params(KnownSystems.adirain, KnownSystems.heild, KnownSystems.jita, KnownSystems.avenod, KnownSystems.thera)>]
    member val SolarSystemId = 0 with get, set
    
    [<Params(1, 2, 3, 4, 5)>]
    member val Depth = 0 with get, set

    [<Benchmark>]
    member this.GetSystemNeighbours() =
        let sys = EsiStatics.SolarSystems.byId this.SolarSystemId |> Option.get
        
        this.Depth |> UniverseExtensions.Neighbours sys |> List.ofSeq

        
        
        

