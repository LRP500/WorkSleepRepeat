using Cinemachine;
using System.Collections;
using UnityEngine;

namespace LD47
{
[CreateAssetMenu(menuName = "LD47/Managers/Camera Manager")]
    public class CameraManager : ScriptableManager
    {
        [SerializeField]
        private PlayerVariable _player = null;

        private CinemachineVirtualCamera _currentCamera = null;

        public override void Initialize() { }

        public override void Clear()
        {
            _currentCamera = null;
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
    }
}
