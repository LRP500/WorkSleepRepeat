using UnityEngine;

namespace WorkSleepRepeat
{
    public class EnableOnCondition : MonoBehaviour
    {
        [SerializeField]
        private Condition _condition = null;

        private void Awake()
        {
            gameObject.SetActive(_condition.Evaluate());
        }
    }
}
