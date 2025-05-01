namespace Four.Collector.Feed

open System
open Option
open System.Net.Http
open System.Xml
open System.ServiceModel.Syndication

module Feed =
  let get (uri: Uri): Async<option<SyndicationFeed>> =
    async {
      let client = new HttpClient()
      let! response = client.GetAsync(uri) |> Async.AwaitTask
      match response.IsSuccessStatusCode with
      | true ->
        let! stream = response.Content.ReadAsStreamAsync() |> Async.AwaitTask
        use reader = XmlReader.Create(stream)
        let feed = SyndicationFeed.Load(reader)
        return Some feed
      | false ->
        return None
    }

