using System;
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

            if (current == null) return;

            if (current.requiredAction == action)
            {
                current.complectionAction?.Execute();
            }

            _currentInstructionIndex++;

            EventManager.Instance.Trigger(GameplayEvent.InstructionCompleted);
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
            if (_currentInstructionIndex >= _instructions.Count)
            {
                return null;
            }

            return _instructions[_currentInstructionIndex];
        }
    } 
}
