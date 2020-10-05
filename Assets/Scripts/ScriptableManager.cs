using UnityEngine;
namespace WorkSleepRepeat
{
    public abstract class ScriptableManager : ScriptableObject
    {
        public virtual void Initialize() { }
        public virtual void Clear() { }
    }
}
