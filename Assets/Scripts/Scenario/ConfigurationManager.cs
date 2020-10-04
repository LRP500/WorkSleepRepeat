using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD47
{
    [CreateAssetMenu(menuName = "LD47/Managers/Configuration Manager")]
    public class ConfigurationManager : ScriptableManager
    {
        [SerializeField]
        private List<Configuration> _configurations = null;

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
