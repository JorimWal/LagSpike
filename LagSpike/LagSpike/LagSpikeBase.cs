using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class LagSpikeBase : BaseGame
{
    static void Main()
    {
        LagSpikeBase game = new LagSpikeBase();
        game.Run();
    }

    public LagSpikeBase()
    {
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        screen = new Point(1440, 825);
        this.SetFullScreen(false);

        gameStateManager.AddGameState("titleMenu", new TitleMenuState());
        gameStateManager.SwitchTo("titleMenu");
    }
}