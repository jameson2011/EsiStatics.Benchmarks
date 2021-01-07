namespace EsiStatics.Benchmarks.Universe

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics

[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type RegionFinderBenchmark()=
    
    let finder = new RegionFinder(true)
    
    [<Params("essence", "domain", "delve", "metropolis", "catch", "the bleak lands")>]
    member val RegionName = "" with get, set
    

    [<Benchmark>]
    member this.FindRegions() =
        finder.Find(this.RegionName) |> Array.ofSeq
        
        
