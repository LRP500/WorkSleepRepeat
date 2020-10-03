using System.Collections.Generic;
using UnityEngine;

namespace LD47
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField]
        private List<ScriptableManager> _managers = null;

        private void Awake()
        {
            foreach (var manager in _managers)
            {
                manager.Initialize();
            }
        }
    }
}
