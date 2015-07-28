using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class GameObject : IGameLoopObject
{
    protected GameObject parent;
    protected Vector2 position, velocity;
    protected int layer, id;
    protected string type;
    protected bool visible;

    public GameObject(int layer = 0, int id = 0, string type = "")
    {
        this.layer = layer;
        this.id = id;
        this.type = type;
        this.position = Vector2.Zero;
        this.velocity = Vector2.Zero;
        this.visible = true;
    }

    public virtual void HandleInput(InputHelper inputHelper)
    {
    }

    public virtual void Update(GameTime gameTime)
    {
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }

    public virtual void Reset()
    {
        visible = true;
    }

    public virtual Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    public virtual Vector2 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public virtual Vector2 GlobalPosition
    {
        get
        {
            if (parent != null)
                return parent.GlobalPosition + this.Position;
            else
                return this.Position;
        }
    }

    public virtual int Layer
    {
        get { return layer; }
        set { layer = value; }
    }

    public virtual GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    public string TypeID
    {
        get { return type + " " + id; }
    }

    public string Type
    {
        get { return type; }
    }

    public int ID
    {
        get { return id; }
    }

    public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }

    public virtual Rectangle BoundingBox
    {
        get
        {
            return new Rectangle((int)GlobalPosition.X, (int)GlobalPosition.Y, 0, 0);
        }
    }
}

