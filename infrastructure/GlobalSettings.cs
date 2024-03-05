public class GlobalSettings : IGlobalSettings
{
    public bool Verbose { get; set; }

    public AppMode Mode { get; set; }
}

public enum AppMode
{
    None,
    Local,
    Remote
}
