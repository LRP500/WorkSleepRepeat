using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "Actions/Instruction Actions/Work")]
    public class InstructionActionWork : InstructionAction
    {
        public override void Execute()
        {
            base.Execute();

            Debug.Log("Work");
        }
    }
}
