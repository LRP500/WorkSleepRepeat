using Cinemachine;
using UnityEngine;

namespace LD47
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
