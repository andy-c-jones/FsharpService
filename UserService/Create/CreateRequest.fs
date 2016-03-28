namespace RequestObjects
open System.Runtime.Serialization

[<DataContract>]
type CreateRequest = 
  {
  [<field: DataMember(Name = "firstName")>]
  FirstName:string; 
  [<field: DataMember(Name = "email")>]
  Email:string
  }