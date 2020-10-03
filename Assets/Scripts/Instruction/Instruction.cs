using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "Instruction")]
    public class Instruction : ScriptableObject
    {
        public string description = string.Empty;
        public InstructionAction requiredAction = null;
        public Action complectionAction = null;
    }
}
