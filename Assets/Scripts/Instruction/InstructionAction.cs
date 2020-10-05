using UnityEngine;

namespace WorkSleepRepeat
{
    public class InstructionAction : Action
    {
        [SerializeField]
        private InstructionManager _instructionManager = null;

        public override void Execute()
        {
            _instructionManager.Validate(this);
        }
    }
}