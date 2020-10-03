using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace LD47
{
    public class GameplayManager : Singleton<GameplayManager>
    {
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
            _instructionManager.Initialize();
            _cameraManager.Initialize();

            CreatePlayer();
        }

        private void OnDestroy()
        {
            _instructionManager.Clear();
            _cameraManager.Clear();
        }

        public IEnumerator EndScene()
        {
            yield return _sceneFader.FadeOut();

            Destroy(_player.gameObject);
            CreatePlayer();

            yield return new WaitForSeconds(1f);
            yield return _sceneFader.FadeIn();
        }

        private void CreatePlayer()
        {
            _player = Instantiate(_playerPrefab);
        }
    }
}
