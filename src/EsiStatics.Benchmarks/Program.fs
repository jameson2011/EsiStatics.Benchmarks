namespace EsiStatics.Benchmarks

module Program=

    open System
    open BenchmarkDotNet.Running


    [<EntryPoint>]
    let main argv =
    
        let benchmarks = [|     typedefof<SolarSystemGetBenchmark>;
                                typedefof<SolarSystemScanBenchmark>;
                                typedefof<SolarSystemCelestialDistancesBenchmark>;
                                typedefof<SolarSystemCelestialsBenchmark>;
                                typedefof<SolarSystemAsteroidBeltsBenchmark>;
                                typedefof<SolarSystemMoonsBenchmark>;
                                typedefof<SolarSystemPlanetsBenchmark>;
                                typedefof<SolarSystemStarBenchmark>;
                                typedefof<SolarSystemStargatesBenchmark>;
                                typedefof<SolarSystemStationsBenchmark>;
                                typedefof<SolarSystemNeighboursBenchmark>;
                                typedefof<FindRouteBenchmark>;
                                typedefof<SolarsSystemFinderBenchmark>;
                                typedefof<AsteroidBeltGetBenchmark>;
                                typedefof<MoonGetBenchmark>;
                                typedefof<PlanetGetBenchmark>;
                                |]

        
        let switch = BenchmarkSwitcher benchmarks
        switch.RunAll() |> ignore
        0 
