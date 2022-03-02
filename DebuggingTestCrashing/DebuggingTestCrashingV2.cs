using System;
using System.Threading.Tasks;
using Xunit;

namespace DebuggingTestCrashing;

public class DebuggingTestCrashingV2
{
    [Theory]
    [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
    public async Task TenParams_DoesNotCrash(
        int p1,
        int p2,
        int p3,
        int p4,
        int p5,
        int p6,
        int p7,
        int p8,
        int p9,
        int p10
    )
    {
        Console.WriteLine("test does not crash");
    }
    
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
    
    [Theory]
    [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
    public async Task TwelveParams_DoesNotCrash(
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
        int p11,
        int p12
    )
    {
        Console.WriteLine("test does not crash when run alone, fails when run with others");
    }
}