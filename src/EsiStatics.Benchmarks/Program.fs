namespace EsiStatics.Benchmarks

module Program=

    open BenchmarkDotNet.Running

    [<EntryPoint>]
    let main argv =
        BenchmarkSwitcher.FromAssembly(typedefof<SolarSystem.SolarSystemGetBenchmark>.Assembly).Run(argv) |> ignore
        0