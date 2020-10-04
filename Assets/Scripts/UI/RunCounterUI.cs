using TMPro;
using Tools.Variables;
using UnityEngine;

namespace LD47
{
    public class RunCounterUI : EnableConfigurable
    {
        [SerializeField]
        private TextMeshProUGUI _counter = null;

        [SerializeField]
        private IntVariable _value = null;

        private void Awake()
        {
            _value.Subscribe(Refresh);
        }

        private void OnDestroy()
        {
            _value.Unsubscribe(Refresh);
        }

        private void Refresh()
        {
            _counter.text = $"#{_value.Value.ToString("0000")}";
        }
    }
}
