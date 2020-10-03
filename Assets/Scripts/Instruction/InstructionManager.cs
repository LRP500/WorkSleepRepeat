using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "Managers/Instruction Manager")]
    public class InstructionManager : ScriptableManager
    {
        [SerializeField]
        private List<Instruction> _instructions = null;

        private int _currentInstructionIndex = 0;

        public void Validate(InstructionAction action)
        {
            Instruction current = GetCurrentInstruction();

            if (current.requiredAction == action)
            {
                current.complectionAction?.Execute();
            }

            NextInstruction();
        }

        public override void Initialize()
        {
            _currentInstructionIndex = 0;
        }

        public List<Instruction> GetInstructions()
        {
            return _instructions;
        }

        public Instruction GetCurrentInstruction()
        {
            return _instructions[_currentInstructionIndex];
        }

        public int GetCurrentIndex()
        {
            return _currentInstructionIndex;
        }

        private void NextInstruction()
        {
            if (_currentInstructionIndex < _instructions.Count - 1)
            {
                _currentInstructionIndex++;
                EventManager.Instance.Trigger(GameplayEvent.InstructionCompleted);
            }
        }
    } 
}
