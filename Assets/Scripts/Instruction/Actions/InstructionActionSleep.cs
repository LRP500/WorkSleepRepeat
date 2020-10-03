using UnityEngine;

namespace LD47
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
            CoroutineRunner.Instance.StartCoroutine(_cameraManager.TransitionTo(_transitionTo, _duration));
        }
    }
}