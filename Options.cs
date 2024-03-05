using CommandLine;

public class Options
{
    // Define your command line options here

    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}
