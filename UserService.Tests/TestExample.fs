module UserService.TestModule
open NUnit.Framework
open FsUnit

[<TestFixture>]
  type fixture ()=
    [<Test>]member x.
         ``1 is 1`` ()=
                1 |> should equal 1
        