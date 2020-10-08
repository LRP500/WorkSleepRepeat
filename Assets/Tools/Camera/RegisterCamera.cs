using Tools.Variables;
using UnityEngine;

namespace Tools.Cinematics
{
    [RequireComponent(typeof(Camera))]
    public class RegisterCamera : MonoBehaviour
    {
        [SerializeField]
        private CameraVariable _cameraVariable = null;

        private void Awake()
        {
            _cameraVariable?.SetValue(GetComponent<Camera>());
        }

        private void OnDestroy()
        {
            _cameraVariable?.Clear();
        }
    }
}
