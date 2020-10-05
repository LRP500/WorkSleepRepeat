using UnityEngine;
using UnityEngine.UI;

namespace LD47
{
    public class ImageFillSetter : MonoBehaviour
    {
        [SerializeField]
        private Image _image = null;

        private float _min;
        private float _max;

        public void Initialize(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public void SetFillValue(float value)
        {
           _image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(_min, _max, value));
        }
    }
}
