﻿using System.Threading.Tasks;
using RetroClash.Extensions;
using RetroClash.Logic;

namespace RetroClash.Protocol.Commands.Client
{
    public class LogicBoostBuilding : Command
    {
        public LogicBoostBuilding(Device device, Reader reader) : base(device, reader)
        {            
        }
        
        public int BuildingId { get; set; }

        public override void Decode()
        {
            BuildingId = Reader.ReadInt32();
            Reader.ReadInt32();
        }

        public override async Task Process()
        {
            Device.Player.LogicGameObjectManager.BoostBuilding(BuildingId);
        }
    }
}
