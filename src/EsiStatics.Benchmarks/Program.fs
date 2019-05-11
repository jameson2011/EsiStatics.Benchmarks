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
                                typedefof<SolarSystemNeighboursBenchmark>;
                                typedefof<FindRouteBenchmark>;
                                typedefof<SolarsSystemFinderBenchmark>;
                                
                                |]

        
        let switch = BenchmarkSwitcher benchmarks
        switch.RunAll() |> ignore
        0 
