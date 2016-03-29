namespace App
module App =
  open Suave
  open Suave.Filters
  open Suave.Operators
  open Suave.Successful
  open Suave.Json
  
  let app : WebPart =
    choose
      [ GET >=> choose
          [ path "/hello" >=> OK "Hello GET"
            path "/goodbye" >=> OK "Good bye GET" ]
        POST >=> choose
          [ path "/create" >=> Writers.setMimeType "application/json" >=> OK "{id:1234}"
            path "/goodbye" >=> OK "Good bye POST" ]
        DELETE >=> choose
          [ pathScan "/users/%d" (fun (id :int) -> printfn "id"; OK "200") >=> Writers.setMimeType "application/json"]
         ]
  
  [<EntryPoint>]
  let main _ =
    startWebServer defaultConfig app
    0