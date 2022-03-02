using System;
using System.Threading.Tasks;
using Xunit;

namespace DebuggingTestCrashing;

public class DebuggingTestCrashing
{
    [Theory]
    [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
    public async Task DoesNotCrash2(int p1, int p2,
        int p3, int p4,
        int p5, int p6, int p7,
        int p8, int p9, int p10,
        int p11, int p12, int p13)
    {
        Console.WriteLine("test crashes");
    }
    
    [Theory]
    [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
    public async Task Crashes2(int p1, int p2,
        int p3, int p4,
        int p5, double p6, double p7,
        int p8, int p9, int p10,
        int p11, int p12, int p13)
    {
        Console.WriteLine("test crashes");
    }
    
    [Theory]
    [InlineData(1)]
    public async Task DoesNotCrash1(int p1)
    {
        Console.WriteLine("test crashes");
    }
}