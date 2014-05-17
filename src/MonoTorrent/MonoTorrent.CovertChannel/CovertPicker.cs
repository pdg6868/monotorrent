using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client.Messages;
using MonoTorrent.Common;
using MonoTorrent.Client;

namespace MonoTorrent.CovertChannel
{
    public class CovertPicker : RandomisedPicker
    {
        public CovertPicker (PiecePicker picker):
            base(picker)
        {
            //var addr = CovertChannel.targetPeerId.AddressBytes;
            //string ip = addr.Host;
            Console.WriteLine ("Foo");
        }

        public override MessageBundle PickPiece (PeerId id, BitField peerBitfield, 
            List<PeerId> otherPeers, int count, int startIndex, int endIndex)
        {
            /*
            //if (id == CovertChannel.targetPeerId) {
                //The id is who you are trying to send message to
                return base.PickPiece (id, peerBitfield, otherPeers, count, startIndex, endIndex);
            } else {
            */
                return base.PickPiece (id, peerBitfield, otherPeers, count, startIndex, endIndex);

        }
    }
}

