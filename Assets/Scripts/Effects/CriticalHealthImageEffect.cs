using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace WorkSleepRepeat
{
    [RequireComponent(typeof(Volume))]
    public class CriticalHealthImageEffect : MonoBehaviour
    {
        [SerializeField]
        private bool _animate = true;

        [Range(0, 1)]
        [SerializeField]
        [ShowIf(nameof(_animate))]
        private float _pulseSpeed = 0.1f;

        [SerializeField]
        [ShowIf(nameof(_animate))]
        [MinMaxSlider(0.1f, 0.5f, ShowFields = true)]
        private Vector2 _blurIntensityRange = new Vector2(0.1f, 0.5f);

        [SerializeField]
        [ShowIf(nameof(_animate))]
        [MinMaxSlider(0f, 1f, ShowFields = true)]
        private Vector2 _vignetteIntensityRange = new Vector2(0.25f, 0.75f);

        private Volume _postProcessingVolume = null;

        private void OnEnable()
        {
            if (_animate)
            {
                StartCoroutine(Animate());
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Animate()
        {
            _postProcessingVolume = GetComponent<Volume>();
            _postProcessingVolume.profile.TryGet(out DepthOfField dof);
            _postProcessingVolume.profile.TryGet(out Vignette vignette);

            dof.active = true;
            dof.mode.value = DepthOfFieldMode.Bokeh;
            vignette.active = true;

            float start = 0;
            while (isActiveAndEnabled)
            {
                start += Time.deltaTime;
                float t = Mathf.PingPong(start * _pulseSpeed, 1);
                dof.focusDistance.value = Mathf.SmoothStep(_blurIntensityRange.x, _blurIntensityRange.y, t);
                vignette.intensity.value = Mathf.SmoothStep(_vignetteIntensityRange.x, _vignetteIntensityRange.y, 1 - t);
                yield return null;
            }
        }
    }
}