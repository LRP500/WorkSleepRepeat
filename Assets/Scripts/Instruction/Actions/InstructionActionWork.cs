using System.Collections;
using Tools.Audio;
using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "LD47/Actions/Instruction Actions/Work")]
    public class InstructionActionWork : InstructionAction
    {
        [SerializeField]
        private CameraManager _cameraManager = null;

        [SerializeField]
        private VirtualCameraVariable _transitionTo = null;

        [SerializeField]
        private float _duration = 2f;

        [Header("Audio")]

        [SerializeField]
        private SimpleAudioEvent _audioEvent = null;

        [SerializeField]
        private AudioSourceVariable _audioSource = null;

        public override void Execute()
        {
            base.Execute();
            CoroutineRunner.Instance.StartCoroutine(Work());
        }

        public IEnumerator Work()
        {
            CoroutineRunner.Instance.StartCoroutine(_cameraManager.TransitionTo(_transitionTo, _duration));
            yield return new WaitForSeconds(1f);
            _audioEvent?.Play(_audioSource);
        }
    }
}