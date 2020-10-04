using UnityEngine;

namespace LD47
{
    public class PlayerStatPanelUI : Configurable
    {
        [SerializeField]
        private CanvasGroup _canvasGroup = null;

        [SerializeField]
        private StatGaugeUI _hunger = null;

        [SerializeField]
        private StatGaugeUI _thirst = null;

        [SerializeField]
        private StatGaugeUI _happiness = null;

        public override void Configure(Configuration configuration)
        {
            _canvasGroup.alpha = configuration.displayStats ? 1 : 0;
            _hunger.Configure(configuration.hunger);
            _thirst.Configure(configuration.thirst);
            _happiness.Configure(configuration.happiness);
        }
    }
}