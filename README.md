# Simple xUnit tests that fails

This project contains very simple tests, with some failing and some succeeding. The determining factor of success seems to relate to the amount of parameters on the test methods.

## Steps to reproduce

(the following is what I will report in the issue)

1. Install the .NET 6.0.200 ARM64 SDK on a Mac running on the M1 chip
2. Create a new xUnit test project 
3. Add the following class and contents to the project:

```csharp
using System;
using System.Threading.Tasks;
using Xunit;

namespace DebuggingTestCrashing;

public class DebuggingTestCrashing
{
    [Theory]
    [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
    public async Task ElevenParams_Crashes(
        int p1,
        int p2,
        int p3,
        int p4,
        int p5,
        int p6,
        int p7,
        int p8,
        int p9,
        int p10,
        int p11
        )
    {
        Console.WriteLine("test crashes");
    }
}
```

4. Run the tests in the test project using `dotnet test`
5. Watch the test fail with the following exception:

```
The active test run was aborted. Reason: Test host process crashed

Test Run Aborted with error System.Exception: One or more errors occurred.
 ---> System.Exception: Unable to read beyond the end of the stream.
   at System.IO.BinaryReader.ReadByte()
   at System.IO.BinaryReader.Read7BitEncodedInt()
   at System.IO.BinaryReader.ReadString()
   at Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.LengthPrefixCommunicationChannel.NotifyDataAvailable()
   at Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.TcpClientExtensions.MessageLoopAsync(TcpClient client, ICommunicationChannel channel, Action`1 errorHandler, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---.
```




## System details

I have only been able to reproduce this issue on Macbook Pros with M1 chips.

Diagnostic files (in `diagnostic-files`) produced by running:
`dotnet test --blame-crash --blame-crash-dump-type full --diag diag.log --configuration Release -l "console;verbosity=detailed" --logger "trx;LogFileName=results.trx"`



### .NET 

```sh
$dotnet --list-sdks
6.0.200 [/usr/local/share/dotnet/sdk]

$dotnet --version
6.0.200

$dotnet --info
.NET SDK (reflecting any global.json):
 Version:   6.0.200
 Commit:    4c30de7899

Runtime Environment:
 OS Name:     Mac OS X
 OS Version:  12.2
 OS Platform: Darwin
 RID:         osx.12-arm64
 Base Path:   /usr/local/share/dotnet/sdk/6.0.200/

Host (useful for support):
  Version: 6.0.2
  Commit:  839cdfb0ec

.NET SDKs installed:
  6.0.200 [/usr/local/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.2 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.2 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]

```

### Hardware

* Model Name:	MacBook Pro
* Model Identifier:	MacBookPro18,1
* Chip:	Apple M1 Pro
* Total Number of Cores:	10 (8 performance and 2 efficiency)
* Memory:	32 GB
* System Firmware Version:	7429.81.3
* OS Loader Version:	7429.81.3

### OS

System Software Overview:

* System Version:	macOS 12.2.1 (21D62)
* Kernel Version:	Darwin 21.3.0
