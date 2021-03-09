namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiSeparatorFlags
    {
        None = 0,
        Horizontal = 1 << 0,
        Vertical = 1 << 1,
        SpanAllColumns = 1 << 2,
    }
}
