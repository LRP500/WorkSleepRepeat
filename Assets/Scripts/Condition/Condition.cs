using UnityEngine;

namespace WorkSleepRepeat
{
    public abstract class Condition : ScriptableObject
    {
        public abstract bool Evaluate();
    }
}
