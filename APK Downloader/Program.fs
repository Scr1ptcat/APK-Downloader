// Learn more about F# at http://fsharp.org

open System
open FSharp.Data
open System.Net
open System.IO


[<EntryPoint>]
let main argv =   

    let apkDownloader = new WebClient()

    let apiKey = "b1207f182ed1c3b28f8cc12ad330bb4079e38dbcab85828bed36c22dbbe0a078"
    let sha256 = "690F5ACB504FF0F095060023031B2403D81B8E0E01E5DD640A237946D950F554"

    let testString = String.Format("https://androzoo.uni.lu/api/download?apikey={0}&sha256={1}", apiKey, sha256)

    

    let downloadedAPK =
        try
            apkDownloader.DownloadData(String.Format("https://androzoo.uni.lu/api/download?apikey=${0}&sha256=${1}", apiKey, sha256))
        with
            | :? System.DivideByZeroException as ex -> printfn "Exception! %s " (ex.Message); None
        
    File.WriteAllBytes("C:\test.apk", downloadedAPK)

    0 // return an integer exit code


    

