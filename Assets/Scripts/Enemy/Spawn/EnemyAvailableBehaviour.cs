using System;
using System.Collections.Generic;
using System.Linq;
using Enemy.Behaviours;
using Enemy.EnemyBase;
using Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Spawn
{
    public class EnemyAvailableBehaviour
    {
        private List<EnemiesConfiguration> _behaviorals;

        public EnemyAvailableBehaviour(EnemiesConfiguration[] enemies) =>
            _behaviorals = enemies.ToList();

        public bool HasBehaviour() => _behaviorals.Count != 0;

        public IEnemyBehavioral GetNext()
        {
            var index = Random.Range(0, _behaviorals.Count);
            var randomBehaviour = _behaviorals[index];

            string fullName = $"Enemy.Behaviours.{randomBehaviour.Name}";
            Type type = Type.GetType(fullName);

            IEnemyBehavioral behavioral;

            if (type != null && typeof(IEnemyBehavioral).IsAssignableFrom(type))
            {
                behavioral = (IEnemyBehavioral)Activator.CreateInstance(type);
            }
            else
            {
                behavioral = new SimpleEnemyBH();
                Debug.LogError($"name '{fullName}' not found!!");
            }

            randomBehaviour.Count--;
            if (randomBehaviour.Count == 0)
            {
                _behaviorals.Remove(randomBehaviour);
            }

            return behavioral;
        }
    }
}
