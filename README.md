[![.NET Build](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-build.yml)

[![.NET Release](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml/badge.svg)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml)

# ReadMyHosts
ReadMyHosts (**RMH**) is a software to handle the windows/linux hosts file

## What to download

### dotnet-build.yml

You should only ever need a `Build` download, if you need to debug on your own machine.
This guy has been build under Debug Configuration over the whole solution. Upon execution ***everything*** will be logged in the ./log/ directory
- (Note the App**Debug**[timestamp].log filename)
- based on this github workflow: https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-build.yml

### dotnet-release.yml

This is the production download, it only logs when errors occur, but does this as Verbose as needed.
- (Note the App[timestamp].log filename (no "Debug"))
- based on this github workflow: https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml

## Intent and purpose

Essentially this is my attempt to pull together a few "new" concepts in C# and .NET, as well as generic
general better understanding of concepts like MVVM, Code-Decoupling, and logging

## In the future ..

- This is going to be one of a few of tools, that is going to live under the mantle of [SManager](https://github.com/MzB-Solutions/SManager)
- Make another project, and run hosts edit as a console based application if wanted.
(both of the above are easily implemented because the code is, as far as possibly, "weakly" coupled)