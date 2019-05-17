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
type RegionFinderBenchmark()=
    
    let mutable finder = new RegionFinder()

    [<GlobalSetup>]
    member this.Setup()=
        finder <- new RegionFinder()
        finder.Find(System.Guid.NewGuid().ToString()) |> Seq.length |> ignore
    
    [<Params("essence", "domain", "delve", "metropolis", "catch", "the bleak lands")>]
    member val RegionName = "" with get, set
    

    [<Benchmark>]
    member this.FindRegions() =
        finder.Find(this.RegionName) |> Array.ofSeq
        
        
