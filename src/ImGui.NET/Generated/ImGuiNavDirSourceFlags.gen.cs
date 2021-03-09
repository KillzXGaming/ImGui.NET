namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiNavDirSourceFlags
    {
        None = 0,
        Keyboard = 1 << 0,
        PadDPad = 1 << 1,
        PadLStick = 1 << 2,
    }
}
