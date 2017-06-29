﻿using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands
{
    [CommandName("TlSr")]
    public class TallyBySourceCommand : ICommand
    {
        public Dictionary<VideoSource, Tuple<bool, bool>> Tally { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Tally.Count);

            foreach (var src in Tally)
            {
                cmd.AddUInt16((int) src.Key);
                cmd.AddBoolArray(src.Value.Item1, src.Value.Item2);
            }

            cmd.PadToNearestPowerOfTwo();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            uint count = cmd.GetUInt16();
            Tally = new Dictionary<VideoSource, Tuple<bool, bool>>();

            for (int i = 0; i < count; i++)
            {
                VideoSource src = (VideoSource) cmd.GetUInt16();
                bool[] arr = cmd.GetBoolArray();
                Tally.Add(src, Tuple.Create(arr[0], arr[1]));
            }

            cmd.SkipToNearestPowerOfTwo();
        }
    }
}