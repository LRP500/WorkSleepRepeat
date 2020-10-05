using TMPro;
using UnityEngine;

namespace WorkSleepRepeat
{
    public class MonitorScreenUI : EnableConfigurable
    {
        [SerializeField]
        private TextMeshProUGUI _subjectID = null;

        public override void Configure(Configuration configuration)
        {
            base.Configure(configuration);

            _subjectID.text = $"Subject ID: #{configuration.subjectID.ToString("0000")}";
        }
    }
}
