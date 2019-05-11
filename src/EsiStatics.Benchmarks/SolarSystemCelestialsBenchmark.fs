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
type SolarSystemCelestialsBenchmark()=
    
    let mutable solarSystem : SolarSystem option = None

    [<IterationSetup>]
    member this.Setup()=
        let finder = new SolarSystemFinder()
        solarSystem <- finder.Find(this.SolarSystemName) |> Seq.tryHead
    
    [<Params("Adirain", "Heild", "Jita", "Avenod", "Thera")>]
    member val SolarSystemName = "" with get, set
    
    [<Benchmark>]
    member this.GetCelestials() =
        let celestials = ( Option.get solarSystem ).Celestials() |> List.ofSeq
        
        celestials |> List.head
        
        
        

