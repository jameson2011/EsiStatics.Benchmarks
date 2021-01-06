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
type ConstellationFinderBenchmark()=
    
    let finder = new ConstellationFinder(true)

    [<GlobalSetup>]
    member this.Setup()=
        finder.Find(System.Guid.NewGuid().ToString()) |> Seq.length |> ignore
    
    [<Params("pecca", "eugidi", "kimotoro", "unicorn", "zermont")>]
    member val ConstellationName = "" with get, set
    

    [<Benchmark>]
    member this.FindConstellations() =
        finder.Find(this.ConstellationName) |> Array.ofSeq
        
        
