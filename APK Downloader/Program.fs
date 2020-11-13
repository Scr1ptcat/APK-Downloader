// Learn more about F# at http://fsharp.org

open System
open FSharp.Data
open System.Net
open System.IO

module Configuration = 

    let apiKey = "{Your Androzoo API Key Here}"
    let androzooURI = "https://androzoo.uni.lu/api/download?apikey={0}&sha256={1}"
    let inputDirectory = @"~\multi-versioned-apks.txt"
    let outputDirectory = @"~\APKs\"

let ReadTargetSHAs shaList : string [] =

    File.ReadAllLines(Configuration.inputDirectory)

let ProcessInputFile (shaList : string [])  =

    let apkMetadataList = [for apkMetadata in shaList do yield apkMetadata.Split [|' '|] ]    

    apkMetadataList

let DownloadAPK(sha256 : string) : byte [] =
        
    let apkDownloader = new WebClient()
    
    let downloadedAPK =

        try
            apkDownloader.DownloadData(String.Format(Configuration.androzooURI, 
                                                    Configuration.apiKey,
                                                    sha256))
        with
            | :? System.Net.WebException as ex -> printfn "Exception! %s " (ex.Message); Array.zeroCreate 1
    
    downloadedAPK
    
let WriteAPK downloadedAPK name version =
    
    File.WriteAllBytes(Configuration.outputDirectory + name + "-" + version + ".apk", downloadedAPK)

[<EntryPoint>]
let main argv =   

    let shaList = ReadTargetSHAs()
    let apkList = ProcessInputFile(shaList) 

    apkList |> List.iter (fun x -> WriteAPK (DownloadAPK(x.[0])) x.[1] x.[2])  

    0





   


    

