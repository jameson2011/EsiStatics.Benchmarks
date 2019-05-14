namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs

[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type MoonGetBenchmark()=
    
    [<Params(40316915,40316926,40316964,40316965)>]
    member val MoonId = 0 with get, set
    
    [<Benchmark>]
    member this.GetMoon() =
        EsiStatics.Moons.byId this.MoonId

