namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiViewportFlags
    {
        None = 0,
        IsPlatformWindow = 1 << 0,
        IsPlatformMonitor = 1 << 1,
        OwnedByApp = 1 << 2,
        NoDecoration = 1 << 3,
        NoTaskBarIcon = 1 << 4,
        NoFocusOnAppearing = 1 << 5,
        NoFocusOnClick = 1 << 6,
        NoInputs = 1 << 7,
        NoRendererClear = 1 << 8,
        TopMost = 1 << 9,
        Minimized = 1 << 10,
        NoAutoMerge = 1 << 11,
        CanHostOtherWindows = 1 << 12,
    }
}
