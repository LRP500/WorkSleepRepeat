using UnityEngine;

namespace WorkSleepRepeat
{
    public abstract class Action : ScriptableObject
    {
        public virtual void Execute() { }
    }

    public abstract class Action<T> : Action
    {
        public virtual void Execute(T parameter) => base.Execute();
    }
}
