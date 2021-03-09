namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiNavMoveFlags
    {
        None = 0,
        LoopX = 1 << 0,
        LoopY = 1 << 1,
        WrapX = 1 << 2,
        WrapY = 1 << 3,
        AllowCurrentNavId = 1 << 4,
        AlsoScoreVisibleSet = 1 << 5,
        ScrollToEdge = 1 << 6,
    }
}
