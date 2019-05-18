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
type ItemTypesFinderBenchmark()=
    
    let mutable finder = new ItemTypesFinder()
    
    [<GlobalSetup>]
    member this.Setup()=
        finder <- new ItemTypesFinder()
        finder.FindItemTypes(System.Guid.NewGuid().ToString()) |> Seq.length |> ignore

    [<Params("rifter", "federation navy comet", "hecate", "erebus", "200mm autocannon ii", "light neutron blaster ii", "zainou", "zzz")>]
    member val Name = "" with get, set
    
    [<Benchmark>]
    member this.GetItemTypes() =
        finder.FindItemTypes(this.Name) |> Seq.length

