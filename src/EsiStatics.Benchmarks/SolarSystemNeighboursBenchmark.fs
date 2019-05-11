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
type SolarSystemNeighboursBenchmark()=
    
    let mutable solarSystem : SolarSystem option = None

    [<IterationSetup>]
    member this.Setup()=
        let finder = new SolarSystemFinder()
        solarSystem <- finder.Find(this.SolarSystemName) |> Seq.tryHead
    
    [<Params("Adirain", "Heild", "Jita", "Avenod", "Thera")>]
    member val SolarSystemName = "" with get, set
    
    
    [<Params(1, 2, 3, 4, 5)>]
    member val Depth = 0 with get, set

    [<Benchmark>]
    member this.GetSystemNeighbours() =    
        this.Depth |> SolarSystemExts.Neighbours (Option.get solarSystem) |> List.ofSeq

        
        
        

