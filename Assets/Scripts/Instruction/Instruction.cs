using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "LD47/Instruction")]
    public class Instruction : ScriptableObject
    {
        public string description = string.Empty;
        public InstructionAction requiredAction = null;
        public Action completionAction = null;
    }
}
