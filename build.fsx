// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Testing.NUnit3

RestorePackages()

// Properties
let buildDir = "./build/"

// Targets
Target "Clean" (fun _ ->
  CleanDirs [buildDir]
)

Target "Build" (fun _ ->
  !! "**/*.fsproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "Build-Output: "
)

Target "Test" (fun _ ->
  !! (buildDir + "/*Tests.dll")
    |> NUnit3 (fun p ->
      {p with
        //ToolName = "nunit3-console.exe"
        ToolPath = "packages/NUnit.ConsoleRunner/tools/nunit3-console.exe" 
        })
)

// Dependencies
"Clean"
  ==> "Build"
  ==> "Test"

// start build
RunTargetOrDefault "Test"
