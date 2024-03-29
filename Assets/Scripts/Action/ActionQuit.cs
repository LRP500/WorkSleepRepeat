﻿using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "LD47/Actions/Quit")]
    public class ActionQuit : Action
    {
        public override void Execute()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }
    }
}
