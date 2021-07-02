
# Build Status

- [![.NET Build](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-build.yml)

- [![.NET Release](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml/badge.svg)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml)

- [![Codacy Badge](https://app.codacy.com/project/badge/Grade/03080d3aed254c54b49ed7e18b59f996)](https://www.codacy.com/gh/MzB-Solutions/ReadMyHosts/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=MzB-Solutions/ReadMyHosts&amp;utm_campaign=Badge_Grade)

# ReadMyHosts

ReadMyHosts (**RMH**) is a software to handle the windows/linux hosts file

## What to download

### dotnet-build.yml

You should only ever need a `Build` download, if you need to debug on your own machine.
This guy has been build under Debug Configuration over the whole solution.
Upon execution ***everything*** will be logged in the ./log/ directory

  - (Note the App**Debug**yyyymmdd.log filename)

- based on this github workflow: [https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-build.yml]

### dotnet-release.yml

This is the production download, it only logs when errors occur,
but does this as Verbose as needed.
- (Note the Appyyyymmdd.log filename (no "Debug"))

- based on this github workflow: [https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml]

## Intent and purpose

Essentially this is my attempt to pull together a few "new" concepts in C# and .NET,
as well as generic general better understanding of concepts like MVVM, Code-Decoupling,
logging etc..

## In the future

- This is going to be one of a few of tools, that is going to live under the mantle
    of [SManager](https://github.com/MzB-Solutions/SManager)

  - Make another project, and run hosts edit as a console based application if wanted.

(both of the above are easily implemented because the code is, as far as possibly,
 "weakly" coupled)
