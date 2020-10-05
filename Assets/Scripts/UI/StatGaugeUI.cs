using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static WorkSleepRepeat.Configuration;

namespace WorkSleepRepeat
{
    public class StatGaugeUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _label = null;

        [SerializeField]
        private TextMeshProUGUI _valueDisplay = null;

        [SerializeField]
        private Image _border = null;

        [SerializeField]
        private Image _fill = null;

        [SerializeField]
        private ImageFillSetter _fillSetter = null;

        [SerializeField]
        private Color _criticalColor = Color.red;

        [SerializeField]
        private Color _disabledColor = Color.white;

        public void Configure(StatConfiguration config)
        {
            _fillSetter.Initialize(0, 100);

            if (config.enabled)
            {
                _fillSetter.SetFillValue(config.value);
                _valueDisplay.text = $"{config.value.ToString("00.00")}%";
                SetColor(config.value < 30 ? _criticalColor : Color.white);
            }
            else
            {
                _fillSetter.SetFillValue(0);
                _valueDisplay.text = "???";
                SetColor(_disabledColor);
            }
        }

        public void SetColor(Color color)
        {
            _label.color = color;
            _valueDisplay.color = color;
            _border.color = color;
            _fill.color = color;
        }
    }
}
