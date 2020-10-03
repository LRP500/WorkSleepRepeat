using UnityEngine;

namespace LD47
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask = default;

        public void TryInteract()
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 10, _layerMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                float distance = Vector3.Distance(interactable.transform.position, transform.position);
                if (distance <= interactable.Range)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
