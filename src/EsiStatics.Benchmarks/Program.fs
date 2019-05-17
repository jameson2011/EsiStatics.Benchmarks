namespace EsiStatics.Benchmarks

module Program=

    open System
    open BenchmarkDotNet.Running
    open EsiStatics


    [<EntryPoint>]
    let main argv =
    
        let benchmarks = [|     
                                typedefof<SolarSystemGetBenchmark>;
                                typedefof<AsteroidBeltGetBenchmark>;
                                typedefof<MoonGetBenchmark>;
                                typedefof<PlanetGetBenchmark>;
                                
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
                                typedefof<RegionFinderBenchmark>;
                                typedefof<ConstellationFinderBenchmark>;
                                
                                typedefof<ItemTypesFinderBenchmark>;
                                |]

        
        let switch = BenchmarkSwitcher benchmarks
        switch.RunAll() |> ignore
        0 
