using CommandLine;

public class Options
{
    // Define your command line options here

    [Option('m', "mode", Required = true, HelpText = "Set the mode of the application local or remote.")]
    public string? Mode { get; set; }

    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}
