using Cinemachine;
using UnityEngine;

namespace WorkSleepRepeat
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class DisableVirtualCamera : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }
}
