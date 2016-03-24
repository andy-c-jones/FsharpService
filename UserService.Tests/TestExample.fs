module UserService.TestModule
open NUnit.Framework
open FsUnit

[<TestFixture>]
  type fixture ()=
    [<Test>]member x.
         ``when I ask whether it is On it answers false.`` ()=
                1 |> should equal 1
        