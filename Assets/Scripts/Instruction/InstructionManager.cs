using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "LD47/Managers/Instruction Manager")]
    public class InstructionManager : ScriptableManager
    {
        private List<Instruction> _instructions = null;

        private int _currentInstructionIndex = 0;

        public override void Initialize()
        {
        }

        public void Refresh(Configuration configuration)
        {
            _currentInstructionIndex = 0;
            _instructions = configuration.instructions;

            EventManager.Instance.Trigger(GameplayEvent.InstructionsUpdated);
        }

        public bool Validate(InstructionAction action)
        {
            Instruction current = GetCurrentInstruction();

            // Invalid action
            if (current == null)
            {
                return false;
            }

            // Incorrect instruction
            if (current.requiredAction != action)
            {
                return false;
            }

            // Execute action
            current.completionAction?.Execute();

            // Go to next action
            _currentInstructionIndex++;

            // Notifiy listeners (UI)
            EventManager.Instance.Trigger(GameplayEvent.InstructionsUpdated);

            return true;
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
