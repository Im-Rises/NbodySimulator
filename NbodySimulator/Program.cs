using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace MyOpenTKExample;

public static class Program
{
    public static void Main()
    {
        var nativeWindowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(800, 600),
            Title = "My OpenTK Example Program"
        };

        using (var window = new MyExampleWindow(GameWindowSettings.Default,
                   nativeWindowSettings))
        {
            window.Run();
        }
    }
}

public class MyExampleWindow : GameWindow
{
    public MyExampleWindow(GameWindowSettings gameWindowSettings,
        NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings)
    {
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        // This gets called every 1/60 of a second.
        if (KeyboardState.IsKeyDown(Keys.Escape))
            Close();

        base.OnUpdateFrame(e);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        // Show that we can use OpenGL: Clear the window to cornflower blue.
        GL.ClearColor(0.39f, 0.58f, 0.93f, 1.0f);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        // Show in the window the results of the rendering calls.
        SwapBuffers();
    }
}
