using System.Collections;
using Tools;
using UnityEngine;

namespace LD47
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        [SerializeField]
        private ConfigurationManager _configurationManager = null;

        [SerializeField]
        private InstructionManager _instructionManager = null;

        [SerializeField]
        private CameraManager _cameraManager = null;

        [SerializeField]
        private Player _playerPrefab = null;

        [SerializeField]
        private SceneFader _sceneFader = null;

        private Player _player = null;

        private void Awake()
        {
            _configurationManager.Initialize();
            _instructionManager.Initialize();
            _cameraManager.Initialize();
        }

        private void Start()
        {
            PrepareScene();
        }

        private void OnDestroy()
        {
            _instructionManager.Clear();
            _cameraManager.Clear();
        }

        private void CreatePlayer()
        {
            _player = Instantiate(_playerPrefab);
        }

        public IEnumerator EndScene()
        {
            yield return _sceneFader.FadeOut();

            CleanScene();

            _configurationManager.Increment();

            PrepareScene();

            yield return new WaitForSeconds(1f);
            yield return _sceneFader.FadeIn();
        }

        public void CleanScene()
        {
            Destroy(_player.gameObject);
        }

        public void PrepareScene()
        {
            CreatePlayer();

            _instructionManager.Refresh(_configurationManager.GetCurrent());
            _configurationManager.Run();
        }
    }
}
