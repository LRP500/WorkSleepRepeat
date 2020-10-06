using UnityEngine;

namespace WorkSleepRepeat
{
    public class DisableOnCondition : MonoBehaviour
    {
        [SerializeField]
        private Condition _condition = null;

        private void Awake()
        {
            gameObject.SetActive(!_condition.Evaluate());
        }
    }
}
