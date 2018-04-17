﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;

namespace RetroClash.Protocol.Messages.Server
{
    public class AvatarProfile : Message
    {
        public AvatarProfile(Device device) : base(device)
        {
            Id = 24334;
        }

        public long UserId { get; set; }

        public override async Task Encode()
        {
            if (UserId == Device.Player.AccountId)
            {
                await Device.Player.LogicClientAvatar(Stream);

                await Stream.WriteIntAsync(0); // Troops Donated
                await Stream.WriteIntAsync(0); // Troops Received               
            }
            else
            {
                await (await Resources.Cache.GetPlayer(UserId)).LogicClientAvatar(Stream);

                await Stream.WriteIntAsync(0); // Troops Donated
                await Stream.WriteIntAsync(0); // Troops Received
            }
        }
    }
}