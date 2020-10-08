using System;
using TMPro;
using UnityEngine;

namespace WorkSleepRepeat
{
    public class SecurityCameraOverlayUI : MonoBehaviour
    {
        [SerializeField]
        private int _camID = 1;

        [SerializeField]
        private TextMeshProUGUI _IDDisplay = null;

        [SerializeField]
        private TextMeshProUGUI _dateTime = null;

        private void Awake()
        {
            _IDDisplay.text = $"Cam {_camID}";
        }

        private void Update()
        {
            DateTime dateTime = DateTime.Now;
            _dateTime.text = $"TCR {dateTime.ToString("MM-dd")} {dateTime.ToString("HH:mm:ss")}";
        }
    }
}
