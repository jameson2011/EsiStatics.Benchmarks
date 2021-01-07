namespace EsiStatics.Benchmarks.Routes

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open EsiStatics

[<SimpleJob>]
[<MemoryDiagnoser>]
[<RankColumn>][<MinColumn>][<Q1Column>][<Q3Column>][<MaxColumn>]
[<GcServer(true)>]
type JumpNavigatorBenchmark()=

    let systemFinder = new SolarSystemFinder(true)
    let itemTypeFinder = new ItemTypesFinder()
    let distanceFinder = new SolarSystemDistanceFinder(true)

    [<Params("adirain", "schoorasana", "poitot" )>]
    member val StartSolarSystem = "" with get, set

    [<Params("avenod")>]
    member val DestinationSolarSystem = "" with get, set

    [<Params("thanatos", "rhea")>]
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
                    |> JumpRouteNavigation.calibration this.JumpCalibration
                    |> JumpRouteNavigation.conservation this.JumpConservation
                    |> JumpRouteNavigation.route [| start; dest |]
                    |> JumpRouteNavigation.ship ship
                    |> JumpRouteNavigation.distanceWeight this.DistanceWeight
                    |> JumpRouteNavigation.stationDockingWeight this.StationDockingWeight
                    |> JumpRouteNavigation.avoidPochvenWeight this.AvoidPochvenWeight
                    |> JumpRouteNavigation.emptyStationsWeight this.EmptyStationsWeight

        JumpRouteNavigation.findRoute distanceFinder plan

        

