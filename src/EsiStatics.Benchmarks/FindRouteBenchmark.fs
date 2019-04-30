namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics

[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
type FindRouteBenchmark()=
    
    
    [<Params(30005003, 30002089, 30013489)>]
    member val StartSolarSystemId = 0 with get, set

    
    [<Params(30000142)>]
    member val FinishSystemId = 0 with get, set

    [<Benchmark>]
    member this.FindRoute() =
        let start = this.StartSolarSystemId |> SolarSystems.byId |> Option.get
        let finish = this.FinishSystemId |> SolarSystems.byId |> Option.get

        let route = (start, finish) |> Navigation.findRoute Navigation.euclideanSystemDistance
        
        route |> Seq.length

