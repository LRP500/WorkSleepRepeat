using System.Collections;
using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "LD47/Actions/Instruction Actions/Sleep")]
    public class InstructionActionSleep : InstructionAction
    {
        [SerializeField]
        private CameraManager _cameraManager = null;

        [SerializeField]
        private VirtualCameraVariable _transitionTo = null;

        [SerializeField]
        private float _duration = 2f;

        public override void Execute()
        {
            base.Execute();
            CoroutineRunner.Current.StartCoroutine(Sleep());
        }

        public IEnumerator Sleep()
        {
            _cameraManager.TransitionTo(_transitionTo);
            yield return new WaitForSeconds(_duration);
            yield return GameplayManager.Current.EndScene();
        }
    }
}