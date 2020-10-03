using UnityEngine;

namespace LD47
{
    public class PlayerInput : MonoBehaviour
    {
        public static readonly KeyCode interactKey = KeyCode.E;

        [SerializeField]
        private Interactor _interactor = null;

        private void Update()
        {
            if (Input.GetKeyDown(interactKey))
            {
                _interactor.TryInteract();
            }
        }
    }
}
