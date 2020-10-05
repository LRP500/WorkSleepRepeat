using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "LD47/Configuration")]
    public class Configuration : ScriptableObject
    {
        #region Nested Structures

        [Serializable]
        public struct StatConfiguration
        {
            [Range(0, 100)]
            public float value;

            public bool enabled; 
        }

        [Serializable]
        public struct StateConfiguration
        {
            public ConfigurableID ID;
            public bool enabled;
        }

        #endregion Nested Structures

        public int subjectID;

        [FoldoutGroup("Player Stats")]
        public StatConfiguration hunger;

        [FoldoutGroup("Player Stats")]
        public StatConfiguration thirst;

        [FoldoutGroup("Player Stats")]
        public StatConfiguration happiness;

        public List<StateConfiguration> state = null;
        public List<Instruction> instructions = null;

        public bool Contains(ConfigurableID ID)
        {
            return state.Any(x => x.ID == ID);
        }

        public bool GetState(ConfigurableID ID)
        {
            return state.First(x => x.ID == ID).enabled;
        }
    }
}
