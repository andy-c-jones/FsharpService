// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake

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

//Target "Test" (fun _ ->
//  !! (buildDir + "/*Tests.dll")
//    |> NUnit (fun p ->
//      {p with
//        DisableShadowCopy = true;
//        OutputFile = buildDir + "TestResults.xml" })
//)

// Dependencies
"Clean"
  ==> "Build"
//  ==> "Test"

// start build
RunTargetOrDefault "Test"