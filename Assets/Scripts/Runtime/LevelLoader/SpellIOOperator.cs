namespace Runtime.LevelLoader
{
    public class SpellIOOperator : BonusIOOperator
    {
        private const string FOLDER = "saves";
        private const string FILENAME_ALL = "spells.is";
        private const string FILENAME_ACTIVE = "activeSpells.is";

        public SpellIOOperator()
            : base(FOLDER, FILENAME_ALL, FILENAME_ACTIVE) { }
    }
}
