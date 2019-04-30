namespace EsiStatics.Benchmarks

module Program=
    open System
    open BenchmarkDotNet.Running

    [<EntryPoint>]
    let main argv =
    
        let benchmarks = [|    typedefof<SolarSystemGetBenchmark>;
                                    typedefof<SolarSystemScanBenchmark>;
                                    typedefof<SolarSystemDeepGetBenchmark>;
                                    typedefof<SolarSystemCelestialDistancesBenchmark>;
                                    typedefof<SolarSystemNeighboursBenchmark>;
                                    typedefof<FindRouteBenchmark>;
                                    |]

        
        let switch = BenchmarkSwitcher benchmarks
        switch.RunAll() |> ignore
        0 
