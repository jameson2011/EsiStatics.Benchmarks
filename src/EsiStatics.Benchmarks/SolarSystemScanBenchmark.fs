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
type SolarSystemScanBenchmark()=
    
    [<Benchmark>]
    member this.ScanSystems() =
        let ss = Regions.all()
                    |> Seq.collect (fun r -> r.Constellations())
                    |> Seq.collect (fun c -> c.SolarSystems())

        ss |> Seq.length


