using System.Collections.Generic;
using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "LD47/Configuration")]
    public class Configuration : ScriptableObject
    {
        public bool enableCounter = false;
        public bool enableCameraFeeds = false;

        public List<Instruction> instructions = null;
    }
}
