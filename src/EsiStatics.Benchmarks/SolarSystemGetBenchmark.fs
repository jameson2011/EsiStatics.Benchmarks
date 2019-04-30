namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs

[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
type SolarSystemGetBenchmark()=
    
    [<Params(KnownSystems.adirain, KnownSystems.jita, KnownSystems.avenod, KnownSystems.thera)>]
    member val SolarSystemId = 0 with get, set
    
    [<Benchmark>]
    member this.GetSystem() =
        EsiStatics.SolarSystems.byId this.SolarSystemId

