namespace App
module App =
  open Suave
  open Suave.Filters
  open Suave.Operators
  open Suave.Successful
  open Suave.Json
  
  let app =
    choose
      [ GET >=> choose
          [ path "/hello" >=> OK "Hello GET"
            path "/goodbye" >=> OK "Good bye GET" ]
        POST >=> choose
          [ path "/create" >=> OK "Hello POST"
            path "/goodbye" >=> OK "Good bye POST" ]
        //POST >=> request(fun r -> OK <| deserialiseHere r.form <| validateInput )
         ]
  
  [<EntryPoint>]
  let main _ =
    startWebServer defaultConfig app
    0