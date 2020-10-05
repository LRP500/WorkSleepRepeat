using TMPro;
using UnityEngine;

namespace WorkSleepRepeat
{
    public class RunCounterUI : EnableConfigurable
    {
        [SerializeField]
        private TextMeshProUGUI _counter = null;

        public override void Configure(Configuration configuration)
        {
            base.Configure(configuration);
            _counter.text = $"Subject ID: #{configuration.subjectID.ToString("0000")}";
        }
    }
}
