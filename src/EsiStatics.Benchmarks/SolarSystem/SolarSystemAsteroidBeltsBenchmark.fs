namespace EsiStatics.Benchmarks.SolarSystem

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics


[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type SolarSystemAsteroidBeltsBenchmark()=
    
    let mutable solarSystem : SolarSystem option = None
    let finder = new SolarSystemFinder(true)
    
    [<IterationSetup>]
    member this.Setup()=
        solarSystem <- finder.Find(this.SolarSystemName) |> Seq.tryHead
    
    [<Params("Adirain", "Heild", "Jita", "Avenod", "Thera")>]
    member val SolarSystemName = "" with get, set
    
    [<Benchmark>]
    member this.GetAsteroidBelts() =
        ( Option.get solarSystem ).Planets() 
            |> Seq.collect (fun p -> p.AsteroidBelts())
            |> Seq.length
        
        
        

