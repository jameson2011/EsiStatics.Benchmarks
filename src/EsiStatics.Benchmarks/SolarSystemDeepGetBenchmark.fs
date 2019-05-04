namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics


[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type SolarSystemDeepGetBenchmark()=
    
    

    [<Params(KnownSystems.adirain, KnownSystems.heild, KnownSystems.jita, KnownSystems.avenod, KnownSystems.thera)>]
    member val SolarSystemId = 0 with get, set
    
    [<Benchmark>]
    member this.GetCelestials() =
        let sys = EsiStatics.SolarSystems.byId this.SolarSystemId |> Option.get
        
        
        sys.Celestials() |> List.ofSeq
        

