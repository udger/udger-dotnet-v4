# Udger client for .NET (data ver. 4)
Local parser is very fast and accurate useragent string detection solution. Enables developers to locally install and integrate a highly-scalable product.
We provide the detection of the devices (personal computer, tablet, Smart TV, Game console etc.), operating system, client SW type (browser, e-mail client etc.)
and devices market name (example: Sony Xperia Tablet S, Nokia Lumia 820 etc.).
It also provides information about IP addresses (Public proxies, VPN services, Tor exit nodes, Fake crawlers, Web scrapers, Datacenter name .. etc.)

### Requirements
- .NET Framework 4.8 or later.
- ADO.NET Data Provider for SQLite (included)
- datafile v4 (udgerdb_v4.dat) from https://data.udger.com/ 

### Automatic updates download
- for autoupdate data use Udger data updater (https://udger.com/support/documentation/?doc=62)

###Features
- Fast
- Written in C#
- LRU cache
- Released under the MIT


### Usage
You should review the included example (`ConsoleTest\Program.cs`)


### Author
The Udger.com Team (info@udger.com)

### v3 format
For the previous data format (v3), please use https://github.com/udger/udger-dotnet