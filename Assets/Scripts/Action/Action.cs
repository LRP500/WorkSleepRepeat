using UnityEngine;

namespace LD47
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
