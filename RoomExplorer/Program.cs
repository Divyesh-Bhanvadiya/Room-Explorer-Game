using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace RoomExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Title = "Room Explorer"
            };

            nativeWindowSettings.ClientSize = new Vector2i(1000, 600);
            
            using (Game game = new Game(GameWindowSettings.Default, nativeWindowSettings))
            {
                game.Run();
            }
        }
    }
}