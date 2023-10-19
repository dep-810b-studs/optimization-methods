using System.CommandLine;
using System.IO;

namespace OptimizationMethods.Application;

internal static class CliHandlerFactory
{
    internal static RootCommand Create()
    {
        var rootCommand = new RootCommand("Application for numerical solving equations.");
            
        var fileOption = new Option<FileInfo>(
            name: "--input-file",
            description: "The file that contains equation and initial function value.") 
        { 
            IsRequired = true,
        };

        fileOption.AddAlias("-i");
        rootCommand.AddOption(fileOption);

        return rootCommand;
    } 
}