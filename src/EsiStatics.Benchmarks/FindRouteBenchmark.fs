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
type FindRouteBenchmark()=
    
    let mutable fromSolarSystem : SolarSystem option = None
    let mutable toSolarSystem : SolarSystem option = None
    let finder = new SolarSystemFinder(true)
    
    [<IterationSetup>]
    member this.Setup()=
        fromSolarSystem <- finder.Find(this.FromSolarSystemName) |> Seq.tryHead
        toSolarSystem <- finder.Find(this.ToSolarSystemName) |> Seq.tryHead
    
    [<Params("Adirain", "Heild", "Avenod", "Deepari", "QX-LIJ", "0OYZ-G", "DN58-U", "RI-JB1", "MVUO-F", "Tsuguwa")>]
    member val FromSolarSystemName = "" with get, set
    
    [<Params("Jita", "Zemalu")>]
    member val ToSolarSystemName = "" with get, set



    [<Benchmark>]
    member this.FindEuclideanRoute() =
        let start = fromSolarSystem |> Option.get
        let finish = toSolarSystem |> Option.get

        let route = (start, finish) |> Navigation.findGateRoute Navigation.euclideanSystemDistance
        
        route |> Seq.length

    [<Benchmark>]
    member this.FindDijkstraRoute() =
        let start = fromSolarSystem |> Option.get
        let finish = toSolarSystem |> Option.get

        let route = (start, finish) |> Navigation.findGateRoute Navigation.dijkstraSystemDistance
        
        route |> Seq.length
