# ReadMyHosts

## Build Status

- Main Branch: [![Code and Dependency Analysis (main)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/analysis.yml/badge.svg?branch=main)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/analysis.yml)
- 
- Dev Branch: [![Code and Dependency Analysis (dev)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/analysis.yml/badge.svg?branch=dev)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/analysis.yml)

- Main Branch: [![Compile debug build](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-debug.yml/badge.svg?branch=dev)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-debug.yml)

- Dev Branch: [![Compile release build](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml/badge.svg?branch=main)](https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml)

- Main Branch: [![Codacy Badge](https://app.codacy.com/project/badge/Grade/03080d3aed254c54b49ed7e18b59f996)](https://www.codacy.com/gh/MzB-Solutions/ReadMyHosts/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=MzB-Solutions/ReadMyHosts&amp;utm_campaign=Badge_Grade)
## ReadMyHosts

ReadMyHosts (**RMH**) is a software to handle the windows/linux hosts file

### What to download

This is the production download, it only logs when errors occur,
but does this as Verbose as needed.

- (Note the Appyyyymmdd.log filename (no "Debug"))

- based on this github workflow: [https://github.com/MzB-Solutions/ReadMyHosts/actions/workflows/dotnet-release.yml]

~~Download this [file](https://github.com/MzB-Solutions/ReadMyHosts/releases/download/v0.1/RMH-linux-v0.1.zip) for Linux~~

~~Download this [file](https://github.com/MzB-Solutions/ReadMyHosts/releases/download/v0.1/RMH-win32-v0.1.zip) for Windows~~

### Intent and purpose

Essentially this is my attempt to pull together a few "new" concepts in C# and .NET,
as well as generic general better understanding of concepts like MVVM, Code-Decoupling,
logging etc..

### In the future

- This is going to be one of a few of tools, that is going to live under the mantle
    of [SManager](https://github.com/MzB-Solutions/SManager)

- Make another project, and run hosts edit as a console based application if wanted.

(both of the above are easily implemented because the code is, as far as possibly,
 "weakly" coupled)
