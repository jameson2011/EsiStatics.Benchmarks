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
type SolarSystemCelestialDistancesBenchmark()=
    
    let mutable solarSystem : SolarSystem option = None

    [<IterationSetup>]
    member this.Setup()=
        let finder = new SolarSystemFinder()
        solarSystem <- finder.Find(this.SolarSystemName) |> Seq.tryHead
    
    [<Params("Adirain", "Heild", "Jita", "Avenod", "Thera")>]
    member val SolarSystemName = "" with get, set
    
    [<Benchmark>]
    member this.GetCelestialDistance() =
        
        let pos = Position.ofCoordinates(1., 1., 1.)

        let celestials = pos |> UniverseExtensions.CelestialDistances (Option.get solarSystem) |> List.ofSeq
        
        celestials |> List.head
        
        
        

