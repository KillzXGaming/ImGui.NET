namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiOldColumnFlags
    {
        None = 0,
        NoBorder = 1 << 0,
        NoResize = 1 << 1,
        NoPreserveWidths = 1 << 2,
        NoForceWithinWindow = 1 << 3,
        GrowParentContentsSize = 1 << 4,
    }
}
