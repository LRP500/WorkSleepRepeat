using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "Actions/Instruction Actions/Sleep")]
    public class InstructionActionSleep : InstructionAction
    {
        public override void Execute()
        {
            base.Execute();

            Debug.Log("Sleep");
        }
    }
}
