using UnityEngine;

namespace LD47
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

        public override void Execute()
        {
            base.Execute();
            CoroutineRunner.Instance.StartCoroutine(_cameraManager.TransitionTo(_transitionTo, _duration));
        }
    }
}