using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace LD47
{
    public class InstructionBoardUI : MonoBehaviour
    {
        [SerializeField]
        private InstructionManager _instructionManager = null;

        [SerializeField]
        private InstructionUI _instructionPrefab = null;

        [SerializeField]
        private Transform _instructionContainer = null;

        private List<InstructionUI> _instructions = null;

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
            Clear();

            var instructions = _instructionManager.GetInstructions();
            for (int i = 0, length = instructions.Count; i < length; i++)
            {
                InstructionUI instance = Instantiate(_instructionPrefab, _instructionContainer);
                instance.SetInstruction(instructions[i], i + 1, i == _instructionManager.GetCurrentIndex());
                _instructions.Add(instance);
            }
        }

        private void Clear()
        {
            _instructions = _instructions ?? new List<InstructionUI>();

            foreach (InstructionUI item in _instructions)
            {
                Destroy(item.gameObject);
            }

            _instructions.Clear();
        }
    }
}
