
namespace GoingTerminal;

public static class Program {
    public static void Main() {
        using var game = new GoingTerminalEngine.Engine(
            // Put all scenes here
            typeof(Scenes.MainScene)
        );

        game.Run();
    }
}
