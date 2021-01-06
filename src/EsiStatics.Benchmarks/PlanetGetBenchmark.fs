namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs

[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type PlanetGetBenchmark()=
    
    [<Params(40316914,40316928,40316961,40316966)>]
    member val PlanetID = 0 with get, set
    
    [<Benchmark>]
    member this.GetPlanet() =
        EsiStatics.Planets.byId this.PlanetID

