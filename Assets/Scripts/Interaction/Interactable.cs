using UnityEngine;

namespace LD47
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private float _range = 1f;
        public float Range => _range;

        [SerializeField]
        private bool _canInteract = true;

        public void Interact()
        {
            if (_canInteract)
            {
            }
        }
    }
}
