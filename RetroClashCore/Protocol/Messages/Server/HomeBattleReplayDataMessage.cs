﻿using System.Threading.Tasks;
using RetroClashCore.Helpers;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Messages.Server
{
    public class HomeBattleReplayDataMessage : PiranhaMessage
    {
        public HomeBattleReplayDataMessage(Device device) : base(device)
        {
            Id = 24114;
            Device.State = Enums.State.Replay;
        }

        public string Replay { get; set; }

        public override async Task Encode()
        {
            await Stream.WriteStringAsync(Replay);
        }
    }
}