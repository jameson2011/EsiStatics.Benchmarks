namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs

[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type SolarSystemGetBenchmark()=
    
    [<Params(KnownSystems.adirain, KnownSystems.heild, KnownSystems.jita, KnownSystems.avenod, KnownSystems.thera)>]
    member val SolarSystemId = 0 with get, set
    
    [<Benchmark>]
    member this.GetSystem() =
        EsiStatics.SolarSystems.byId this.SolarSystemId

