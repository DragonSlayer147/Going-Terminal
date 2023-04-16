
namespace GoingTerminal;

public static class Program {
    public static void Main() {
        using var game = new GoingTerminal.MainGame();
        game.Run();
    }
}
