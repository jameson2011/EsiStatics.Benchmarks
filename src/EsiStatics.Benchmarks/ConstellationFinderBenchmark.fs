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
type ConstellationFinderBenchmark()=
    
    let mutable finder = new ConstellationFinder()

    [<GlobalSetup>]
    member this.Setup()=
        finder <- new ConstellationFinder()
        finder.Find(System.Guid.NewGuid().ToString()) |> Seq.length |> ignore
    
    [<Params("pecca", "eugidi", "kimotoro", "unicorn", "zermont")>]
    member val ConstellationName = "" with get, set
    

    [<Benchmark>]
    member this.FindConstellations() =
        finder.Find(this.ConstellationName) |> Array.ofSeq
        
        
