namespace App.Create
module CreateRequestValidation =
  open RequestObjects

  type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure
  
  let validateInput (input:CreateRequest) =
    if input.FirstName = "" then Failure "Name must not be blank"
    else if input.Email = "" then Failure "Email must not be blank"
    else Success input 