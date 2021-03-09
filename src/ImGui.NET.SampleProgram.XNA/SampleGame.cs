using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Num = System.Numerics;

namespace ImGuiNET.SampleProgram.XNA
{
    /// <summary>
    /// Simple FNA + ImGui example
    /// </summary>
    public class SampleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private ImGuiRenderer _imGuiRenderer;

        private Texture2D _xnaTexture;
        private IntPtr _imGuiTexture;

        
        public SampleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.PreferMultiSampling = true;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
//            var v = ImGui.GetFrameCount();
            _imGuiRenderer = new ImGuiRenderer(this);
            _imGuiRenderer.RebuildFontAtlas();            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Texture loading example

			// First, load the texture as a Texture2D (can also be done using the XNA/FNA content pipeline)
			_xnaTexture = CreateTexture(GraphicsDevice, 300, 150, pixel =>
			{
				var red = (pixel % 300) / 2;
				return new Color(red, 1, 1);
			});

			// Then, bind it to an ImGui-friendly pointer, that we can use during regular ImGui.** calls (see below)
			_imGuiTexture = _imGuiRenderer.BindTexture(_xnaTexture);

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(clear_color.X, clear_color.Y, clear_color.Z));

            // Call BeforeLayout first to set things up
            _imGuiRenderer.BeforeLayout(gameTime);

            // Draw our UI
            ImGuiLayout();

            // Call AfterLayout now to finish up and draw all the things
            _imGuiRenderer.AfterLayout();

            base.Draw(gameTime);
        }

        // Direct port of the example at https://github.com/ocornut/imgui/blob/master/examples/sdl_opengl2_example/main.cpp
        private float f = 0.0f;

        private bool show_test_window = false;
        private bool show_another_window = true;
        private bool show_another_window2 = true;
        private Num.Vector3 clear_color = new Num.Vector3(114f / 255f, 144f / 255f, 154f / 255f);
        private byte[] _textBuffer = new byte[100];

        protected unsafe virtual void ImGuiLayout()
        {






            // 1. Show a simple window
            // Tip: if we don't call ImGui.Begin()/ImGui.End() the widgets appears in a window automatically called "Debug"
            {
                ImGuiDockNodeFlags dockspace_flags = ImGuiDockNodeFlags.DockSpace;
                ImGuiWindowFlags window_flags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoDocking;

                var vp = ImGui.GetMainViewport();
                ImGui.SetNextWindowPos(vp.WorkPos);
                ImGui.SetNextWindowSize(vp.WorkSize);
                ImGui.SetNextWindowViewport(vp.ID);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
                window_flags = window_flags | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
                window_flags = window_flags | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Num.Vector2(0.0f, 0.0f));
                ImGui.Begin("ddemo", window_flags);
                ImGui.PopStyleVar();
                ImGui.PopStyleVar(2);
                //                ImGui.DockBuilderAddNode();

                var io = ImGui.GetIO();
                uint dockspaceId = 0;

                if ((((int)io.ConfigFlags) & (int)ImGuiConfigFlags.DockingEnable) == (int)ImGuiConfigFlags.DockingEnable)
                {
                    System.Console.WriteLine("enabled = ");
                    dockspaceId = ImGui.GetID("MyDockSpace");
//                    ImGui.DockSpace(dockspaceId, new Num.Vector2(0.0f, 0.0f), ImGuiDockNodeFlags.None);

                    if(ImGui.DockBuilderGetNode(dockspaceId).NativePtr == null)
                    {
                        ImGui.DockBuilderRemoveNode(dockspaceId);
                        ImGui.DockBuilderAddNode(dockspaceId, ImGuiDockNodeFlags.DockSpace);
                        ImGui.DockBuilderSetNodeSize(dockspaceId, vp.Size);
                        
                        uint outt;
                        uint dock_main_id = dockspaceId;

                        uint right;
                        uint left;

                        var dock_up_id = ImGui.DockBuilderSplitNode(dock_main_id, ImGuiDir.Right, 0.7f, out left, out right);

                        ImGui.DockBuilderDockWindow("ImageView", right);
                        ImGui.DockBuilderDockWindow("ImportView", left);

//                        ImGui.DockBuilderDockWindow("ASD", dock_up_id);


                        ImGui.DockBuilderFinish(dock_main_id);

                    }
                    ImGui.DockSpace(dockspaceId, new Num.Vector2(0,0), dockspace_flags);

                }
                else
                {
                    System.Console.WriteLine("notenabled = ");
                    io.ConfigFlags = io.ConfigFlags | ImGuiConfigFlags.DockingEnable;
                }

//                if(ImGui.BeginMenuBar())
  //              {
    //                ImGui.MenuItem("asdasd");
      //              ImGui.EndMenu();
        //        }

                //ImGui.SliderFloat("float", ref f, 0.0f, 1.0f, string.Empty);
                //ImGui.ColorEdit3("clear color", ref clear_color);
                //if (ImGui.Button("Test Window")) show_test_window = !show_test_window;
                //if (ImGui.Button("Another Window")) show_another_window = !show_another_window;
                //ImGui.Text(string.Format("Application average {0:F3} ms/frame ({1:F1} FPS)", 1000f / ImGui.GetIO().Framerate, ImGui.GetIO().Framerate));

                //ImGui.InputText("Text input", _textBuffer, 100);

                //ImGui.Text("Texture sample");
                //ImGui.Image(_imGuiTexture, new Num.Vector2(300, 150), Num.Vector2.Zero, Num.Vector2.One, Num.Vector4.One, Num.Vector4.One); // Here, the previously loaded texture is used
            }

            // 2. Show another simple window, this time using an explicit Begin/End pair
            if (show_another_window)
            {
                //ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGui.Begin("ImageView", ref show_another_window);
                ImGui.Text("Hello");
                ImGui.End();


            }

            if (show_another_window2)
            {
                //ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGui.Begin("ImportView", ref show_another_window2);
                ImGui.Text("Hello2");
                ImGui.End();


            }

            // 3. Show the ImGui test window. Most of the sample code is in ImGui.ShowTestWindow()
            if (show_test_window)
            {
                //ImGui.SetNextWindowPos(new Num.Vector2(650, 20), ImGuiCond.FirstUseEver);
                //ImGui.ShowDemoWindow(ref show_test_window);
            }
            ImGui.End();
        }

		public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint)
		{
			//initialize a texture
			var texture = new Texture2D(device, width, height);

			//the array holds the color for each pixel in the texture
			Color[] data = new Color[width * height];
			for(var pixel = 0; pixel < data.Length; pixel++)
			{
				//the function applies the color according to the specified pixel
				data[pixel] = paint( pixel );
			}

			//set the color
			texture.SetData( data );

			return texture;
		}
	}
}