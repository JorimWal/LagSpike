using Microsoft.Xna.Framework;

class Button : SpriteGameObject
{
    protected bool pressed;

    public Button(string assetname, int layer = 0, int id = 0, string type = "")
        : base(assetname, layer, id, type)
    {
        pressed = false;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        pressed = inputHelper.MouseLeftButtonPressed() &&
            BoundingBox.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y);
    }

    public override void Reset()
    {
        base.Reset();
        pressed = false;
    }

    public bool Pressed
    {
        get { return pressed; }
    }
}
