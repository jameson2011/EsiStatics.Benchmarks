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

type SolarSystemDistanceFinderBenchmark()=

    let finder = new SolarSystemDistanceFinder()
    let systemFinder = new SolarSystemFinder(true)

    [<Params("adirain", "heild", "avenod", "deepari", "QX-LIJ", "0OYZ-G", "tsuguwa", "jita", "zemalu")>]
    member val SolarSystemName = "" with get, set

    [<Params(1., 4., 6., 8., 10.)>]
    member val Distance = 0. with get, set

    [<Benchmark>]
    member this.Find() =
        let sys = systemFinder.Find(this.SolarSystemName) |> Seq.head
        let distance = this.Distance * (1.<LY>)

        finder.Find sys distance
        
        
        
