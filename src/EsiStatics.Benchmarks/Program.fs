namespace EsiStatics.Benchmarks

module Program=

    open BenchmarkDotNet.Running

    [<EntryPoint>]
    let main argv =
        BenchmarkSwitcher.FromAssembly(typedefof<SolarSystemGetBenchmark>.Assembly).Run(argv) |> ignore
        0