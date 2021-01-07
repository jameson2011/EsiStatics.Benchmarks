namespace EsiStatics.Benchmarks.SolarSystem

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs

[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type AsteroidBeltGetBenchmark()=
    
    [<Params(40316916,40316920,40316962,40316963)>]
    member val BeltId = 0 with get, set
    
    [<Benchmark>]
    member this.GetAsteroidBelt() =
        EsiStatics.AsteroidBelts.byId this.BeltId

