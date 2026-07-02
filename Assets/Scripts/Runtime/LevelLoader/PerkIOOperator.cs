namespace Runtime.LevelLoader
{
    public class PerkIOOperator : BonusIOOperator
    {
        private const string FOLDER = "saves";
        private const string FILENAME_ALL = "perks.is";
        private const string FILENAME_ACTIVE = "activePerks.is";

        public PerkIOOperator()
            : base(FOLDER, FILENAME_ALL, FILENAME_ACTIVE) { }
    }
}
