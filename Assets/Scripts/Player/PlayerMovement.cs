using System.Collections;
using Tools.Audio;
using UnityEngine;

namespace LD47
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _controller = null;

        [SerializeField]
        private float _speed = 1f;

        [SerializeField]
        private Transform _playerBody = null;

        [SerializeField]
        private AudioSource _audioSource = null;

        [SerializeField]
        private SimpleAudioEvent _footStepsSFX = null;

        private bool _isMoving = false;

        private void Update()
        {
            float axisX = Input.GetAxis("Horizontal"); 
            float axisY = Input.GetAxis("Vertical");

            Vector3 move = _playerBody.right * axisX + _playerBody.forward * axisY;
            _controller.Move(move * _speed * Time.deltaTime);

            if (_isMoving && move.sqrMagnitude <= 0.1)
            {
                _isMoving = false;
                StopAllCoroutines();
            }
            else if (!_isMoving && move.sqrMagnitude > 0.1)
            {
                _isMoving = true;
                StartCoroutine(FootSteps());
            }
        }

        private IEnumerator FootSteps()
        {
            float interval = 0.6f;
            float timer = 0.5f;

            while (true)
            {
                if (timer >= interval)
                {
                    _footStepsSFX.Play(_audioSource);
                    timer = 0;
                }

                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
