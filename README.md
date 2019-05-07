# KnightCrawler CLI

# Basic usage

When you have the .NET Command Line Interface installed on your OS of choice, you can try it out using some of the samples on the [dotnet/core repo](https://github.com/dotnet/core/tree/master/samples). You can download the sample in a directory, and then you can kick the tires of the CLI.


Clone the Repository

    git clone <repo-name>

Change Directories to Client App

    cd src/Client/InfinityLabs.KnightCrawler.ConsoleApp/

Run the Application

    dotnet run -- -u mywebsite.com -depth 1


## Arguments

`-u | --url` (Required) The url to scrape links from.

`-d | --depth` (Default: 1) How many levels down to go.

`-p | --path` Folder to place results file in.

`-o | --output` Output type (CSV, HTML, JSON)

`-t | --trace` Switch to enable console output.