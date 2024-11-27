using System.Collections.Generic;
using System.Linq;
using Enemy.Behaviours;
using Enemy.EnemyBase;
using Runtime;
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
            int index = Random.Range(0, _behaviorals.Count);
            EnemiesConfiguration randomBehaviour = _behaviorals[index];

            IEnemyBehavioral behavioral = Instance.GetByName<IEnemyBehavioral>(
                $"Enemy.Behaviours.{randomBehaviour.Name}",
                new SimpleEnemyBh()
            );

            randomBehaviour.Count--;
            if (randomBehaviour.Count == 0)
            {
                _behaviorals.Remove(randomBehaviour);
            }

            return behavioral;
        }
    }
}
