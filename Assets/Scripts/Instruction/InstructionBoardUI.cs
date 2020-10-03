using TMPro;
using Tools;
using UnityEngine;

namespace LD47
{
    public class InstructionBoardUI : MonoBehaviour
    {
        [SerializeField]
        private InstructionManager _instructionManager = null;

        [SerializeField]
        private TextMeshProUGUI _instructionText = null;

        private void Awake()
        {
            EventManager.Instance.Subscribe(GameplayEvent.InstructionCompleted, OnInstructionCompleted);
        }

        private void Start()
        {
            Refresh();
        }

        private void OnDisable()
        {
            EventManager.Instance.Unsubscribe(GameplayEvent.InstructionCompleted, OnInstructionCompleted);
        }

        private void OnInstructionCompleted(object arg)
        {
            Refresh();
        }

        public void Refresh()
        {
            _instructionText.text = _instructionManager.GetCurrentInstruction().description;
        }
    }
}
