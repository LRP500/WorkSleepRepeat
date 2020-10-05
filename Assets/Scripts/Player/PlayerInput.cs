﻿using Tools.Variables;
using UnityEngine;

namespace LD47
{
    public class PlayerInput : MonoBehaviour
    {
        public static readonly KeyCode interactKey = KeyCode.E;

        [SerializeField]
        private CameraVariable _mainCamera = null;

        private void Update()
        {
            if (Input.GetKeyDown(interactKey))
            {
                _mainCamera.Value.GetComponent<Interactor>().TryInteract();
            }
        }
    }
}
