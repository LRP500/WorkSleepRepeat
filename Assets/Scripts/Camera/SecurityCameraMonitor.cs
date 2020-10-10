using UnityEngine;
using UnityEngine.UI;

namespace WorkSleepRepeat
{
    public class SecurityCameraMonitor : MonoBehaviour
    {
        [SerializeField]
        private RawImage _screenImage = null;

        private void Awake()
        {
            _screenImage.material = Instantiate(_screenImage.material);
        }
    }
}
