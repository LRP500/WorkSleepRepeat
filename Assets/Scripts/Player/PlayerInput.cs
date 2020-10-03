using UnityEngine;

namespace LD47
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private Interactor _interactor = null;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactor.TryInteract();
            }
        }
    }
}
