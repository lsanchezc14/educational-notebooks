using System.ComponentModel;
using Spectre.Console.Cli;

public class GreetCommand : Command<GreetCommand.Settings>
{
    public static void Main(string[] args)
    {
        var app = new CommandApp();
        app.Configure(config =>
        {
            config.AddCommand<GreetCommand>("greet");
        });

        app.Run(args);
    }
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<name>")]
        [Description("The name to greet")]
        public string Name { get; init; } = string.Empty;
  
        [CommandOption("-c|--count")]
        [Description("Number of times to greet")]
        [DefaultValue(1)]
        public int Count { get; init; } = 1;
    }
  
    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        for (var i = 0; i < settings.Count; i++)
        {
            System.Console.WriteLine($"Hello, {settings.Name}!");
        }
        return 0;
    }
}