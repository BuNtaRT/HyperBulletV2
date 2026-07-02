#if UNITY_EDITOR
using System;
using System.Linq;
using Bonus.Perk;
using Bonus.Spells;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public static class BonusEnumValidator
    {
        static BonusEnumValidator()
        {
            ValidateSpellClasses();
            ValidatePerkClasses();
        }

        private static Type GetTypeByName(string fullName)
        {
            return AppDomain
                .CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(t => t.FullName == fullName);
        }

        private static void ValidateSpellClasses()
        {
            foreach (SpellType spell in Enum.GetValues(typeof(SpellType)))
            {
                string typeName = $"Bonus.Spells.Variations.{spell}";
                Type type = GetTypeByName(typeName);

                if (type == null)
                {
                    Debug.LogError(
                        $"Класс для способности {spell} не найден. Ожидается: {typeName}"
                    );
                }
            }
        }

        private static void ValidatePerkClasses()
        {
            foreach (PerkType spell in Enum.GetValues(typeof(PerkType)))
            {
                string typeName = $"Bonus.Perk.Variations.{spell}";
                Type type = GetTypeByName(typeName);

                if (type == null)
                {
                    Debug.LogError($"Класс для перка {spell} не найден. Ожидается: {typeName}");
                }
            }
        }
    }
}
#endif
