using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "Work Sleep Repeat/Conditions/Critical Health")]
    public class CriticalHealthCondition : Condition
    {
        [SerializeField]
        private ConfigurationManager _configurationManager = null;

        [Range(0, 100)]
        [SerializeField]
        private float _criticalThreshold = 10f;

        public override bool Evaluate()
        {
            Configuration config = _configurationManager.GetCurrent();
            return config.hunger.value <= _criticalThreshold || config.thirst.value <= _criticalThreshold;
        }
    }
}
