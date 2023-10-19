using System.CommandLine;
using System.Threading.Tasks;

namespace OptimizationMethods.Application;

internal static class Program
{ 
    internal static async Task<int> Main(string[] args) 
    {
        var cliHandler = CliHandlerFactory.Create();
        return await cliHandler.InvokeAsync(args);
    }
}
