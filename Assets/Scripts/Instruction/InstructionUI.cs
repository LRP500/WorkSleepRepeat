using TMPro;
using UnityEngine;

namespace WorkSleepRepeat
{
    public class InstructionUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _description = null;

        [SerializeField]
        private GameObject _overlay = null;

        private Instruction _instruction = null;

        public void SetInstruction(Instruction instruction, int index, bool current)
        {
            _instruction = instruction;
            _description.text = $"{index} - {instruction.description}";
            _overlay.SetActive(current);
            _description.color = current ? Color.white : Color.black;
        }
    }
}
