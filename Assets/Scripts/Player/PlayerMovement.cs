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

        private void Update()
        {
            float axisX = Input.GetAxis("Horizontal"); 
            float axisY = Input.GetAxis("Vertical");

            Vector3 move = _playerBody.right * axisX + _playerBody.forward * axisY;
            _controller.Move(move * _speed * Time.deltaTime);
        }
    }
}
