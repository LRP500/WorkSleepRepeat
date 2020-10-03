using UnityEngine;

namespace LD47
{
    public class PlayerMouseLook : MonoBehaviour
    {
        [SerializeField]
        private float _sensitivity = 50f;

        [SerializeField]
        private Transform _playerBody = null;

        [SerializeField]
        private Transform _playerHead = null;


        private float _rotationX = 0f;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            // Axis input
            float mouseX = Input.GetAxis("Mouse X") * _sensitivity * 10 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * 10 * Time.deltaTime;

            // Vertical rotation
            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
            _playerHead.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);

            // Horizontal rotation
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
