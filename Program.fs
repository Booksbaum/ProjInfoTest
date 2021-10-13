open System
open System.IO
open System.Threading


[<EntryPoint>]
let main argv =
    if argv |> Array.contains "--sleep-on-version" then
        Environment.SetEnvironmentVariable("SleepOnVersion", "1")
    if argv |> Array.contains "--exit-on-version" then
        Environment.SetEnvironmentVariable("ExitOnVersion", "1")

    if argv |> Array.contains "--version" then
        if not <| String.IsNullOrWhiteSpace (Environment.GetEnvironmentVariable("SleepOnVersion")) then
            while true do
                Thread.Sleep 1000
            exit 0
        if not <| String.IsNullOrWhiteSpace (Environment.GetEnvironmentVariable("ExitOnVersion")) then
            exit 0

    let toolsPath = Ionide.ProjInfo.Init.init (DirectoryInfo(Environment.CurrentDirectory))

    0 // return an integer exit code