﻿using System.Threading.Tasks;
using RetroClashCore.Helpers;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class VisitedHomeDataMessage : PiranhaMessage
    {
        public VisitedHomeDataMessage(Device device) : base(device)
        {
            Id = 24113;
            Device.State = Enums.State.Visiting;
        }

        public long AvatarId { get; set; }

        public override async Task Encode()
        {
            await Stream.WriteIntAsync(0);

            var player = await Resources.PlayerCache.GetPlayer(AvatarId);

            await player.LogicClientHome(Stream);
            await player.LogicClientAvatar(Stream);

            Stream.WriteByte(1);
            await Device.Player.LogicClientAvatar(Stream);
        }
    }
}