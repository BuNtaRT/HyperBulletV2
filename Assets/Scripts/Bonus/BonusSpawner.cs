using Bonus.Perk;
using Bonus.Spells;
using Lib;
using Runtime;
using UnityEngine;
using Vault;

namespace Bonus
{
    public class BonusSpawner
    {
        public BonusSpawner()
        {
            GlobalEventsManager.OnEnemyDie.AddListener(OnEnemyDie);
        }

        private void OnEnemyDie(Vector2 enemyPosition)
        {
            int random = Random.Range(0, 101);
            SpawnPerk(enemyPosition);
            // if (LvlVariables.BonusSpawnChance > random)
            // {
            // random = Random.Range(0, 101);

            // тут шанс 1/5 что мы заспавним перк так как его отношение к способностям 1 к 4

            // if (random > 80)
            //     SpawnPerk(enemyPosition);
            // else
            //     SpawnSpell(enemyPosition);
            // }
        }

        private void SpawnPerk(Vector2 position)
        {
            var perkNameLevel = ArrayTools.GetRandom(LvlVariables.AvailablePerks);
            Debug.Log(perkNameLevel.Key);
            PerkSO perk = LoadPool.Load<PerkSO>(ResourcesPath.PerkSO(perkNameLevel.Key));
            // IPerk perk = Instance.GetByName<IPerk>(
            //     $"Bonus.Perks.{ArrayTools.GetRandom(LvlVariables.AvailablePerks)}",
            //     new DefaultPerk()
            // );
            if (perk)
            {
                var perkObject = ObjectPool.SpawnObj(TypeObj.Perk, position);
                perkObject.GetComponent<PerkBonus>().Set(perk);
            }
        }

        private void SpawnSpell(Vector2 position)
        {
            var spellName = ArrayTools.GetRandom(LvlVariables.AvailableSpells);
            SpellSO spell = LoadPool.Load<SpellSO>(ResourcesPath.SpellSO(spellName));

            if (spell)
            {
                var perkObject = ObjectPool.SpawnObj(TypeObj.Spell, position);
                perkObject.GetComponent<SpellOnRoad>().Set(spell);
            }
        }
    }
}