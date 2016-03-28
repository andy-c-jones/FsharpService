namespace RequestObjects
open System.Runtime.Serialization

[<DataContract>]
type CreateRequest = 
  {
  [<field: DataMember(Name = "firstName")>]
  firstName:string; 
  [<field: DataMember(Name = "email")>]
  email:string
  }