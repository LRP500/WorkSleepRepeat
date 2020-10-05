using UnityEngine;

namespace WorkSleepRepeat
{
    public class EnableConfigurable : Configurable
    {
        [SerializeField]
        private ConfigurableID _ID = ConfigurableID.None;

        [SerializeField]
        private bool _enabledByDefault = false;

        private void Awake()
        {
            gameObject.SetActive(_enabledByDefault);
        }

        public override void Configure(Configuration configuration)
        {
            if (configuration.Contains(_ID))
            {
                gameObject.SetActive(configuration.GetState(_ID));
            }
        }
    }
}
