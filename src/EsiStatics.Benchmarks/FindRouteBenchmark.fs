﻿namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics

[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
type FindRouteBenchmark()=
    
    
    [<Params(KnownSystems.adirain, KnownSystems.heild, KnownSystems.avenod, KnownSystems.deepari, KnownSystems.``QX-LIJ``, KnownSystems.``0OYZ-G``)>]
    member val StartSolarSystemId = 0 with get, set

    
    [<Params(KnownSystems.jita)>]
    member val FinishSystemId = 0 with get, set

    [<Benchmark>]
    member this.FindRoute() =
        let start = this.StartSolarSystemId |> SolarSystems.byId |> Option.get
        let finish = this.FinishSystemId |> SolarSystems.byId |> Option.get

        let route = (start, finish) |> Navigation.findRoute Navigation.euclideanSystemDistance
        
        route |> Seq.length
