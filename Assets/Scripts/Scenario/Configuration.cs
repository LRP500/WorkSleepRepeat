using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WorkSleepRepeat
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

        [Serializable]
        public struct StateConfiguration
        {
            public ConfigurableID ID;
            public bool enabled;
        }

        public int subjectID;

        public StatConfiguration hunger;
        public StatConfiguration thirst;
        public StatConfiguration happiness;

        public List<StateConfiguration> state = null;
        public List<Instruction> instructions = null;

        // TEMP
        public bool thankYouForYourService = false;

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
