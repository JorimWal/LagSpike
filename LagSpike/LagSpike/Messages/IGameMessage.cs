using Lidgren.Network;
public interface IGameMessage
{
    //GameMessageTypes MessageType { get; }
    void Encode(NetOutgoingMessage om);

    void Decode(NetIncomingMessage im);
}