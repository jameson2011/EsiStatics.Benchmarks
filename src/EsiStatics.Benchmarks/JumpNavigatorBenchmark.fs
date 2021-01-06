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
type JumpNavigatorBenchmark()=

    let systemFinder = new SolarSystemFinder(true)
    let itemTypeFinder = new ItemTypesFinder()

    [<Params("adirain", "schoorasana", "1-nkvt" )>]
    member val StartSolarSystem = "" with get, set

    [<Params("avenod")>]
    member val DestinationSolarSystem = "" with get, set

    [<Params("sin", "thanatos", "rhea")>]
    member val Ship = "" with get, set

    [<Params(5)>]
    member val JumpCalibration = 5 with get, set

    [<Params(5)>]
    member val JumpConservation = 5 with get, set

    [<Params(1.)>]
    member val DistanceWeight = 1. with get, set

    [<Params(1.)>]
    member val StationDockingWeight = 1. with get, set

    [<Params(1.)>]
    member val AvoidPochvenWeight = 1. with get, set

    [<Params(1.)>]
    member val EmptyStationsWeight = 1. with get, set

    [<Benchmark>]
    member this.Find() =
        let ship = itemTypeFinder.Find(this.Ship) |> Seq.head
        let start = systemFinder.Find(this.StartSolarSystem) |> Seq.head
        let dest = systemFinder.Find(this.DestinationSolarSystem) |> Seq.head
        
        let plan = JumpPlan.empty 
                    |> JumpPlan.setCalibration this.JumpCalibration
                    |> JumpPlan.setConservation this.JumpConservation
                    |> JumpPlan.setRoute [| start; dest |]
                    |> JumpPlan.setShip ship
                    |> JumpPlan.setDistanceWeight this.DistanceWeight
                    |> JumpPlan.setStationDockingWeight this.StationDockingWeight
                    |> JumpPlan.setAvoidPochvenWeight this.AvoidPochvenWeight
                    |> JumpPlan.setEmptyStationsWeight this.EmptyStationsWeight

        let routeFinder = new JumpNavigator(plan)

        routeFinder.FindRoute()

