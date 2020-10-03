using TMPro;
using Tools.Variables;
using UnityEngine;

namespace LD47
{
    public class RunCounterUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup = null;

        [SerializeField]
        private TextMeshProUGUI _counter = null;

        [SerializeField]
        private IntVariable _value = null;

        private void Awake()
        {
            _value.Subscribe(Refresh);
        }

        private void Start()
        {
            Refresh();
            Show();
        }

        private void OnDestroy()
        {
            _value.Unsubscribe(Refresh);
        }

        private void Refresh()
        {
            _counter.text = $"#{_value.Value.ToString("0000")}";
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }
    }
}
