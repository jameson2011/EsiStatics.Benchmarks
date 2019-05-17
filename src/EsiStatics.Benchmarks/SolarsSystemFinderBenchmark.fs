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
type SolarsSystemFinderBenchmark()=
    
    let mutable finder = new SolarSystemFinder()

    [<GlobalSetup>]
    member this.Setup()=
        finder <- new SolarSystemFinder()
        finder.Find(System.Guid.NewGuid().ToString()) |> Seq.length |> ignore
    
    [<Params("adirain", "heild", "avenod", "deepari", "QX-LIJ", "0OYZ-G", "tsuguwa", "jita", "zemalu")>]
    member val SolarSystemName = "" with get, set
    

    [<Benchmark>]
    member this.FindSolarSystem() =
        finder.Find(this.SolarSystemName) |> Array.ofSeq
        
    [<Benchmark>]
    member this.SearchSolarSystems() =
        finder.Find(this.SolarSystemName.Substring(0, 2)) |> Array.ofSeq
        
