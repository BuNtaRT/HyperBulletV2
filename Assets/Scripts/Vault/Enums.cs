namespace Vault
{
    public enum ObjLayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        UI = 5,
    }

    public enum GameStatus
    {
        None,
        Pause,
        PickPerk,
        Action,
    }

    public static class GameTags
    {
        public const string ENEMY = "Enemy";
        public const string PLAYER = "Player";
        public const string BULLET = "Bullet";
        public const string BONUS = "Bonus";
    }
}
