﻿using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXMS")]
    public class HyperDeckSettingsGetCommand : ICommand
    {
        public uint Id { get; set; }
        public string NetworkAddress { get; set; }
        public VideoSource Input { get; set; }
        public bool AutoRoll { get; set; }
        public uint AutoRollFrameDelay { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.Pad(2);
            cmd.AddByte(IPUtil.ParseAddress(NetworkAddress));
            cmd.AddUInt16((uint)Input);
            cmd.AddBoolArray(AutoRoll);
            cmd.Pad();
            cmd.AddUInt8(AutoRollFrameDelay); // TODO - this causes the delay to report as either 0 or 60 (min or max)
            cmd.Pad(7);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(2);
            NetworkAddress = IPUtil.IPToString(cmd.GetByte(), cmd.GetByte(), cmd.GetByte(), cmd.GetByte());
            Input = (VideoSource)cmd.GetUInt16();
            AutoRoll = cmd.GetBoolArray()[0];
            cmd.Skip();
            AutoRollFrameDelay = cmd.GetUInt8(0, 60);
            cmd.Skip(7);
        }
    }
}