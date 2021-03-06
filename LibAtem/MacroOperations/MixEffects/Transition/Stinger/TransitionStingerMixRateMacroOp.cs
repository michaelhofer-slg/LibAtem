using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerMixRate, 8)]
    public class TransitionStingerMixRateMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt8Range(0, 250)]
        [MacroField("MixRate")]
        public uint MixRate { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.MixRate,
                Index = Index,
                MixRate = MixRate,
            };
        }
    }
}