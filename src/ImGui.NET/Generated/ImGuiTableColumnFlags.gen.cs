namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiTableColumnFlags
    {
        None = 0,
        DefaultHide = 1 << 0,
        DefaultSort = 1 << 1,
        WidthStretch = 1 << 2,
        WidthFixed = 1 << 3,
        NoResize = 1 << 4,
        NoReorder = 1 << 5,
        NoHide = 1 << 6,
        NoClip = 1 << 7,
        NoSort = 1 << 8,
        NoSortAscending = 1 << 9,
        NoSortDescending = 1 << 10,
        NoHeaderWidth = 1 << 11,
        PreferSortAscending = 1 << 12,
        PreferSortDescending = 1 << 13,
        IndentEnable = 1 << 14,
        IndentDisable = 1 << 15,
        IsEnabled = 1 << 20,
        IsVisible = 1 << 21,
        IsSorted = 1 << 22,
        IsHovered = 1 << 23,
        WidthMask = WidthStretch | WidthFixed,
        IndentMask = IndentEnable | IndentDisable,
        StatusMask = IsEnabled | IsVisible | IsSorted | IsHovered,
        NoDirectResize = 1 << 30,
    }
}
