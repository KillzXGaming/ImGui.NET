namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiItemFlags
    {
        None = 0,
        NoTabStop = 1 << 0,
        ButtonRepeat = 1 << 1,
        Disabled = 1 << 2,
        NoNav = 1 << 3,
        NoNavDefaultFocus = 1 << 4,
        SelectableDontClosePopup = 1 << 5,
        MixedValue = 1 << 6,
        ReadOnly = 1 << 7,
        Default = 0,
    }
}
