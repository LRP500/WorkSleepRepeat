using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WorkSleepRepeat
{
    [CreateAssetMenu(menuName = "LD47/Managers/Configuration Manager")]
    public class ConfigurationManager : ScriptableManager
    {
        [SerializeField]
        private List<Configuration> _configurations = null;

#if UNITY_EDITOR
        [SerializeField]
        [BoxGroup("Debug")]
        private bool _debugMode = false;

        [SerializeField]
        [BoxGroup("Debug")]
        [ShowIf(nameof(_debugMode))]
        private List<Configuration> _debugConfigurations = null;
#endif

        private List<Configurable> _configurables = null;

        private int _currentConfigurationIndex = -1;

        public override void Initialize()
        {
            _configurables = FindObjectsOfType<Configurable>().ToList();
            _currentConfigurationIndex = 0;
        }

        public Configuration GetCurrent()
        {
            if (_currentConfigurationIndex >= _configurations.Count)
            {
                return null;
            }

#if UNITY_EDITOR
            if (_debugMode)
            {
                return _debugConfigurations[_currentConfigurationIndex];
            }
#endif

            return _configurations[_currentConfigurationIndex];
        }

        public void Run()
        {
            Configuration current = GetCurrent();

            foreach (var configurable in _configurables)
            {
                configurable.Configure(current);
            }
        }

        public void Increment()
        {
            _currentConfigurationIndex++;
        }
    }
}
