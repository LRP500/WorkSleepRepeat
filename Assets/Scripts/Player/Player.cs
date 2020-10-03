using Cinemachine;
using UnityEngine;

namespace LD47
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _camera = null;
        public CinemachineVirtualCamera Camera => _camera;

        [SerializeField]
        private GameObject _playerBody = null;

        [SerializeField]
        private PlayerVariable _runtimeReference = null;

        [SerializeField]
        private CameraManager _cameraManager = null;

        private void Awake()
        {
            _runtimeReference.SetValue(this);
        }

        private void Start()
        {
            _cameraManager.TransitionTo(_camera);
        }

        public void Freeze()
        {
            _playerBody.SetActive(false);
        }

        public void UnFreeze()
        {
            _playerBody.SetActive(true);
        }
    }
}
