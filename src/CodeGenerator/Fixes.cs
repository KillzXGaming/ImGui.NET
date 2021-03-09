using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeGenerator
{
    public class Fixes
    {
        string[] files = new string[]
        {
            @"ImGuiStyleMod.gen.cs",
            @"ImGuiDockNode.gen.cs",
            @"ImGuiViewportP.gen.cs",
            @"ImGuiContext.gen.cs",
            @"ImGui.gen.cs",
			@"ImGuiDockNodeFlags.gen.cs"
		};

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}
		public void FixShit(string rootPath)
        {
			
			
			files = files.Select(x => Path.Combine(rootPath, x)).ToArray();

            processFileRemoveLines(files[0], "union");
            processFileReplaceText(files[1], "RangeAccessor<ImGuiDockNode*", "RangeAccessor<ImGuiDockNode");
            processFileReplaceText(files[2], "RangeAccessor<ImDrawList*", "RangeAccessor<ImDrawList");
            processFileRemoveLines(files[3], "ImChunkStream");
            processFileRemoveLines(files[3], "ImGuiItemFlagsPtr");
            processFileRemoveLines(files[3], "NativePtr->Tables");
            processFileRemoveLines(files[3], "NativePtr->TabBars");
            processFileRemoveLines(files[4], "Vector2 FindBestWindowPosForPopupEx", 8);
            processFileReplaceText(files[4], "IntPtr callback = null", "IntPtr callback = IntPtr.Zero");
            processFileReplaceText(files[4], "ImGuiPopupFlags_None", "ImGuiPopupFlags.None");
            processFileReplaceText(files[4], "ImGuiNavHighlightFlags_TypeDefault", "ImGuiNavHighlightFlags.TypeDefault");
            processFileReplaceText(files[4], "IntPtr custom_callback = null", "IntPtr custom_callback = IntPtr.Zero");
			processFileReplaceText(files[4], "ImGuiContext* ctx = IntPtr.Zero;", "ImGuiContext* ctx = null;");
			processFileReplaceText(files[5], "AutoHideTabBar = 1 << 6,", @" AutoHideTabBar = 1 << 6,
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
		NoResizeY = 1 << 22");

		}


		void processFileRemoveLines(string path, string remove, int nrLinesAfter)
		{
			string content = File.ReadAllText(path);
			string processed = RemoveLines(content, remove, nrLinesAfter);
			File.WriteAllText(path, processed);
		}

		void processFileRemoveLines(string path, string remove)
		{
			string content = File.ReadAllText(path);
			string processed = RemoveLines(content, remove);
			File.WriteAllText(path, processed);
		}

		void processFileReplaceText(string path, string replaceFrom, string replaceTo)
		{
			string content = File.ReadAllText(path);
			string processed = content.Replace(replaceFrom, replaceTo);

			File.WriteAllText(path, processed);
		}

		string RemoveLines(string s, string sRemove)
		{
			StringReader sr = new StringReader(s);

			StringBuilder sb = new StringBuilder();
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				if (!line.Contains(sRemove))
					sb.AppendLine(line);
			}
			return sb.ToString();

		}


		string RemoveLines(string s, string sRemove, int nrLinesAfter)
		{

			int dontAtFor = 0;
			StringReader sr = new StringReader(s);

			StringBuilder sb = new StringBuilder();
			string line;
			while ((line = sr.ReadLine()) != null)
			{


				if (line.Contains(sRemove))
				{
					dontAtFor = nrLinesAfter;
				}
				if (dontAtFor > 0)
				{
					dontAtFor--;
				}
				if (dontAtFor == 0)
					sb.AppendLine(line);
			}
			return sb.ToString();

		}



	}
}
