using UnityEngine;

namespace LD47
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask = default;

        [SerializeField]
        private bool _canInteract = true;

        [SerializeField]
        private InteractionUI _feedbackUI = null;

        private Interactable _hovered;

        private void Update()
        {
            _hovered = GetInteractable();
            _feedbackUI.SetInteractable(_hovered);
        }

        private Interactable GetInteractable()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 10, _layerMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                float distance = Vector3.Distance(interactable.transform.position, transform.position);
                if (distance <= interactable.Range)
                {
                    return interactable;
                }
            }

            return null;
        }

        public void TryInteract()
        {
            if (_hovered != null && _canInteract)
            {
                _hovered.Interact();
            }
        }
    }
}
