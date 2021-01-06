namespace EsiStatics.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics


[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type SolarSystemCelestialDistancesBenchmark()=
    
    let mutable solarSystem : SolarSystem option = None
    let finder = new SolarSystemFinder(true)
    
    [<IterationSetup>]
    member this.Setup()=
        solarSystem <- finder.Find(this.SolarSystemName) |> Seq.tryHead
    
    [<Params("Adirain", "Heild", "Jita", "Avenod", "Thera")>]
    member val SolarSystemName = "" with get, set
    
    [<Benchmark>]
    member this.GetCelestialDistance() =
        
        let pos = Position.ofCoordinates(1., 1., 1.)

        let celestials = pos |> SolarSystemExts.CelestialDistances (Option.get solarSystem) |> List.ofSeq
        
        celestials |> List.head
        
        
        

