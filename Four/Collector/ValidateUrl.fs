namespace Four.Collector.ValidateUrl

open System
open System.Net.Http

module ValidateUrl =
  let exec (uriString: string) : Uri option =

    Uri.TryCreate(uriString, UriKind.Absolute)
      |> function
        | true, uri ->
            if uri.Scheme = Uri.UriSchemeHttp || uri.Scheme = Uri.UriSchemeHttps then
              Some uri
            else
              None
        | false, _ -> None
