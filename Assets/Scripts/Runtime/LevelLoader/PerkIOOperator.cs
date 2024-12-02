using System.Collections.Generic;
using System.Linq;
using Bonus.Perk;

namespace Runtime.LevelLoader
{
    public class PerkIOOperator
    {
        private const string FOLDER = "saves";
        private const string FILENAME = "perks.is";


        public static void SavePerkLevels(Dictionary<string, PerkRarity> perks) => FileIO.Save(perks, FOLDER, FILENAME);

        public static Dictionary<string, PerkRarity?> GetActivePerks() => Load(LoadActive());

        private static Dictionary<string, PerkRarity?> Load(string[] activePerks)
        {
            var data = FileIO.Load<PerkUserData[]>(FOLDER, FILENAME);

            if (data != default(PerkUserData[]))
                return (activePerks.Length != 0
                        ? data.Where(perkData => activePerks.Contains(perkData.perkName))
                        : data)
                    .ToDictionary(key => key.perkName, value => (PerkRarity?)value.level);

            return activePerks.ToDictionary(key => key, value => (PerkRarity?)null);
        }


        public static void SaveAsActive(string[] perks) => FileIO.Save(perks, FOLDER, FILENAME);

        private static string[] LoadActive() => FileIO.Load<string[]>("saves", "activePerks.is");
    }

    [System.Serializable]
    public class PerkUserData
    {
        public string perkName;
        public float level;
    }
}