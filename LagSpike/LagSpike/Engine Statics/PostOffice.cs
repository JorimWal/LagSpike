using Microsoft.Xna.Framework;
using Lidgren.Network;
using Lidgren.Network.Xna;
using Lidgren;
using System;

namespace LagSpike.Engine_Statics
{
    class PostOffice
    {
        public PostOffice()
        {

        }

        public void SendUpdateMessage(GameObject gameObj)
        {
            //NetOutgoingMessage om = netServer.CreateMessage();
            //om.Write((byte)gameMessage.MessageType);
            //gameMessage.Encode(om);

            //netServer.SendToAll(om, NetDeliveryMethod.);
        }
        //private void ProcessNetworkMessages()
        //{
        //    NetIncomingMessage im;

        //    while ((im = this.networkManager.ReadMessage()) != null)
        //    {
        //        switch (im.MessageType)
        //        {
        //            case NetIncomingMessageType.VerboseDebugMessage:
        //            case NetIncomingMessageType.DebugMessage:
        //            case NetIncomingMessageType.WarningMessage:
        //            case NetIncomingMessageType.ErrorMessage:
        //                Console.WriteLine(im.ReadString());
        //                break;
        //            case NetIncomingMessageType.StatusChanged:
        //                switch ((NetConnectionStatus)im.ReadByte())
        //                {
        //                    case NetConnectionStatus.Connected:
        //                        Console.WriteLine("{0} Connected", im.SenderEndpoint);
        //                        break;
        //                    case NetConnectionStatus.Disconnected:
        //                        Console.WriteLine("{0} Disconnected", im.SenderEndpoint);
        //                        break;
        //                    case NetConnectionStatus.RespondedAwaitingApproval:
        //                        im.SenderConnection.Approve();
        //                        break;
        //                }
        //                break;
        //        }

        //        this.networkManager.Recycle(im);
        //    }
        //}
    }
}
