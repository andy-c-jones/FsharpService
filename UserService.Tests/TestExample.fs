module UserService.TestModule
open NUnit.Framework
open FsUnit

[<Test>]
let test =
  1 |> should equal 1