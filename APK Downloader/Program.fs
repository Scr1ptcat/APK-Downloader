// Learn more about F# at http://fsharp.org

open System
open FSharp.Data
open System.Net
open System.IO

module Configuration = 

    let apiKey = "b1207f182ed1c3b28f8cc12ad330bb4079e38dbcab85828bed36c22dbbe0a078"
    let androzooURI = "https://androzoo.uni.lu/api/download?apikey={0}&sha256={1}"
    let inputDirectory = @"C:\Users\John\Desktop\multi-versioned-apks.txt"
    let outputDirectory = @"C:\test.apk"

let ReadTargetSHAs () (shaList : string []) =

    File.ReadAllLines(Configuration.inputDirectory)

let ProcessInputFile(shaList : string []) =

    for apkMetadata in shaList do

        apkMetadata.

let DownloadAPK(sha256 : string) (downloadedAPK: byte []) =
        
    let apkDownloader = new WebClient()
    
    let downloadedAPK =
        try
            apkDownloader.DownloadData(String.Format(Configuration.androzooURI, 
                                                    Configuration.apiKey,
                                                    sha256))
        with
            | :? System.Net.WebException as ex -> printfn "Exception! %s " (ex.Message); Array.zeroCreate 1
    
    downloadedAPK
    
let WriteAPK(downloadedAPK : byte []) =
    
    File.WriteAllBytes(Configuration.outputDirectory , downloadedAPK)

[<EntryPoint>]
let main argv =   

    0





   


    

