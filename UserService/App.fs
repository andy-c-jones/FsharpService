module App

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Json
open System.Runtime.Serialization

type Result<'TSuccess,'TFailure> = 
  | Success of 'TSuccess
  | Failure of 'TFailure

[<DataContract>]
type CreateRequest = 
  {
  [<field: DataMember(Name = "firstName")>]
  firstName:string; 
  [<field: DataMember(Name = "email")>]
  email:string
  }

let validateInput input =
  if input.firstName = "" then Failure "Name must not be blank"
  else if input.email = "" then Failure "Email must not be blank"
  else Success input  // happy path

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