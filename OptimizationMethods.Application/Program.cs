using System.CommandLine;
using OptimizationMethods.Application;

var cliHandler = CliHandlerFactory.Create();
return await cliHandler.InvokeAsync(args);
