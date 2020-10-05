﻿using Tools.Audio;
using UnityEngine;

namespace LD47
{
    [RequireComponent(typeof(AudioSource))]
    public class RegisterAudioSource : MonoBehaviour
    {
        [SerializeField]
        private AudioSourceVariable _variable = null;

        private void Awake()
        {
            _variable.SetValue(GetComponent<AudioSource>());
        }
    }
}
