using UnityEngine;

namespace LD47
{
    public class PlayerStatPanelUI : EnableConfigurable
    {
        [SerializeField]
        private StatGaugeUI _hunger = null;

        [SerializeField]
        private StatGaugeUI _thirst = null;

        [SerializeField]
        private StatGaugeUI _happiness = null;

        public override void Configure(Configuration configuration)
        {
            base.Configure(configuration);

            _hunger.Configure(configuration.hunger);
            _thirst.Configure(configuration.thirst);
            _happiness.Configure(configuration.happiness);
        }
    }
}