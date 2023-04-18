
namespace GoingTerminal;

public static class Program {
    public static void Main() {
        using var game = new GoingTerminalEngine.Engine(typeof(Scenes.MainScene));
        game.Run();
    }
}
