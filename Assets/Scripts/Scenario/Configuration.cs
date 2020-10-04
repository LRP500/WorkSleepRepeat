using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "LD47/Configuration")]
    public class Configuration : ScriptableObject
    {
        [Serializable]
        public struct StatConfiguration
        {
            [Range(0, 100)]
            public float value;

            public bool enabled; 
        }

        public bool enableCounter = false;
        public bool enableCameraFeeds = false;

        public bool displayStats = true;
        public StatConfiguration hunger;
        public StatConfiguration thirst;
        public StatConfiguration happiness;

        public List<Instruction> instructions = null;
    }
}
