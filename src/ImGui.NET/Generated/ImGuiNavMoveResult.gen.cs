using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiNavMoveResult
    {
        public ImGuiWindow* Window;
        public uint ID;
        public uint FocusScopeId;
        public float DistBox;
        public float DistCenter;
        public float DistAxial;
        public ImRect RectRel;
    }
    public unsafe partial struct ImGuiNavMoveResultPtr
    {
        public ImGuiNavMoveResult* NativePtr { get; }
        public ImGuiNavMoveResultPtr(ImGuiNavMoveResult* nativePtr) => NativePtr = nativePtr;
        public ImGuiNavMoveResultPtr(IntPtr nativePtr) => NativePtr = (ImGuiNavMoveResult*)nativePtr;
        public static implicit operator ImGuiNavMoveResultPtr(ImGuiNavMoveResult* nativePtr) => new ImGuiNavMoveResultPtr(nativePtr);
        public static implicit operator ImGuiNavMoveResult* (ImGuiNavMoveResultPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiNavMoveResultPtr(IntPtr nativePtr) => new ImGuiNavMoveResultPtr(nativePtr);
        public ImGuiWindowPtr Window => new ImGuiWindowPtr(NativePtr->Window);
        public ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);
        public ref uint FocusScopeId => ref Unsafe.AsRef<uint>(&NativePtr->FocusScopeId);
        public ref float DistBox => ref Unsafe.AsRef<float>(&NativePtr->DistBox);
        public ref float DistCenter => ref Unsafe.AsRef<float>(&NativePtr->DistCenter);
        public ref float DistAxial => ref Unsafe.AsRef<float>(&NativePtr->DistAxial);
        public ref ImRect RectRel => ref Unsafe.AsRef<ImRect>(&NativePtr->RectRel);
        public void Clear()
        {
            ImGuiNative.ImGuiNavMoveResult_Clear((ImGuiNavMoveResult*)(NativePtr));
        }
        public void Destroy()
        {
            ImGuiNative.ImGuiNavMoveResult_destroy((ImGuiNavMoveResult*)(NativePtr));
        }
    }
}
