namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics


[<CoreJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
type SolarSystemCelestialDistancesBenchmark()=
    
    

    [<Params(KnownSystems.adirain, KnownSystems.heild, KnownSystems.jita, KnownSystems.avenod, KnownSystems.thera)>]
    member val SolarSystemId = 0 with get, set
    
    [<Benchmark>]
    member this.GetSystem() =
        let sys = EsiStatics.SolarSystems.byId this.SolarSystemId |> Option.get
        
        let pos = Position.ofCoordinates(1., 1., 1.)

        let celestials = pos |> UniverseExtensions.CelestialDistances sys |> List.ofSeq
        
        celestials |> List.head
        
        
        

