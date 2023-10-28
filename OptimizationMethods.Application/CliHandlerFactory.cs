using System;
using System.CommandLine;
using System.IO;
using System.Linq;

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
        
        rootCommand.SetHandler(ReadFile, fileOption);

        return rootCommand;
    }
    
    static void ReadFile(FileInfo file)
    {
        File.ReadLines(file.FullName)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}