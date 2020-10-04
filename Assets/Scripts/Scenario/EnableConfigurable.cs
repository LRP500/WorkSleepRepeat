using UnityEngine;

namespace LD47
{
    public class EnableConfigurable : Configurable
    {
        [SerializeField]
        private ConfigurableID _ID = ConfigurableID.None;

        private void Awake()
        {
            // Disabled by default
            gameObject.SetActive(false);
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
