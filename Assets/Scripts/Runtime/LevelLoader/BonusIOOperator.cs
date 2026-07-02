using System.Collections.Generic;
using System.Linq;

namespace Runtime.LevelLoader
{
    public class BonusIOOperator
    {
        private readonly string FOLDER;
        private readonly string FILENAME_ALL;
        private readonly string FILENAME_ACTIVE;

        protected BonusIOOperator(string folder, string fileNameAll, string filenameActive)
        {
            FOLDER = folder;
            FILENAME_ALL = fileNameAll;
            FILENAME_ACTIVE = filenameActive;
        }

        protected void SaveAsActive(string[] bonus) => FileIO.Save(bonus, FOLDER, FILENAME_ACTIVE);

        protected Dictionary<string, byte?> LoadActive()
        {
            string[] activeBonus = FileIO.Load<string[]>(FOLDER, FILENAME_ACTIVE);
            BonusFileFormat[] allBonus = FileIO.Load<BonusFileFormat[]>(FOLDER, FILENAME_ALL);

            if (allBonus != null)
                return (
                    activeBonus.Length != 0
                        ? allBonus.Where(perkData => activeBonus.Contains(perkData.perkName))
                        : allBonus
                ).ToDictionary(key => key.perkName, value => (byte?)value.level);

            return activeBonus.ToDictionary(key => key, value => (byte?)null);
        }

        protected void Save(BonusFileFormat[] bonus) => FileIO.Save(bonus, FOLDER, FILENAME_ALL);

        protected void Load() => FileIO.Load<BonusFileFormat[]>(FOLDER, FILENAME_ALL);
    }

    [System.Serializable]
    public class BonusFileFormat
    {
        public string perkName;
        public byte level;
    }
}
