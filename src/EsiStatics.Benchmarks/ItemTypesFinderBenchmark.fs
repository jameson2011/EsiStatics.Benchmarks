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
    
    let finder = new ItemTypesFinder(true)
    
    [<Params("rifter", "federation navy comet", "hecate", "erebus", "200mm autocannon ii", "light neutron blaster ii", "zainou", "zzz")>]
    member val Name = "" with get, set
    
    [<Benchmark>]
    member this.GetItemTypes() =
        finder.Find(this.Name) |> Seq.length

