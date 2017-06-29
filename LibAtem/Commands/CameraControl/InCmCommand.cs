﻿namespace LibAtem.Commands.CameraControl
{
    [CommandName("InCm")]
    public class InCmCommand : ICommand
    {
        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddByte(0x01, 0x00); // ??
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip(4);
        }
    }
}