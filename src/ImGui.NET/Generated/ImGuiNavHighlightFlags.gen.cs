namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiNavHighlightFlags
    {
        None = 0,
        TypeDefault = 1 << 0,
        TypeThin = 1 << 1,
        AlwaysDraw = 1 << 2,
        NoRounding = 1 << 3,
    }
}
