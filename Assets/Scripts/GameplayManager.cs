using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace LD47
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        [SerializeField]
        private List<ScriptableManager> _managers = null;

        [SerializeField]
        private CameraManager _cameraManager = null;

        [SerializeField]
        private Player _playerPrefab = null;

        [SerializeField]
        private SceneFader _sceneFader = null;

        private Player _player = null;

        private void Awake()
        {
            foreach (var manager in _managers)
            {
                manager.Initialize();
            }
        }

        private void Start()
        {
            CreatePlayer();
        }

        private void OnDestroy()
        {
            foreach (var manager in _managers)
            {
                manager.Clear();
            }
        }

        public IEnumerator EndScene()
        {
            yield return _sceneFader.FadeOut();

            Destroy(_player.gameObject);
            CreatePlayer();

            yield return new WaitForSeconds(2f);
            yield return _sceneFader.FadeIn();
        }

        private void CreatePlayer()
        {
            _player = Instantiate(_playerPrefab);
        }
    }
}
