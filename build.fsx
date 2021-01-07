#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators


let buildDir = "./build/"
let buildLibDir = buildDir + "lib/"
let execPath = "EsiStatics.Benchmarks.dll" |> Path.combine buildLibDir 
let testResultsDir = "BenchmarkDotNet.Artifacts"

let buildOptions = fun (opts: DotNet.BuildOptions) -> 
                                { opts with
                                    Configuration = DotNet.BuildConfiguration.Release
                                    OutputPath = buildLibDir |> Some
                                    MSBuildParams = { opts.MSBuildParams with 
                                                                DisableInternalBinLog = true }
                                } 

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ buildDir
    ++ buildLibDir
    ++ testResultsDir
    |> Shell.cleanDirs 
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build buildOptions)
)

Target.create "Run Universe Benchmarks" (fun _ -> DotNet.exec id execPath "-f EsiStatics.Benchmarks.Universe.*" |> ignore)

Target.create "Run Item Type Benchmarks" (fun _ -> DotNet.exec id execPath "-f EsiStatics.Benchmarks.ItemTypes.*" |> ignore)
    
Target.create "Run Solar System Benchmarks" (fun _ -> DotNet.exec id execPath "-f EsiStatics.Benchmarks.SolarSystem.*" |> ignore)

Target.create "Run Routes Benchmarks" (fun _ -> DotNet.exec id execPath "-f EsiStatics.Benchmarks.Routes.*" |> ignore)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "Run Universe Benchmarks"
  ==> "Run Item Type Benchmarks"
  ==> "Run Solar System Benchmarks"
  ==> "Run Routes Benchmarks"
  ==> "All"

Target.runOrDefault "All"
