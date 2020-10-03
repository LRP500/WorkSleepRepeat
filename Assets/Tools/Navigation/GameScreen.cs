using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

namespace Tools.Navigation
{
    [CreateAssetMenu(menuName = "Tools/Navigation/Game Screen")]
    public class GameScreen : ScriptableObject
    {
        [SerializeField]
        private List<SceneReference> _scenes = null;
        public List<SceneReference> Scenes => _scenes;

        [SerializeField]
        private List<SceneReference> _dependencies = null;
    }
}
