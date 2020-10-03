using UnityEngine;

namespace LD47
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        private string _label = string.Empty;
        public string Label => _label;

        [SerializeField]
        private float _range = 1f;
        public float Range => _range;

        [SerializeField]
        private bool _canBeInteractedWith = true;

        public void Interact()
        {
            if (_canBeInteractedWith)
            {
            }
        }
    }
}
