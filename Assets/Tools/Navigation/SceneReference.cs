using UnityEditor;
using UnityEngine;

namespace Tools.Navigation
{
    [CreateAssetMenu(menuName = "Tools/Navigation/Scene Reference")]
    public class SceneReference : ScriptableObject
    {
#if UNITY_EDITOR
        //[OnValueChanged("Refresh")]
        public SceneAsset asset;
#endif
        //[DisplayAsString]
        public new string name;

        //[DisplayAsString]
        public string path;

#if UNITY_EDITOR
        private void Refresh()
        {
        }

        private void OnValidate()
        {
            name = asset.name;
            path = AssetDatabase.GetAssetPath(asset);
        }
#endif
    }
}