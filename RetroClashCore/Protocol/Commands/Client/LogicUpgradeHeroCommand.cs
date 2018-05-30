﻿using System.Threading.Tasks;
using RetroClashCore.Extensions;
using RetroClashCore.Logic;

namespace RetroClashCore.Protocol.Commands.Client
{
    public class LogicUpgradeHeroCommand : LogicCommand
    {
        public LogicUpgradeHeroCommand(Device device, Reader reader) : base(device, reader)
        {
        }

        public int HeroId { get; set; }

        public override void Decode()
        {
            HeroId = Reader.ReadInt32();

            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            var hero = Device.Player.HeroManager.Get(HeroId);

            if (hero != null)
            {
                hero.Health = 0;
                hero.State = 3;
                hero.Upgrade();
            }
        }
    }
}