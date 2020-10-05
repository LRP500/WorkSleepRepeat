using Cinemachine;
using UnityEngine;

namespace WorkSleepRepeat
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class VirtualCameraVariableSetter : MonoBehaviour
    {
        [SerializeField]
        private VirtualCameraVariable _variable = null;

        private void Awake()
        {
            _variable.SetValue(GetComponent<CinemachineVirtualCamera>());
        }

        private void OnDestroy()
        {
            _variable.SetValue(null);
        }
    }
}
