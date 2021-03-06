﻿using System.Threading.Tasks;
using RetroClashCore.Helpers;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class NpcDataMessage : PiranhaMessage
    {
        public NpcDataMessage(Device device) : base(device)
        {
            Id = 24133;
            Device.State = Enums.State.Npc;
        }

        public int NpcId { get; set; }

        public override async Task Encode()
        {
            await Stream.WriteIntAsync(0);

            await Stream.WriteStringAsync(Resources.Levels.NpcLevels[NpcId - 17000000]);

            await Device.Player.LogicClientAvatar(Stream);

            await Stream.WriteIntAsync(0);

            await Stream.WriteIntAsync(NpcId);
        }
    }
}