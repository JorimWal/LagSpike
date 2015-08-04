using Lidgren.Network;
using Lidgren.Network.Xna;
using Microsoft.Xna.Framework;
public class UpdateMessage : IGameMessage
{
    public UpdateMessage(NetIncomingMessage im)
    {
        this.Decode(im);
    }

    public UpdateMessage(GameObject gameobject)
    {
        this.ID = gameobject.ID;
        //this.Position = asteroid.SimulationState.Position;
        //this.Velocity = asteroid.SimulationState.Velocity;
        //this.Rotation = asteroid.SimulationState.Rotation;
        this.MessageTime = NetTime.Now;
    }

    public long ID { get; set; }

    public double MessageTime { get; set; }

    public Vector2 Position { get; set; }

    public float Rotation { get; set; }

    public Vector2 Velocity { get; set; }

    //public GameMessageTypes MessageType
    //{
    //    get { return GameMessageTypes.Create; }
    //}

    public void Decode(NetIncomingMessage im)
    {
        this.ID = im.ReadInt64();
        this.MessageTime = im.ReadDouble();
        this.Position = im.ReadVector2();
        this.Velocity = im.ReadVector2();
        this.Rotation = im.ReadSingle();
    }

    public void Encode(NetOutgoingMessage om)
    {
        om.Write(this.ID);
        om.Write(this.MessageTime);
        om.Write(this.Position);
        om.Write(this.Velocity);
        om.Write(this.Rotation);
    }
}