using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "LD47/Managers/Camera Manager")]
    public class CameraManager : ScriptableManager
    {
        [SerializeField]
        private PlayerVariable _player = null;

        private List<Camera> _securityCameras = null;

        private CinemachineVirtualCamera _currentCamera = null;

        public override void Initialize()
        {
            FindSecurityCameras();
            CoroutineRunner.Current.StartCoroutine(UpdateSecurityCameras());
        }

        public override void Clear()
        {
            _currentCamera = null;
        }

        public void FindSecurityCameras()
        {
            GameObject[] results = GameObject.FindGameObjectsWithTag("SecurityCamera");

            _securityCameras = new List<Camera>();
            foreach (GameObject item in results)
            {
                Camera camera = item.GetComponent<Camera>();

                if (camera)
                {
                    camera.enabled = false;
                    _securityCameras.Add(item.GetComponent<Camera>());
                }
            }
        }

        public void TransitionTo(CinemachineVirtualCamera nextCamera)
        {
            // Same camera
            if (_currentCamera == nextCamera)
            {
                return;
            }

            // First transition
            if (_currentCamera != null)
            {
                _currentCamera.enabled = false;

                // Transition out of player
                if (_currentCamera == _player.Value.Camera)
                {
                    _player.Value.Freeze();
                }
            }

            _currentCamera = nextCamera;
            _currentCamera.enabled = true;

            // Unfreeze player if necessary
            if (nextCamera == _player.Value.Camera)
            {
                _player.Value.UnFreeze();
            }
        }

        public IEnumerator TransitionTo(CinemachineVirtualCamera camera, float duration)
        {
            CinemachineVirtualCamera previous = _currentCamera;
            TransitionTo(camera);
            yield return new WaitForSeconds(duration);
            TransitionTo(previous);
        }

        private IEnumerator UpdateSecurityCameras()
        {
            if (_securityCameras.Count == 0)
            {
                yield break;
            }

            while (true)
            {
                for (int i = 0; i < _securityCameras.Count; i++)
                {
                    _securityCameras[i].Render();
                    yield return null;
                }
            }
        }
    }
}
