using System.Collections;
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
            Instruction instruction = _instructionManager.GetCurrentInstruction();

            if (instruction == null)
            {
                //_instructionText.gameObject.SetActive(false);
                StartCoroutine(Repeat());
            }
            else
            {
                StopAllCoroutines();
                _instructionText.text = _instructionManager.GetCurrentInstruction().description;
            }
        }

        private IEnumerator Repeat()
        {
            float duration = 1;
            float timer = 0;
            bool visible = true;

            _instructionText.text = "Repeat";

            while (enabled)
            {
                if (timer >= duration)
                {
                    visible = !visible;
                    _instructionText.gameObject.SetActive(visible);
                    timer = 0;
                }

                timer += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            _instructionText.gameObject.SetActive(true);
        }
    }
}
