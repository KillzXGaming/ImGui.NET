namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiDockNodeFlags
    {
        None = 0,
        KeepAliveOnly = 1 << 0,
        NoDockingInCentralNode = 1 << 2,
        PassthruCentralNode = 1 << 3,
        NoSplit = 1 << 4,
        NoResize = 1 << 5,
         AutoHideTabBar = 1 << 6,
		DockSpace = 1 << 10,
		CentralNode = 1 << 11,
		NoTabBar = 1 << 12,
		HiddenTabBar = 1 << 13,
		NoWindowMenuButton = 1 << 14,
		NoCloseButton = 1 << 15,
		NoDocking = 1 << 16,
		NoDockingSplitMe = 1 << 17,
		NoDockingSplitOther = 1 << 18,
		NoDockingOverMe = 1 << 19,
		NoDockingOverOther = 1 << 20,
		NoResizeX = 1 << 21,
		NoResizeY = 1 << 22
    }
}
